# GitHub Repository Yöneticisi  

Bu proje, GitHub repository'lerini yönetmek için geliştirilmiş bir masaüstü uygulamasıdır. Kullanıcılar, GitHub kullanıcı adlarını ve token'larını girerek kendi repository'lerini görüntüleyebilir, düzenleyebilir ve yönetebilirler.  

---

## 🚀 Özellikler  
- **Repo Yönetimi:** GitHub kullanıcı adı ve token kullanarak repo yönetimi sağlar.  
- **Otomatik Dosya Konumu Belirleme:** Repository'ler arasında seçim yaparak ilgili dosya konumlarını otomatik olarak belirler.  
- **Ayrıntılı Görüntüleme:** Seçilen repository için ayrıntıları gösterir.  
- **Güvenli Giriş:** Token doğrulaması ile güvenli giriş yapar.  

---

## 🔑 Giriş Sayfası İşleyişi  
![image](https://github.com/user-attachments/assets/0b4b5496-be9e-4bb0-9280-c9c1a14d74da)

Giriş sayfasında kullanıcıdan şu bilgiler istenir:  
- **GitHub Kullanıcı Adı** (`cmbGithubAd` kontrolü)  
- **Token** (`txtToken` kontrolü)  
- **Repository Adı** (`cmbRepoAdı` kontrolü)  

### Giriş Butonunun İşleyişi:  
- Kullanıcı, giriş butonuna bastığında (`btnGiris_Click`) seçilen repository adına göre dosya adı ve konumu belirlenir.  
- **Eğer `talhadrz.github.io` seçilirse:**  
  - Dosya Adı: `talhadrz`  
  - Dosya Konumu: `C:\Users\LENOVO\Desktop\Github Repositories\talhadrz`  
- **Eğer `projeler` seçilirse:**  
  - Dosya Adı: `projeler`  
  - Dosya Konumu: `C:\Users\LENOVO\Desktop\Github Repositories\projeler`  
- **Token girilmediyse,** kullanıcıya `Lütfen Repositorie Seç` mesajı gösterilir.  
- **Token girildiyse,** `Form2` açılır ve giriş sayfası gizlenir.  

---

## 📋 Ön Gereksinimler  
- .NET Framework ile uyumlu bir Windows işletim sistemi  
- GitHub API erişimi için kişisel token  

---

## 🔧 Kurulum ve Çalıştırma  
```bash
# Repository'yi klonlayın
git clone https://github.com/talhadrz/<repository-adı>.git

# Projeyi Visual Studio'da açın ve gerekli bağımlılıkları yükleyin
