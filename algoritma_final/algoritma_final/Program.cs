using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace algoritma_final
{
    class Program
    {
        public static void dosyayaYaz(string[] veri)
        {
            string dosya_yolu = @"asiListesi.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < veri.Length; i++)
            {
                sw.WriteLine(veri[i]);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public static string numaraAyirici(string gelen)
        {
            string no = "";
            for (int i = 0; i < gelen.Length; i++)
            {
                if (gelen[i] == ',')
                {
                    break;
                }
                if (gelen[i] != ',')
                {
                    no += gelen[i];
                }
            }
            return no;
        }
        public static string isimAyirici(string gelen)
        {
            string isim = "";
            int sayac = 0;
            for (int i = 0; i < gelen.Length; i++)
            {
                if (gelen[i] == ',')
                {
                    sayac++;
                }
                if (sayac == 1)
                {
                    for (int j = i + 1; j < gelen.Length; j++)
                    {
                        if (gelen[j] != ',')
                        {
                            isim += gelen[j];
                        }
                        if (gelen[j] == ',')
                        {
                            break;
                        }

                    }
                    sayac++;
                }
            }

            return isim;
        }

        public static string asiAyirici(string gelen)
        {
            string asi = "";
            int sayac = 0;

            for (int i = 0; i < gelen.Length; i++)
            {
                if (gelen[i] == ',')
                {
                    sayac++;
                    if (sayac == 2)
                    {
                        for (int j = i + 1; j < gelen.Length; j++)
                        {
                            if (gelen[j] != ',')
                            {
                                asi += gelen[j];

                            }
                            if (gelen[j] == ',')
                            {
                                break;
                            }

                        }
                    }
                }
            }

            return asi;
        }
        public static string tarihAyirici(string gelen)
        {
            string tarih = "";
            for (int i = 0; i < gelen.Length; i++)
            {
                if (gelen[i] == ',')
                {
                    for (int j = i + 1; j < gelen.Length; j++)
                    {
                        if (gelen[j] == ',')
                        {

                            for (int k = j + 1; k < gelen.Length; k++)
                            {

                                if (gelen[k] == ',')
                                {
                                    for (int p = k + 1; p < gelen.Length; p++)
                                    {
                                        if (gelen[p] != ',')
                                        {
                                            tarih += gelen[p];

                                        }
                                        if (gelen[p] == ',')
                                        {
                                            break;
                                        }
                                    }

                                }


                            }

                        }
                    }

                }
            }

            return tarih;
        }
        public static int dosyaSatirSayisi()
        {
            string dosya_yolu = @"asiListesi.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            int sayac = 0;
            StreamReader sw = new StreamReader(fs);

            string yazi = sw.ReadLine();
            while (yazi != null)
            {

                sayac++;
                yazi = sw.ReadLine();
            }

            sw.Close();
            fs.Close();
            return sayac;
        }
        public static string[] dizidenDosyayaYaz(String[] dizim)
        {
            string dosya_yolu = @"asiListesi.txt";

            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            int sayac = 0;
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            while (yazi != null)
            {
                dizim[sayac] = yazi;
                sayac++;
                yazi = sw.ReadLine();
            }

            sw.Close();
            fs.Close();
            return dizim;

        }
        public static string[] diziyeYaz(string[] dizi, int indis, string deger)
        {

            for (int i = dizi.Length - 1; i >= indis; i--)

            {



                dizi[i] = dizi[i - 1];



            }
            dizi[indis] = deger;


            return dizi;

        }
        public static void ranevusuOlanlar(string[] dizi)
        {
            int sayac = 0;
            int sirano = 1;
            Console.WriteLine("Sıra No           Öğrenci Numarası             Adı Soyadı           Aşı Firması           Tarih");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < dizi.Length; i++)
            {
                string satır = dizi[i];
                for (int j = 0; j < satır.Length; j++)
                {
                    if (satır[j] == ',')
                    {
                        sayac++;
                    }
                }
                if (sayac > 2)
                {

                    Console.WriteLine(sirano + "                  " + numaraAyirici(satır) + "               " + isimAyirici(satır) + "             " + asiAyirici(satır) + "          " + tarihAyirici(satır));
                    sirano++;

                }
                sayac = 0;
            }




        }

        static void Main(string[] args)
        {


            do
            {
                Console.WriteLine("              MENÜ                ");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Yeni kayıt eklemek için          1:");
                Console.WriteLine("Randevu almak için               2:");
                Console.WriteLine("Randevuları Listelemek için      3:");
                Console.WriteLine("Çıkış için                       0: \n");
                Console.WriteLine("LÜTFEN SEÇİMİNİZİ GİRİNİZ         : ");
                int secim = int.Parse(Console.ReadLine());
                string[] kayitlistesi = new string[dosyaSatirSayisi()];
                kayitlistesi = dizidenDosyayaYaz(kayitlistesi);
                if (secim == 1)
                {

                    Console.WriteLine("Öğrenci numarası :");
                    string ogrencino = Console.ReadLine();
                    Console.WriteLine("Öğrenci adı :");
                    string ogrenciadi = Console.ReadLine();
                    string yenikayit = ogrencino + "," + ogrenciadi + ",";
                    for (int i = 0; i < kayitlistesi.Length; i++)
                    {
                        Console.WriteLine(kayitlistesi[i]);
                    }
                    for (int i = 0; i < kayitlistesi.Length; i++)
                    {
                        string gelen = numaraAyirici(kayitlistesi[i]);
                        if (int.Parse(gelen) > int.Parse(ogrencino))
                        {
                            Console.WriteLine("yazılacak yer " + (i + 1));
                            kayitlistesi = diziyeYaz(kayitlistesi, i, yenikayit);
                            break;
                        }

                    }
                    dosyayaYaz(kayitlistesi);


                }
                else if (secim == 2)
                {
                    Console.WriteLine("Öğrenci numarası :");
                    int ogrencino = int.Parse(Console.ReadLine());
                    for (int i = 0; i < kayitlistesi.Length; i++)
                    {
                        string gelen2 = numaraAyirici(kayitlistesi[i]);
                        if (int.Parse(gelen2) == ogrencino)
                        {
                            Console.WriteLine(isimAyirici(kayitlistesi[i]) + ":");
                            Console.WriteLine("  AŞI TERCİHİ \n ----------------- \n Biontech : 1 \n sinovac : 2 \n Sputnik : 3");

                            int tercih = int.Parse(Console.ReadLine());
                            Console.WriteLine("Lütfen aşı tarihini giriniz:");
                            string tarih = Console.ReadLine();

                            if (tercih == 1)
                            {
                                kayitlistesi[i] = kayitlistesi[i] + " Biontech ," + tarih + ",";
                                dosyayaYaz(kayitlistesi);
                            }
                            else if (tercih == 2)
                            {
                                kayitlistesi[i] = kayitlistesi[i] + " sinovac ," + tarih + ",";
                                dosyayaYaz(kayitlistesi);
                            }
                            else if (tercih == 3)
                            {
                                kayitlistesi[i] = kayitlistesi[i] + " Sputnik ," + tarih + ",";
                                dosyayaYaz(kayitlistesi);
                            }

                        }


                    }

                }
                else if (secim == 3)
                {
                    ranevusuOlanlar(kayitlistesi);
                }
                else if (secim == 0)
                {
                    break;

                }

            } while (true);

        }
    }
}
