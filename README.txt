# Kutuphane Projesi

Kutuphane Projesi, kullanıcıların kitapları ekleyebileceği, güncelleyebileceği, silebileceği ve görüntüleyebileceği bir kütüphane yönetim sistemi sunmaktadır. React frontend ile .NET 7 Web API backend'i kullanarak geliştirilmiştir.

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
2. Veritabanı Bağlantısı: `Infrastructure.Context` içindeki `AppDbContext` dosyasını açın ve kendi veritabanı bağlantı bilgilerinizi aşağıdaki gibi girin:
   "Server=YourServerName;Database=KutuphaneProjesiDB;Uid=YourLoginName;Pwd=YourPassword;TrustServerCertificate=True;"
3. CORS Ayarları: `program.cs` dosyasındaki `AddCors` alanındaki URL'yi React projenizdeki localhost URL'nizle değiştirin.
4. Migration Ekleme: Migration işlemleri için aşağıdaki komutları çalıştırın:
   Add-Migration init
   Update-Database
5. Projeyi Çalıştırma: `KutuphaneProjesi.sln` dosyasına tıklayarak projeyi açın ve çalıştırın.

## Kullanım

- Giriş: Kullanıcılar giriş yapabilir ve sistemdeki kitapları yönetebilir.
- Kitap Ekleme: Kullanıcılar yeni kitaplar ekleyebilir. Dosya yükleme özelliği bulunmaktadır.
- Kitap Silme: Kullanıcılar mevcut kitapları silebilir.
- Kitap Güncelleme: Kullanıcılar kitap bilgilerini güncelleyebilir.
- Kitapları Görüntüleme: Kullanıcılar tüm kitapları görüntüleyebilir.

## Notlar

- Proje üzerinde çalışırken, backend ve frontend URL'lerinin doğru ayarlandığından emin olun.
- Hatalar durumunda kullanıcı dostu hata mesajları görüntülenmektedir.
- Herhangi bir sorunla karşılaşırsanız, lütfen projedeki hata kayıtlarını kontrol edin.

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen bir pull request gönderin.

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasını kontrol edin.
