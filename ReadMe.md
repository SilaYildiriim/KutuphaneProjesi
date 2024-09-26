# Kutuphane Projesi

Kutuphane Projesi, kullanıcıların kitapları ekleyip, güncelleyip, silebileceği kapsamlı bir kütüphane yönetim sistemidir. Modern web teknolojileri kullanılarak geliştirilmiş olan bu sistemde, kullanıcı arayüzü için dinamik bir deneyim sunan React kullanıldı. React ile, kullanıcıların kitapları hızlıca keşfetmelerine ve detaylarını görüntülemelerine olanak tanıyan bir arayüz tasarlandı.

Veritabanı işlemleri ve sunucu tarafı mantığı için .NET 7 Web API tercih edildi. Bu sayede, kitapların eklenmesi, güncellenmesi ve silinmesi gibi işlemlerin sorunsuz bir şekilde verilmesi sağlandı. .NET 7 ile API oluşturmak, veri yönetimini kolaylaştırırken, kullanıcıların taleplerine hızlı yanıt verilmesini sağlıyor. Ayrıca, kullanıcı ve admin rolleri arasında net bir ayrım yaparak, her iki grubun ihtiyaçlarına uygun işlevler sunulması hedeflenildi.

Bu sistem, kullanıcıların giriş yaparak kütüphane kitaplarını keşfetmelerine ve arama yaparak detaylarını görüntülemelerine olanak tanırken, adminler ise kapsamlı bir yönetim paneline erişim sağlayarak kitaplar üzerinde tam kontrol elde ederler.

Adminler, yeni kitap ekleme, mevcut kitapları güncelleme ve istenmeyen kitapları silme gibi yönetim işlemlerini kolayca gerçekleştirebilir. Kullanıcılar, arayüz üzerinden hızlı bir şekilde giriş yaparak kütüphanedeki mevcut kitapları arayabilir ve bu kitapların yazarları, yayınevleri ve fiyatları gibi bilgilerini görüntüleyebilirler. Adminlerin sağladığı yönetimsel yetkiler sayesinde, kütüphanenin güncel kalması ve kullanıcıların ihtiyaçlarına uygun içeriklerin sunulması sağlanmaktadır.

### Giriş Bilgileri

- **User için:**
  - **Kullanıcı Adı:** user
  - **Şifre:** password

- **Admin için:**
  - **Kullanıcı Adı:** admin
  - **Şifre:** password


## Gereksinimler

- Frontend: React (VS Code kullanımı önerilir)
- Backend: .NET 7 Web API (Visual Studio ile geliştirilmiştir)
- Node.js: En güncel sürüm

## Kurulum

### Frontend Kurulumu

1. Proje Klasörüne Girin: `KutuphaneProjesi.UI` klasörüne gidin.
2. Node Modüllerini Yükleyin: Aşağıdaki komutu terminalde çalıştırın:
   npm install
3.Projeyi Çalıştırın: Aşağıdaki komutu terminalde çalıştırın:
   npm run dev
4. URL Ayarları: Kendi lokal URL'lerinizi ayarlamak için aşağıdaki dosyaları düzenleyin:
   - `src/services/AuthService.jsx`
   - `src/context/ApiContext.jsx`
   
   Bu dosyalarda `YourLocalHost` kısmını kendi API bağlantı URL'nizle değiştirin.

### Backend Kurulumu

1. Proje Klasörüne Girin: `KutuphaneProjesi.API` klasörüne gidin.
2. Projeyi Açın: KutuphaneProjesi.sln dosyasına tıklayarak projeyi açın.
3. Veritabanı Bağlantısı: Infrastructure.Context içindeki AppDbContext dosyasını açın ve kendi veritabanı bağlantı bilgilerinizi girin.
4. CORS Ayarları: program.cs dosyasındaki AddCors alanındaki URL'yi React projenizdeki localhost URL'nizle değiştirin.
5. Migration Ekleme: Migration işlemleri için aşağıdaki komutları çalıştırın:
   Add-Migration init
   Update-Database
6. Projeyi Çalıştırma: `KutuphaneProjesi.sln` dosyasına tıklayarak projeyi açın ve çalıştırın.

## Kullanım

### User

- Giriş: Userlar sisteme giriş yaparak kütüphane kitaplarını keşfedebilir.
- Kitap Görüntüleme: Userlar arama yaparak buldukları kitapların detaylarını görüntüleyebilir.
- Hata Mesajları: Hatalar durumunda kullanıcı dostu hata mesajları görüntülenmektedir.

### Admin

- Giriş: Adminler giriş yaparak yönetim paneline erişebilir.
- Kitap Ekleme: Adminler yeni kitaplar ekleyebilir. Dosya yükleme özelliği bulunmaktadır.
- Kitap Silme: Adminler mevcut kitapları silebilir.
- Kitap Güncelleme: Adminler kitap bilgilerini güncelleyebilir.
- Kitap Görüntüleme: Adminler tüm kitapları görüntüleyebilir.

## Notlar

- Proje üzerinde çalışırken, backend ve frontend URL'lerinin doğru ayarlandığından emin olun.
