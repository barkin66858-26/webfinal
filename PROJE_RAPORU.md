# PROJE RAPORU: BK Coaching Web Sitesi

**Ders:** Web Programlama
**Öğrenci Adı:** [İsim Soyisim]
**Numara:** [Öğrenci No]

---

## 1. Projenin Amacı
Bu projenin amacı, modern web teknolojileri ve MVC mimarisi kullanılarak dinamik bir Fitness/Spor Salonu yönetim sistemi geliştirmektir. Proje, kullanıcıların üyelik paketlerini inceleyebileceği bir arayüz ve yöneticilerin bu paketleri yönetebileceği (Ekleme, Silme, Güncelleme) bir yönetim paneli sunar.

## 2. Kullanılan Teknolojiler
*   **Backend:** ASP.NET Core MVC (.NET 8.0)
*   **Veritabanı:** SQLite (Entity Framework Core Code-First yaklaşımı)
*   **Frontend:** HTML5, CSS3 (Custom Dark Theme), JavaScript
*   **Geliştirme Ortamı:** Visual Studio Code / Visual Studio

## 3. Veritabanı Tasarımı
Projede Code-First yaklaşımı kullanılmıştır.

**Tablo: Users (Kullanıcılar)**
*   `Id` (PK, int): Kullanıcı benzersiz kimliği
*   `Username` (string): Kullanıcı adı
*   `Password` (string): Şifre
*   `IsAdmin` (bool): Yönetici yetkisi kontrolü

**Tablo: Packages (Paketler)**
*   `Id` (PK, int): Paket kimliği
*   `Name` (string): Paket adı (Örn: Gold Üyelik)
*   `Price` (decimal): Aylık ücret
*   `Description` (string): Paket açıklaması
*   `Features` (string): Özellikler (virgülle ayrılmış liste)
*   `ImageUrl` (string): Kampanya görseli linki

## 4. Backend Kod Yapısı ve MVC İlişkisi
Proje klasik MVC (Model-View-Controller) desenine uygun olarak yapılandırılmıştır:

*   **Models:** Veritabanı tablolarını temsil eden sınıflar (`User.cs`, `Package.cs`) burada tanımlanmıştır. `FitnessDbContext` sınıfı veritabanı bağlantısını yönetir.
*   **Controllers:** Gelen istekleri karşılayan sınıflardır.
    *   `HomeController`: Ana sayfa ve paket listeleme işlemlerini yönetir.
    *   `AdminController`: Sadece yetkili kullanıcıların erişebildiği, paket ekleme/silme işlemlerinin yapıldığı yerdir. `[Authorize]` attribute'u ile korunmaktadır.
    *   `AccountController`: Giriş (Login) ve Kayıt işlemlerini yönetir. Cookie Authentication kullanılarak oturum yönetimi sağlanmıştır.
*   **Views:** Kullanıcıya sunulan arayüzlerdir (Razor Pages - .cshtml). Ortak tasarım öğeleri (Navbar, Footer) `_Layout.cshtml` dosyasında tutularak kod tekrarı önlenmiştir.

## 5. CRUD İşlemleri ve Endpoint'ler (Admin Paneli)
Yönetim paneli `/Admin` endpoint'inde çalışır.
*   **Create (Ekleme):** `/Admin/Create` (GET: Formu gösterir, POST: Veriyi kaydeder)
*   **Read (Listeleme):** `/Admin/Index` (Tüm paketleri tablo halinde listeler)
*   **Update (Güncelleme):** `/Admin/Edit/{id}` (Mevcut paketi düzenler)
*   **Delete (Silme):** `/Admin/Delete/{id}` (Paketi veritabanından siler)

## 6. Sonuç ve Değerlendirme
Proje başarıyla tamamlanmış ve tüm temel gereksinimler karşılanmıştır. Responsive tasarım sayesinde mobil cihazlarda düzgün görüntülenmektedir. Admin paneli ile dinamik içerik yönetimi sağlanmıştır.

---
**Deployment Notu:**
Proje yerel ortamda SQLite veritabanı ile çalışmaktadır. Canlıya alınırken `appsettings.json` içerisindeki Connection String hedeflenen sunucuya (Azure SQL, PostgreSQL vb.) göre güncellenmelidir.
