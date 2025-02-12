using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Kod_Duzeltme
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string GithubAdı;// = "talhadrz"; // GitHub kullanıcı adı
        public string Reposito; // Repository adı
        public string Token;// = ""; // GitHub Token
        public string DosyaKonumu; // Masaüstüne indirilen dosyaların bulunduğu klasör yolu
        public string DosyaAdı; // Masaüstüne indirilen dosyaların bulunduğu klasör yolu
        public string url = "https://talhadrz.github.io/";

        private void Form2_Load(object sender, EventArgs e)
        {
            btnGithubDosyaAdı(sender, e);
            ClassOkuYaz("max");
        }
        private async void btnGithub(object sender, EventArgs e)
        {
            GithubİndirGuncelle(sender, e);
        }

        public async Task GithubİndirGuncelle(object sender, EventArgs e)
        {
            DialogResult kontrol = MessageBox.Show("Dosyaları Githuba Yüklemek için 'Evet', Bilgisayara indirmek için 'Hayır' seçin.", "İşlem Seçin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool karar = (kontrol == DialogResult.Yes ? true : false);
            DialogResult uyarı = MessageBox.Show("İşlemi Onaylamak için 'Evet' Onaylamamak İçin 'Hayır' Seçeneğini Seçin", "Uyarı", MessageBoxButtons.YesNo);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("C# GitHub API Client");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
                if (uyarı == DialogResult.Yes)
                {
                    if (karar)
                    {
                        foreach (var filePath in Directory.GetFiles(DosyaKonumu))
                        {
                            try
                            {
                                string fileName = Path.GetFileName(filePath);
                                string fileContent = File.ReadAllText(filePath);
                                string base64Content = Convert.ToBase64String(Encoding.UTF8.GetBytes(fileContent));
                                string url = $"https://api.github.com/repos/{GithubAdı}/{Reposito}/contents/{fileName}";

                                HttpResponseMessage response = await client.GetAsync(url);
                                string sha = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync()).sha : null;

                                var data = new { message = "Yüklenen dosya", content = base64Content, sha };
                                HttpResponseMessage uploadResponse = await client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

                                MessageBox.Show(uploadResponse.IsSuccessStatusCode ? $"✔ {fileName} başarıyla yüklendi." : $"❌ {fileName} yüklenirken hata oluştu.", "Bilgi", MessageBoxButtons.OK, uploadResponse.IsSuccessStatusCode ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        MessageBox.Show("✅ Tüm dosyalar başarıyla yüklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (!Directory.Exists(DosyaKonumu)) Directory.CreateDirectory(DosyaKonumu);

                        string jsonResponse = await client.GetStringAsync($"https://api.github.com/repos/{GithubAdı}/{Reposito}/contents/");
                        foreach (var item in JsonConvert.DeserializeObject<dynamic>(jsonResponse))
                        {
                            if (item.type == "file")
                            {
                                try
                                {
                                    byte[] fileData = await client.GetByteArrayAsync(item.download_url.ToString());
                                    File.WriteAllBytes(Path.Combine(DosyaKonumu, Path.GetFileName(item.download_url.ToString())), fileData);
                                    MessageBox.Show($"✔ Kaydedildi: {item.name}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        MessageBox.Show("✅ Tüm dosyalar başarıyla indirildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnDosyaKaydet(object sender, EventArgs e)
        {
           ClassOkuYaz("yaz", listBox2.SelectedItem.ToString());
        }
                    

        // index.html
        public string ClassOkuYaz(string karar, string uznt = "")
        {
            if (karar == "max")
                listBox2.Items.Clear();
            // Klasördeki tüm dosya isimlerini al
            if (Directory.Exists(DosyaKonumu))
            {
                string[] files = Directory.GetFiles(DosyaKonumu);

                // Dosya isimlerini yazdır
                foreach (string file in files)
                {
                    if (karar == "max")
                    {
                        listBox2.Items.Add(Path.GetFileName(file));
                    }
                   else if (karar == "oku")
                    {
                        if (Path.GetFileName(file) == uznt)
                        {
                            return File.ReadAllText(file);
                        }
                    }
                    else if (karar == "yaz")
                    {
                        if (uznt == Path.GetFileName(file))
                        {
                            File.WriteAllText(file, richTextBox1.Text);
                            MessageBox.Show($"✔ {uznt} başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Belirtilen klasör bulunamadı.");
            }
            return "Null";
        }

        private async void btnGithubDosyaİci(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir dosya seçin!");
                return;
            }

            string filePath = listBox1.SelectedItem.ToString(); // Seçili dosya yolu
            string fileContent;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("C# GitHub API Client");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                string url = $"https://api.github.com/repos/{GithubAdı}/{Reposito}/contents/{filePath}";

                HttpResponseMessage response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    fileContent = $"Hata: {response.StatusCode}";
                }

                string json = await response.Content.ReadAsStringAsync();
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                string base64Content = jsonObj.content;

                byte[] data = Convert.FromBase64String(base64Content);
                fileContent = Encoding.UTF8.GetString(data);
            }
            richTextBox1.Text = fileContent; // İçeriği göster
        }
        private async void btnDosyaKaydetGithuba(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir dosya seçin!");
                return;
            }

            string filePath = listBox1.SelectedItem.ToString(); // Seçili dosya yolu
            string newFileContent = richTextBox1.Text; // RichTextBox'tan alınan metin

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("C# GitHub API Client");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                string url = $"https://api.github.com/repos/{GithubAdı}/{Reposito}/contents/{filePath}";

                // Mevcut dosya bilgilerini almak için GET isteği
                HttpResponseMessage response = await client.GetAsync(url);
                string sha = string.Empty;

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic jsonObj = JsonConvert.DeserializeObject(jsonResponse);
                    sha = jsonObj.sha; // Dosyanın SHA değerini al
                }

                // Dosyanın yeni içeriğini Base64 formatına çevir
                string base64Content = Convert.ToBase64String(Encoding.UTF8.GetBytes(newFileContent));

                // Yükleme verisi
                var data = new
                {
                    message = "Dosya güncellendi", // Commit mesajı
                    content = base64Content, // Base64 kodlanmış içerik
                    sha = sha // Eğer dosya varsa, SHA-1 değeri
                };

                string jsonData = JsonConvert.SerializeObject(data);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Dosyayı GitHub'a güncelleme (PUT isteği)
                HttpResponseMessage uploadResponse = await client.PutAsync(url, content);

                if (uploadResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show($"✔ {filePath} başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"❌ {filePath} güncellenirken hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnGithubDosyaAdı(object sender, EventArgs e)
        {
            List<string> dosyaListesi;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("C# GitHub API Client");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                string url = $"https://api.github.com/repos/{GithubAdı}/{Reposito}/contents/";
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Hata: {response.StatusCode}");
                    dosyaListesi = new List<string>();
                }

                string json = await response.Content.ReadAsStringAsync();
                dynamic jsonObj = JsonConvert.DeserializeObject(json);

                List<string> fileList = new List<string>();

                foreach (var item in jsonObj)
                {
                    if (item.type == "file")
                    {
                        fileList.Add((string)item.path);
                    }
                }
                dosyaListesi = fileList;
            }
            listBox1.Items.Clear();
            foreach (string dosya in dosyaListesi)
            {
                listBox1.Items.Add(dosya);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmGiris frm = new frmGiris();
            frm.Show();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGithubDosyaİci(sender, e);
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = ClassOkuYaz("oku",listBox2.SelectedItem.ToString());
        }

        private void btnCalıstır_Click(object sender, EventArgs e)
        {
            // Dosya yolu belirleyin (örneğin bir HTML dosyası)
            string filePath = $"C:\\Users\\LENOVO\\Desktop\\Github Repositories\\{DosyaAdı}\\index.html"; // Dosya yolunu buraya yaz

            try
            {
                // Dosyayı varsayılan uygulama ile aç
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosya açılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalıstırGithub_Click(object sender, EventArgs e)
        {
            // Chrome'un yüklü olduğu dosya yolu (Yüklü değilse değiştirebilirsiniz)
            string chromePath = @"C:\Users\LENOVO\Desktop\Talha - Chrome.lnk";

          

            try
            {
                // Chrome'u aç ve URL'yi ver
                Process.Start(chromePath, url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chrome açılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void label5_Click(object sender, EventArgs e)
        {
            string Kopyala = Clipboard.GetText();
            richTextBox1.Text = Kopyala;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
    }
}