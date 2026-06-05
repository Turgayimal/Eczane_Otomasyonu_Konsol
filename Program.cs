#nullable disable
using System;

namespace EczaneOtomasyonu
{
    class Program
    {
        static void Main(string[] sender)
        {
            string[] ilacAdlari = new string[100];
            int[] ilacStoklari = new int[100];
            double[] ilacFiyatlari = new double[100];
            int mevcutIlacCesidi = 0;

            ilacAdlari[0] = "Parol"; ilacStoklari[0] = 50; ilacFiyatlari[0] = 45.50;
            ilacAdlari[1] = "Ar evil"; ilacStoklari[1] = 4; ilacFiyatlari[1] = 60.00;
            ilacAdlari[2] = "Aspirin"; ilacStoklari[2] = 30; ilacFiyatlari[2] = 35.00;
            ilacAdlari[3] = "Augmentin"; ilacStoklari[3] = 15; ilacFiyatlari[3] = 120.50;
            ilacAdlari[4] = "Majezik"; ilacStoklari[4] = 25; ilacFiyatlari[4] = 55.00;
            mevcutIlacCesidi = 5;

            string[] satisIlacAdlari = new string[500];
            int[] satisAdetleri = new int[500];
            double[] satisGelirleri = new double[500];
            int toplamSatisIslemiSayisi = 0;

            bool sistemCalisiyor = true;

            while (sistemCalisiyor)
            {
                Console.Clear();
                Console.WriteLine("=== ECZANE OTOMASYON SISTEMI ===");
                Console.WriteLine("1. Ilac Listesi ve Stok Durumu");
                Console.WriteLine("2. Yeni Ilac Ekleme / Stok Guncelleme");
                Console.WriteLine("3. Ilac Satisi Yap");
                Console.WriteLine("4. RAPORLAMA MODULU (Kritik Alan)");
                Console.WriteLine("5. Sistemden Cikis");
                Console.WriteLine("--------------------------------");
                Console.Write("Yapmak istediginiz islemi secin (1-5): ");

                string anaSecim = Console.ReadLine();

                if (anaSecim == "1")
                {
                    Console.Clear();
                    Console.WriteLine("=== MEVCUT ILAC LISTESI ===");
                    Console.WriteLine(string.Format("{0,-5} {1,-20} {2,-15} {3,-10}", "No", "Ilac Adi", "Stok Miktari", "Fiyat"));
                    Console.WriteLine("---------------------------------------------------------");

                    for (int i = 0; i < mevcutIlacCesidi; i++)
                    {
                        string stokDurumu = ilacStoklari[i].ToString();
                        if (ilacStoklari[i] < 5)
                        {
                            stokDurumu += " (Kritik Stok!)";
                        }

                        Console.WriteLine(string.Format("{0,-5} {1,-20} {2,-15} {3,-10:C2}", (i + 1), ilacAdlari[i], stokDurumu, ilacFiyatlari[i]));
                    }

                    Console.WriteLine("\nAna menuye donmek icin ENTER'a basin...");
                    Console.ReadLine();
                }
                else if (anaSecim == "2")
                {
                    Console.Clear();
                    Console.WriteLine("=== YENI ILAC / STOK EKLEME ===");
                    Console.Write("Ilac Adini Girin: ");
                    string girilenAd = Console.ReadLine();

                    int bulunanIndeks = -1;
                    for (int i = 0; i < mevcutIlacCesidi; i++)
                    {
                        if (ilacAdlari[i].ToLower() == girilenAd.ToLower())
                        {
                            bulunanIndeks = i;
                            break;
                        }
                    }

                    if (bulunanIndeks != -1)
                    {
                        Console.WriteLine($"\nBu ilac sistemde zaten kayitli. Mevcut stok: {ilacStoklari[bulunanIndeks]}");
                        Console.Write("Eklenecek stok miktarini girin: ");
                        int ekStok;
                        if (int.TryParse(Console.ReadLine(), out ekStok) && ekStok > 0)
                        {
                            ilacStoklari[bulunanIndeks] += ekStok;
                            Console.WriteLine($"\nStok basariyla guncellendi. Yeni Stok: {ilacStoklari[bulunanIndeks]}");
                        }
                        else
                        {
                            Console.WriteLine("\nGecersiz miktar girildi. Stok guncellenemedi.");
                        }
                    }
                    else
                    {
                        if (mevcutIlacCesidi < 100)
                        {
                            Console.Write("Ilac Stok Miktarini Girin: ");
                            int yeniStok;
                            bool stokGecerli = int.TryParse(Console.ReadLine(), out yeniStok);

                            Console.Write("Ilac Birim Fiyatini Girin (Orn: 45,50): ");
                            double yeniFiyat;
                            bool fiyatGecerli = double.TryParse(Console.ReadLine(), out yeniFiyat);

                            if (stokGecerli && fiyatGecerli && yeniStok >= 0 && yeniFiyat > 0)
                            {
                                ilacAdlari[mevcutIlacCesidi] = girilenAd;
                                ilacStoklari[mevcutIlacCesidi] = yeniStok;
                                ilacFiyatlari[mevcutIlacCesidi] = yeniFiyat;
                                mevcutIlacCesidi++;
                                Console.WriteLine("\nYeni ilac basariyla sisteme kaydedildi.");
                            }
                            else
                            {
                                Console.WriteLine("\nGecersiz stok veya fiyat girisi yapildi. Kayit basarisiz.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nOtomasyon hafizasi dolu! Daha fazla farkli ilac eklenemez.");
                        }
                    }

                    Console.WriteLine("\nAna menuye donmek icin ENTER'a basin...");
                    Console.ReadLine();
                }
                else if (anaSecim == "3")
                {
                    Console.Clear();
                    Console.WriteLine("=== ILAC SATIS EKRANI ===");
                    Console.Write("Satisi yapilacak ilacın adini girin: ");
                    string satisAd = Console.ReadLine();

                    int satisIndeks = -1;
                    for (int i = 0; i < mevcutIlacCesidi; i++)
                    {
                        if (ilacAdlari[i].ToLower() == satisAd.ToLower())
                        {
                            satisIndeks = i;
                            break;
                        }
                    }

                    if (satisIndeks != -1)
                    {
                        Console.WriteLine($"Ilac Bulundu: {ilacAdlari[satisIndeks]} | Stok Durumu: {ilacStoklari[satisIndeks]} | Birim Fiyat: {ilacFiyatlari[satisIndeks]:C2}");
                        Console.Write("Kac adet satilacak: ");
                        int satilacakAdet;

                        if (int.TryParse(Console.ReadLine(), out satilacakAdet) && satilacakAdet > 0)
                        {
                            if (ilacStoklari[satisIndeks] >= satilacakAdet)
                            {
                                ilacStoklari[satisIndeks] -= satilacakAdet;
                                double toplamTutar = satilacakAdet * ilacFiyatlari[satisIndeks];

                                satisIlacAdlari[toplamSatisIslemiSayisi] = ilacAdlari[satisIndeks];
                                satisAdetleri[toplamSatisIslemiSayisi] = satilacakAdet;
                                satisGelirleri[toplamSatisIslemiSayisi] = toplamTutar;
                                toplamSatisIslemiSayisi++;

                                Console.WriteLine("\nSatis islemi basarili!");
                                Console.WriteLine($"Tahsil Edilen Tutar: {toplamTutar:C2}");
                                Console.WriteLine($"Kalan Stok: {ilacStoklari[satisIndeks]}");
                            }
                            else
                            {
                                Console.WriteLine("\nYetersiz stok! Satis islemi gerceklestirilemedi.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nGecersiz adet girildi.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nGirilen isimde bir ilac eczane envanterinde bulunamadi.");
                    }

                    Console.WriteLine("\nAna menuye donmek icin ENTER'a basin...");
                    Console.ReadLine();
                }
                else if (anaSecim == "4")
                {
                    Console.Clear();
                    Console.WriteLine("==================================================");
                    Console.WriteLine("          ECZANE DETAYLI RAPORLAMA MODULU         ");
                    Console.WriteLine("==================================================");

                    double toplamCiro = 0;
                    int toplamSatilanKutuSayisi = 0;
                    for (int i = 0; i < toplamSatisIslemiSayisi; i++)
                    {
                        toplamCiro += satisGelirleri[i];
                        toplamSatilanKutuSayisi += satisAdetleri[i];
                    }

                    Console.WriteLine($"Toplam Yapilan Satis Islemi : {toplamSatisIslemiSayisi} adet");
                    Console.WriteLine($"Toplam Satilan Ilac Kutusu  : {toplamSatilanKutuSayisi} adet");
                    Console.WriteLine($"Sistemdeki Toplam Ciro      : {toplamCiro:C2}");
                    Console.WriteLine("--------------------------------------------------");

                    Console.WriteLine("KRITIK STOK SEVIYESINDEKI ILACLAR (Stok < 5):");
                    bool kritikDurumVarMi = false;
                    for (int i = 0; i < mevcutIlacCesidi; i++)
                    {
                        if (ilacStoklari[i] < 5)
                        {
                            Console.WriteLine($"- {ilacAdlari[i]} (Kalan Stok: {ilacStoklari[i]})");
                            kritikDurumVarMi = true;
                        }
                    }
                    if (!kritikDurumVarMi) Console.WriteLine("Sistemde kritik stokta urun bulunmamaktadir.");
                    Console.WriteLine("--------------------------------------------------");

                    Console.WriteLine("ILAC BAZLI TOPLAM SATIS RAPORLARI:");
                    if (toplamSatisIslemiSayisi > 0)
                    {
                        for (int i = 0; i < mevcutIlacCesidi; i++)
                        {
                            int ilacToplamSatisi = 0;
                            double ilacToplamGeliri = 0;

                            for (int j = 0; j < toplamSatisIslemiSayisi; j++)
                            {
                                if (satisIlacAdlari[j] == ilacAdlari[i])
                                {
                                    ilacToplamSatisi += satisAdetleri[j];
                                    ilacToplamGeliri += satisGelirleri[j];
                                }
                            }

                            if (ilacToplamSatisi > 0)
                            {
                                Console.WriteLine($"- {ilacAdlari[i]}: Toplam {ilacToplamSatisi} adet satildi, {ilacToplamGeliri:C2} gelir getirdi.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Henuz hic satis yapilmadigi icin veri uretilemedi.");
                    }
                    Console.WriteLine("==================================================");

                    Console.WriteLine("\nAna menuye donmek icin ENTER'a basin...");
                    Console.ReadLine();
                }
                else if (anaSecim == "5")
                {
                    sistemCalisiyor = false;
                    Console.Clear();
                    Console.WriteLine("Eczane Otomasyon Sisteminden cikiliyor. Iyi gunler dileriz.");
                }
            }

            Console.WriteLine("\nKapatmak icin bir tusa basin...");
            Console.ReadKey();
        }
    }
}