# 💈 Dinamik Erkek Kuaför Randevu Sistemi
Bu proje, ASP.NET Core 8 altyapısı kullanılarak geliştirilen dinamik bir erkek kuaför randevu sistemi uygulamasıdır. Modern kullanıcı arayüzü, esnek yönetim panelleri ve kullanıcı dostu etkileşimli randevu modülleriyle sektöre özel çözüm sunar. Kuaförlere özel yönetim ekranları, ziyaretçiler için detaylı hizmet tanıtım sayfaları ve gelişmiş randevu alma mekanizması ile kapsamlı bir sistem geliştirilmiştir.

## 📝 Öne Çıkan Özellikler
- **Ana Sayfa**: Hizmet verilen sektör hakkında tanıtıcı içerik, kuaför bilgileri ve hızlı erişim bölümleri.
- **Hizmet Tanıtımı**: Erkek kuaför hizmetlerinin detaylı şekilde sunulduğu bilgilendirici sayfa.
- **Randevu Alma Modülü**:
   - Kullanıcı, kuaförü seçer.
   - Seçilen kuaföre ait uygun günler AJAX ile getirilir.
   - Seçilen güne göre uygun saatler yine AJAX ile dinamik şekilde listelenir.
- **Berber Profilleri**: Her kuaföre özel çalışma saatleri, randevu geçmişi ve kullanıcıya özel gösterim alanı.
- **Admin Paneli**: Tüm sistem verilerini yöneten kapsamlı kontrol paneli.
- **Kuaför Yönetim Paneli**: Her berbere özel olarak biçimlendirilmiş panel ile çalışma saatlerini, hizmetleri ve randevuları yönetme imkânı.
- **Randevu Takvimi**: Kuaföre özel tanımlanan gün ve saatlere göre otomatik randevu oluşturma altyapısı.
- **CRUD İşlemleri**: Tüm panellerde içerik ekleme, silme, güncelleme ve listeleme fonksiyonları.
- **Kullanıcı Giriş** Panelleri: Hem admin hem de kuaförler için güvenli giriş ekranları.

## 🛠️ Teknolojik Altyapı
- **🖥️ ASP.NET Core 8 (MVC)**: Modern web geliştirme mimarisiyle sürdürülebilir yazılım altyapısı.
- **🗃️ Entity Framework Core (Code First)**: Veritabanının koddan türetilerek yönetilmesi.
- **🔄 LINQ Sorguları**: Etkili veri filtreleme ve sorgulama mekanizması.
- **🔐 Authentication & Authorization**:
   - Authentication.Cookies
   - Security.Claims ile kullanıcı tanıma ve yetkilendirme
- **📊 JSON & AJAX**:
   - Dinamik randevu alma işlemlerinde kuaför ve güne özel verileri getirme
   - 💻 HTML, CSS, Bootstrap, JavaScript: Responsive ve kullanıcı dostu arayüz tasarımı.
   - 📦 Partial View & ViewComponent: Sayfa içi bileşenlerin modüler kullanımı.
   - 📐 Layout Yapılandırması: Tüm site sayfalarında tutarlı ve şık görünüm.

 ## 📚 Kullanım
 - **Admin Paneli**:
   - Tüm kuaförlerin, kullanıcıların, hizmetlerin ve randevuların yönetimi.
   - CRUD işlemleri ile sistem verilerinin tam kontrolü.
- **Kuaför Paneli**:
   - Her kuaför sadece kendi randevularını ve çalışma saatlerini görebilir ve yönetebilir.
   - Kullanıcıdan gelen randevuların detaylı listesi.
- **Ziyaretçi Arayüzü**:
   - Kullanıcılar diledikleri kuaförü seçerek hızlıca randevu alabilir.
   - Uygun gün ve saatler dinamik olarak listelenir.
- **Giriş Panelleri**:
   - Admin ve kuaförler için güvenli kimlik doğrulama mekanizması.
   - Gelişmiş Randevu Motoru:
   - Çalışma takvimi üzerinden otomatik saat üretimi.
   - Kuaföre özel randevu saatlerinin otomatik hesaplanması.

## 📸 Proje Görselleri

- **Ana Sayfa**
   - ![Ekran görüntüsü 2025-06-26 004332](https://github.com/user-attachments/assets/90411c9b-c530-4d74-b904-422d36e04cac)

- **Hakkımızda**
   - ![Ekran görüntüsü 2025-06-26 013243](https://github.com/user-attachments/assets/7b1502de-143a-4a6c-a65f-246deb37b7aa)
     
- **Tarz**
   - ![Ekran görüntüsü 2025-06-26 013309](https://github.com/user-attachments/assets/ef48c471-0c69-467e-8cf4-74d89b8b99b2)

- **Hizmetlerimiz**
   - ![Ekran görüntüsü 2025-06-26 013346](https://github.com/user-attachments/assets/d7d43457-60b6-4a6b-8cd2-708892d6646a)

- **Cut & Style**
   - ![Ekran görüntüsü 2025-06-26 013414](https://github.com/user-attachments/assets/7b57c40c-4a43-48fe-8cfa-b29adb1e61f4)

- **Yorumlar**
   - ![Ekran görüntüsü 2025-06-26 013431](https://github.com/user-attachments/assets/c470bd1a-94ba-44ef-b1e4-a6e99e08d11e)

- **İletişim**
   - ![Ekran görüntüsü 2025-06-26 013444](https://github.com/user-attachments/assets/6f9c1ac1-de00-4692-ab7d-5fe8d18cf922)

- **Randevu Al**
   - ![Ekran görüntüsü 2025-06-26 004418](https://github.com/user-attachments/assets/286d0fb3-25bd-44f8-9871-c90b4774440d)


## 🛠️ Admin Paneli

- **Kuaförler**
    - ![Ekran görüntüsü 2025-06-26 005554](https://github.com/user-attachments/assets/a24caeef-6eb3-43e4-8326-ff0b70e6eefa)

- **Kampanyalar**
    - ![Ekran görüntüsü 2025-06-26 005717](https://github.com/user-attachments/assets/28aaac68-a43e-47ce-bc53-710854153057)


## 💈 Kuaför Paneli

- **Profil**
    - ![Ekran görüntüsü 2025-06-26 005530](https://github.com/user-attachments/assets/68454019-1c36-4dfd-a1b6-ad3b6b00e265)

- **Randevular**
    - ![Ekran görüntüsü 2025-06-26 005327](https://github.com/user-attachments/assets/33d7163a-f8f4-4972-bcd5-e23ed716af34)

- **Randevu Günleri**
    - ![Ekran görüntüsü 2025-06-26 005406](https://github.com/user-attachments/assets/61d78241-5f20-4974-a707-32b929c5e5c7)

  - **Yeni Randevu Günü Ekle**
      - ![Ekran görüntüsü 2025-06-26 005507](https://github.com/user-attachments/assets/dedd0ffc-555b-443d-b17b-f34ca000b49b)

- **Randevu Saatleri**
    - ![Ekran görüntüsü 2025-06-26 005426](https://github.com/user-attachments/assets/9fdf0ebb-2dbd-42c5-b865-8f4f08502eae)

- **Randevu Tarihleri**
    - ![Ekran görüntüsü 2025-06-26 005444](https://github.com/user-attachments/assets/197c76c3-3a3a-441b-9561-549c98f744e5)


## 🔐 Giriş Panelleri

- **Kuaför Giriş Paneli**
     - ![Ekran görüntüsü 2025-06-26 004232](https://github.com/user-attachments/assets/fa809c42-db8a-46c4-a2f3-b59619cced92)

- **Admin Giriş Paneli**
     - ![Ekran görüntüsü 2025-06-26 004251](https://github.com/user-attachments/assets/8e75a1e3-89e5-4417-a18e-a4cb1a29bf0f)

## 📝 Veritabanı Yapısı
  - ![image](https://github.com/user-attachments/assets/bb86ba3f-9ac5-41a5-95a9-3504c65f3816)


## 📜 Sürüm Geçmişi
- Proje Visual Studio 2022 ile geliştirildi.
