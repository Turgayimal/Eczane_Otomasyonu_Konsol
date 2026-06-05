# Konsol Eczane Otomasyon Sistemi (Raporlama Odaklı)

C# dilinde geliştirilmiş, tamamen fonksiyon kullanılmadan (tek bir Main bloğu içerisinde) doğrusal ve paralel dizi (Parallel Arrays) mantığıyla yazılmış bir Eczane Otomasyon Sistemidir.

## Projenin Öne Çıkan Özellikleri

* **Detaylı Raporlama Modülü (Kritik Alan):** Otomasyonun kalbini oluşturan bu modül; yapılan toplam satış işlemini, satılan toplam ilaç kutusu sayısını, sistemdeki anlık toplam ciroyu ve ilaç bazlı toplam satış/gelir analizini anlık olarak hesaplar.
* **Kritik Stok Takibi:** Sistemdeki ilaçların stok miktarlarını sürekli denetler. Stoğu 5 kutunun altına düşen ilaçları hem listeleme ekranında hem de raporlama modülünde dinamik olarak "Kritik Stok!" uyarısıyla listeler.
* **Akıllı Stok Güncelleme:** Yeni bir ilaç eklenmek istendiğinde, sistem önce ilacın adını kontrol eder. Eğer ilaç zaten envanterde varsa sıfırdan eklemek yerine mevcut stoğun üzerine ekleme yapar.

## İşlevsel Modüller

1. **Ilac Listesi ve Stok Durumu:** Eczanedeki tüm ilaçları, fiyatlarını ve stok durumlarını düzgün bir tablo halinde listeler.
2. **Yeni Ilac Ekleme / Stok Guncelleme:** Envantere yeni ilaç girişlerini veya mevcut ilaçların stok takviyelerini yönetir.
3. **Ilac Satisi Yap:** İlaç arama, stok kontrolü, anlık stok düşümü ve satış tutarı hesaplama işlemlerini yürütür. Satış verilerini raporlama dizilerine kaydeder.
4. **RAPORLAMA MODULU:** Eczanenin tüm finansal ve envanter analizini tek ekranda özetler.

## Teknik Detaylar

* **Dil:** C# (.NET Konsol Uygulaması)
* **Mimari:** Fonksiyonsuz / Metotsuz Tasarım (Doğrusal Algoritma)
* **Veri Yönetimi:** Bellek üzerinde paralel diziler (`string[]`, `int[]`, `double[]`) kullanılarak veri entegrasyonu sağlanmıştır.
