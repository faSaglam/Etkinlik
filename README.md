# Etkinlik

Konfidens .Net Hiring Chalange için geliştirilmiştir.
## Demo
https://www.youtube.com/watch?v=qGN0msoOsYY 
demoyu linkten izleyebilirsiniz.

## Kurulum
Proje codefirst mantığı ile yazılmış olup **Package Manager Console'da**
<ol>
  <li>Default Project'de DataAccess'i seçin</li>
   <li>Console'a Update-Database diyerek</li>
</ol> 
veri tabanını ayağa kaldırabilirsiniz.
<br/>
Not:
<br/>
Admin kullanıcı için , Kullanıcı adı: omfasaglam@gmail.com , şifre Admin*123 ;
<br/>
User için Kullanıcı adı : testuser@testuser.com , şifre : Test-123
<br/>
Sisteme default olarak eklenmiştir.
Sistemde testuser@testuser.com'a ait default etkinlikler mevcuttur.
<hr/>
Bir hata ile karşılaşırsanız:
EventUI > appsettings.json ve appsettings.Development.json 'da "DefaultConnection" stringi ve 
DataAccess>Concreate>EventsDbContext da 

` protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){optionsBuilder.UseSqlServer("Connection string ");}`

 Connection stringi değiştirin.ConnectionStringlerin **aynı olmasına** lütfen dikkat ediniz.



# Kullanım Seneryosu

<ul>
  <li>Kullancılar en az 5 gün ilerisine bir etkinlik oluşturabilirler.</li>
   <li>Etkinliğin kişi sayısı en az 5 olmalıdır.</li>
  <li>Oluşturalan etkinlik Admin kullanıcısı tarafından onaylanır ya da iptal edilir.</li>
  <li>Her kullanıcı  her etkinliğe bir bilet alabilir.</li>
  <li>Biletler ücretsizdir ve kapıdaki görevli tarafından kontrol edilecektir.</li>  
</ul>


## Normal Kullanıcılar İçin (User) 


### Üye Olma ve Güncelleme
**/User/Register** rotasında kullanıclar mail adresi , isim , soyisim ve en az 8 karakterden oluşan , en az bir büyük harf, bir küçük harf ve bir rakamdan oluşan bir şifre ile üye olabilirler.
**User/Login** rotasıyla üye girişi yapıldıktan sonra **User/Profile** rotasında bilgilerini görüntüleyebilir ve güncelleyebilirler.

### Etkinlik Ekleme , Onaylama Ve Bilet 

Her eklenen etkinlik *bool IsConfirmed* özelliği otomatik olarak *false* yani onaylanmamış olarak işaretlenir.Bu özelliği Admin değiştirebilir.
Etkinlikler bugünün tarihinden en erken **5 gün sonraya** oluşturalabilir. Etkinliğin onaylanıp onaylanmadığını kişi kendi sayfasından takip edebilir.
Etkinliğin gerçekleşeceği tarihe 5 günden az süre kalmadıysa güncelleme ve silme işlemlerini gerçekleştirebilir.
Güncellenen etkinlikte yeni kişi sayısı satılan biletlerden az olamaz.

Onaylanmış etkinlikler **Event/List** rotasında görülür. Kişi arama kısmını kullanarak isteğine göre arama yapabilir. İstediği etkinlikten bilet alabilir.
Her oluşturalan bilet için Etkinliğin Id'si ve İsmi , Kullanıcı adının yer aldığı bir bilet numarası oluşturulur.
Kapıdaki görevli sadece etkinliğin İd si ve kullanıcı adını girerek bileti doğrular.


## Admin Kullanıcı
Sistem ayağa kaldırılırken oluşan omfasaglam@gmail.com ve Admin*123 şifresi ile giriş yapabilirsiniz.

Profili güncelleyebilir , şehir ve kategori ekleyebilirsiniz.

Oluşturulan etkinliklere onay verebilir veya silebilirsiniz( gerçekleşmesine 5 günden az kalmadıysa)

# Kullanılan Teknolojiler ve Kütüphaneler 

<ul>
  <li>Sistemde dil olarak C# , framework olarak .Net kullanılmıştır.</li>
  <li>Veritabanı MSSQL server üzerine oturtulmuştur.</li>
   <li>Entity Framework ile entity sınıfları veritabanına konfigure edilmiştir.</li>
  <li>Proje CodeFirst yaklaşımı ile ayağa kaldırılmıştır.</li>
    <li>Microsoft.AspNetCore.Identity.EntityFrameworkCore ile kullanıcı tarafı oluşturulmuştur. Kullanıcı oturumu cookie üzerinden takip edilmektedir.</li>
</ul>









