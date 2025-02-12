# GitHub Dosya Yöneticisi

Bu proje, **C# Windows Forms** kullanılarak geliştirilmiş bir GitHub dosya yöneticisidir. Uygulama, GitHub deposuna dosya yükleme, güncelleme ve indirme işlemlerini kolayca yapmanızı sağlar.

---

## 📌 Özellikler

- **GitHub'a Dosya Yükleme ve Güncelleme:**  
  Dosyaları GitHub deposuna yükleyebilir veya mevcut dosyaları güncelleyebilirsiniz.

- **GitHub'dan Dosya İndirme:**  
  Depodaki dosyaları bilgisayarınıza indirebilirsiniz.

- **Dosya İçeriğini Görüntüleme ve Düzenleme:**  
  GitHub'daki dosya içeriğini görüntüleyebilir ve düzenleyebilirsiniz.

- **Masaüstü ile Senkronizasyon:**  
  Dosyaları masaüstü klasörünüzde tutarak GitHub ile senkronize çalışabilirsiniz.

---

## 🛠️ Gereksinimler

- **.NET Framework** 4.7.2 ve üzeri
- **Visual Studio** veya başka bir C# IDE
- **GitHub Token** (Yetkilendirme için gerekli)

---

## 🚀 Kurulum ve Kullanım

1. **Projeyi Klonla veya İndir:**
    ```bash
    git clone https://github.com/talhadrz/GitHubDosyaYonetici.git
    ```
2. **Visual Studio ile Açın ve Gerekli Bağımlılıkları Kurun.**
3. **GitHub Token Ayarları:**
   - `Token` alanına GitHub kişisel erişim anahtarınızı girin.
   - Gerekli izinleri içeren bir token oluşturun: `repo` yetkisi gereklidir.
4. **Giriş Ekranında:**
   - GitHub kullanıcı adınızı ve tokenınızı girin.
   - Depo adını seçin.
5. **Dosya İşlemleri:**
   - Dosyaları yükleyebilir, güncelleyebilir veya indirebilirsiniz.

---

## 📂 Proje Yapısı

```plaintext
📁 GitHubDosyaYonetici
│   ├── Form1.cs          # Giriş Formu
│   ├── Form2.cs          # Dosya Yönetim Formu
│   ├── Program.cs        # Ana Başlangıç Dosyası
│   └── README.md         # Proje Tanıtımı
