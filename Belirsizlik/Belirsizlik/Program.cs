using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belirsizlik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //tanımlama kısmı
            int satir, sutun;
            double iyimserlikkatsayisi;
            Console.Write("Lütfen alternatiflerinizin adedini giriniz: ");
            satir = Convert.ToInt32(Console.ReadLine());
            Console.Write("Lütfen doğal durumlarınız adedini giriniz: ");
            sutun = Convert.ToInt32(Console.ReadLine());
            string[] alternatifadi = new string[satir];
            for (int i = 0; i < satir; i++)
            {
                Console.Write("Lütfen {0}. alternatifinizin adını giriniz: ", i + 1);
                string ad = Console.ReadLine();
                alternatifadi[i] = ad;
            }
            Console.Write("Lütfen iyimserlik katsayınızın değerini giriniz:");
            iyimserlikkatsayisi = Convert.ToDouble(Console.ReadLine());
            double eksiiyimserlik = 1 - iyimserlikkatsayisi;
            Console.Write("1-iyimserlik değeriniz:" + eksiiyimserlik);
            Console.WriteLine();
            if (iyimserlikkatsayisi >= 0 && iyimserlikkatsayisi <= 1)
            {
                Console.Write("Sorusunuz maliyet yapılı ise m,getir yapılı ise g harfini giriniz:");
                string sorutipi = Console.ReadLine();
                if (sorutipi == "g")
                {
                    //getir yapılı kısmı
                    int[,] matris = new int[satir, sutun];
                    //veri alma kısmı
                    for (int i = 0; i < satir; i++)
                    {
                        for (int j = 0; j < sutun; j++)
                        {
                            //aşağıd 0 satır 1 sütün
                            Console.Write(" {0}.alternatifinizin, {1}.doğal durum değerini giriniz: ", i + 1, j + 1);
                            matris[i, j] = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    Console.WriteLine();
                    //yazdırma kısmı
                    Console.WriteLine("Matrisiniz:");
                    for (int k = 0; k < satir; k++)
                    {
                        {
                            for (int n = 0; n < sutun; n++)
                            {
                                Console.Write(matris[k, n] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    //iyimserlik ölçütü
                    Console.WriteLine("İyimserlik ölçütü için işlemler:");
                    //satirların en büyüğünü bulma
                    int[] buyukler = new int[satir];
                    for (int i = 0; i < satir; i++)
                    {
                        for (int j = 0; j < sutun; j++)
                        {
                            if (buyukler[i] <= matris[i, j])
                            {
                                buyukler[i] = matris[i, j];

                            }
                        }
                    }
                    //satirların en büyüğünü ekrana yazdırma
                    Console.WriteLine("Her bir satırın en büyük değerleri aşağıda gözüktüğü gibidir:");
                    for (int i = 0; i < buyukler.Length; i++)
                    {
                        Console.Write(buyukler[i]);
                        Console.WriteLine();
                    }

                    //maxın maxı kısmı
                    int index = 0;
                    int enbuyuk = buyukler[0];
                    for (int i = 0; i < buyukler.Length; i++)
                    {
                        if (enbuyuk < buyukler[i])
                        {
                            enbuyuk = buyukler[i];
                            index = i;
                        }

                    }
                    Console.WriteLine("İyimserlik ölçütüne göre seçmeniz gereken değer:" + enbuyuk);
                    Console.WriteLine("İyimserlik ölçütüne göre KARAR:{0}", alternatifadi[index]);
                    Console.WriteLine();
                    Console.WriteLine("Kötümserlik ölçütü için işlemler:");
                    //satırların en düşüğünü bulma
                    int[] kucukler = new int[satir];
                    for (int i = 0; i < satir; i++)
                    {
                        int min = matris[i, 0];
                        for (int j = 0; j < sutun; j++)
                        {

                            if (min > matris[i, j])
                            {
                                min = matris[i, j];
                            }
                        }
                        kucukler[i] = min;
                    }
                    //satırların en düşüğünü ekrana yazdırma
                    Console.WriteLine("Her bir satırın en küçük değeri aşağıda gözüktüğü gibidir:");
                    for (int i = 0; i < kucukler.Length; i++)
                    {
                        Console.Write(kucukler[i]);
                        Console.WriteLine();
                    }
                    //en düşüüklerin en yükseklerini alma 
                    //kötümserlik
                    index = 0;
                    int minmax = kucukler[0];
                    for (int i = 0; i < kucukler.Length; i++)
                    {
                        if (minmax < kucukler[i])
                        {
                            minmax = kucukler[i];
                            index = i;
                        }
                    }
                    Console.WriteLine("Kötümserlik ölçütüne göre seçmeniz gereken değer:" + minmax);
                    Console.WriteLine("Kötümserlik ölçütüne göre KARAR:{0}", alternatifadi[index]);
                    Console.WriteLine();
                    Console.WriteLine("Eş olasılık ölçütü için işlemler:");
                    //eş olasılık
                    //sutun*satırlardaki degerler
                    double[] satirtoplamlari = new double[satir];
                    for (int i = 0; i < satir; i++)
                    {
                        double satirtoplam = 0;

                        for (int j = 0; j < sutun; j++)
                        {
                            satirtoplam += matris[i, j];
                            satirtoplamlari[i] = satirtoplam;

                        }
                    }
                    Console.WriteLine("Her bir satırın toplamı:");
                    ///satirtoplamlarını ekrana yazdırma
                    for (int i = 0; i < satirtoplamlari.Length; i++)
                    {
                        Console.Write(satirtoplamlari[i]);
                        Console.WriteLine();
                    }
                    //satirtoplamlarını doğal durumların sayısına bölme ve yeni bir diziye aktarma
                    double[] esolasılık = new double[satir];
                    for (int i = 0; i < satirtoplamlari.Length; i++)
                    {
                        double bolunmushali = satirtoplamlari[i] / sutun;
                        esolasılık[i] = bolunmushali;
                    }
                    Console.WriteLine("Satır toplamlarının doğal durumların sayısına bölünmüş halleri aşağıda gözüktüğü gibidir:");
                    //bölünmüş hsllerini ekrana yazdırma
                    for (int i = 0; i < satirtoplamlari.Length; i++)
                    {
                        Console.Write(esolasılık[i]);
                        Console.WriteLine();
                    }

                    //bölüneenlerin en büyüğünü bulma ve ekrana yazdırma eş olasılık
                    index = 0;
                    double esolasılıktaenbuyuk = esolasılık[0];
                    for (int i = 0; i < esolasılık.Length; i++)
                    {
                        if (esolasılıktaenbuyuk < esolasılık[i])
                        {
                            esolasılıktaenbuyuk = esolasılık[i];
                            index = i;
                        }

                    }
                    Console.WriteLine("Eş olasılık ölçütüne göre seçmeniz gereken değer:" + esolasılıktaenbuyuk);
                    Console.WriteLine("Eş olasılık ölçütüne göre KARAR:{0}", alternatifadi[index]);

                    Console.WriteLine();
                    //hurwics ölçütü
                    //satırların en büyükleri ve en kucukleri
                    Console.WriteLine("Hurwicz ölçütü için işlemler:");
                    double[] hurwics1 = new double[satir];
                    double iyimser = 0;
                    for (int i = 0; i < buyukler.Length; i++)
                    {
                        iyimser = iyimserlikkatsayisi * buyukler[i];
                        hurwics1[i] = iyimser;

                    }
                    /*
                    for (int i = 0; i < hurwics1.Length; i++)
                    {
                        Console.WriteLine("buyulerin çarppım sonucçları");
                        Console.Write(hurwics1[i]);
                        Console.WriteLine();
                    }
                    */

                    double[] hurwics2 = new double[satir];
                    double iyimsereksi = 0;
                    for (int i = 0; i < kucukler.Length; i++)
                    {
                        iyimsereksi = eksiiyimserlik * kucukler[i];
                        hurwics2[i] = iyimsereksi;
                    }
                    /*
                    for (int i = 0; i < hurwics1.Length; i++)
                    {
                        Console.WriteLine("kucuklerin çarppım sonucçları");
                        Console.Write(hurwics2[i]);
                        Console.WriteLine();
                    }*/

                    double[] hurwics3 = new double[satir];

                    for (int i = 0; i < buyukler.Length; i++)
                    {
                        hurwics3[i] = hurwics1[i] + hurwics2[i];
                    }
                    //her satır için çarpım sonuçları
                    Console.WriteLine("Her satırın iyimserlik katsayısı ve 1-iyimserlik katsayısı işleminden sonraki toplanmış" +
                        "halleri aşağıda gözüktüğü gibidir:");
                    for (int i = 0; i < hurwics3.Length; i++)
                    {
                        Console.Write(hurwics3[i]);
                        Console.WriteLine();
                    }
                   index = 0;
                    double enbuyuk2 = hurwics3[0];
                    for (int i = 0; i < hurwics3.Length; i++)
                    {
                        if (enbuyuk2 < hurwics3[i])
                        {
                            enbuyuk2 = hurwics3[i];
                            index = i;
                        }
                    }
                    Console.WriteLine("Hurwicz ölçütüne göre seçmeniz gereken değer:" + enbuyuk2);
                    Console.WriteLine("Hurwicz ölçütüne göre KARAR:{0}", alternatifadi[index]);
                    Console.WriteLine();
                    Console.WriteLine("Pişmanlık ölçütü için işlemler:");

                    //Pişmanlık ölçütü  
                    //matrisin transpouzunu alma
                    int[,] tersmatris = new int[sutun, satir];
                    for (int i = 0; i < satir; i++)
                    {
                        for (int j = 0; j < sutun; j++)
                        {
                            tersmatris[j, i] = matris[i, j];
                        }
                    }
                    Console.WriteLine("Transpozu alınmış matris:");
                    //transpozunu aldığım mmatrisi ekrana yazdırma
                    for (int i = 0; i < sutun; i++)
                    {
                        for (int j = 0; j < satir; j++)
                        {
                            Console.Write(tersmatris[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    //satirların en büyüğünü bulma
                    int[] tersbuyukler = new int[sutun];
                    for (int i = 0; i < sutun; i++)
                    {
                        for (int j = 0; j < satir; j++)
                        {
                            if (tersbuyukler[i] <= tersmatris[i, j])
                            {
                                tersbuyukler[i] = tersmatris[i, j];
                            }
                        }
                    }
                    //satirların en büyüğünü ekrana yazdırma
                    Console.WriteLine("Her bir satırın en büyüğü aşağıda gözüktüğü gibidir:");
                    for (int i = 0; i < tersbuyukler.Length; i++)
                    {
                        Console.Write(tersbuyukler[i]);
                        Console.WriteLine();
                    }

                    //satirların en büyüğünü her birinden çıkartma
                    int[,] pismanlikmatrisi = new int[sutun, satir];
                    for (int i = 0; i < sutun; i++)
                    {
                        for (int j = 0; j < satir; j++)
                        {
                            pismanlikmatrisi[i, j] = tersbuyukler[i] - tersmatris[i, j];
                        }
                    }
                    //pişmanlık tablosunu ekrana yazdirma
                    Console.WriteLine("Pişmanlık tablosu:");
                    for (int i = 0; i < sutun; i++)
                    {
                        for (int j = 0; j < satir; j++)
                        {
                            Console.Write(pismanlikmatrisi[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    //pişmanlık matrisinin tersini alma

                    int[,] tersmatris2 = new int[satir, sutun];
                    for (int i = 0; i < sutun; i++)
                    {
                        for (int j = 0; j < satir; j++)
                        {
                            tersmatris2[j, i] = pismanlikmatrisi[i, j];
                        }
                    }
                    //transpozunu aldığım mmatrisi ekrana yazdırma
                    Console.WriteLine("pişmanlık matrisinin transpozu:");
                    for (int i = 0; i < satir; i++)
                    {
                        for (int j = 0; j < sutun; j++)
                        {
                            Console.Write(tersmatris2[i, j] + " ");
                        }
                        Console.WriteLine();
                    }


                    //pişmanlık tablosunda satirların en büyüğünü alma

                    int[] pismanlikbuyukler = new int[satir];
                    for (int i = 0; i < satir; i++)
                    {
                        for (int j = 0; j < sutun; j++)
                        {
                            if (pismanlikbuyukler[i] <= tersmatris2[i, j])
                            {
                                pismanlikbuyukler[i] = tersmatris2[i, j];
                            }
                        }
                    }
                    Console.WriteLine("Pişmanlık matrisinin her bir satırının en büyükleri aşağıda gözüktüğü gibidir:");
                    //pişmanlık tablosunun en büyüklerinii ekrana yazdırma
                    for (int i = 0; i < pismanlikbuyukler.Length; i++)
                    {
                        Console.Write(pismanlikbuyukler[i]);
                        Console.WriteLine();
                    }
                    //en küçüğü bulma
                    index = 0;
                    int pismanlikenkucuk = pismanlikbuyukler[0];
                    for (int i = 0; i < pismanlikbuyukler.Length; i++)
                    {
                        if (pismanlikbuyukler[i] < pismanlikenkucuk)
                        {
                            pismanlikenkucuk = pismanlikbuyukler[i];
                            index = i;
                        }

                    }
                    Console.WriteLine("Pişmanlık ölçütüne göre seçmeniz gereken değer:" + pismanlikenkucuk);
                    Console.WriteLine("Pişmanlık ölçütüne göre KARAR:{0}", alternatifadi[index]);
                    Console.ReadLine();
                }
                else
                {
                    int index= 0;
                    //////////////////////////////////////////
                    //maliyet yapılı kısmı
                    int[,] matris = new int[satir, sutun];
                    //veri alma kısmı
                    for (int i = 0; i < satir; i++)
                    {
                        for (int j = 0; j < sutun; j++)
                        {
                            //aşağıd 0 satır 1 sütün
                            Console.Write(" {0}.alternatifinizin, {1}.doğal durum değerini giriniz: ", i + 1, j + 1);
                            matris[i, j] = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    Console.WriteLine();
                    //yazdırma kısmı
                    Console.WriteLine("Matrisiniz:");
                    for (int k = 0; k < satir; k++)
                    {
                        {
                            for (int n = 0; n < sutun; n++)
                            {
                                Console.Write(matris[k, n] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                    //iyimserlik
                    //satırların en küçügünü bulma
                    Console.WriteLine("İyimserlik ölçütü için işlemler:");
                    int[] kucukler = new int[satir];
                    for (int i = 0; i < satir; i++)
                    {
                        int min = matris[i, 0];
                        for (int j = 0; j < sutun; j++)
                        {

                            if (min > matris[i, j])
                            {
                                min = matris[i, j];
                            }
                        }
                        kucukler[i] = min;
                    }
                    Console.WriteLine("Her bir satırın en küçük değeri aşağıda gözüktüğü gibidir:");
                    //satırların en küçüğünü ekrana yazdırma
                    for (int i = 0; i < kucukler.Length; i++)
                    {
                        Console.Write(kucukler[i]);
                        Console.WriteLine();
                    }
                    index= 0;
                    //küçüklerin küçügünü bulma kısmı
                    int minmin = kucukler[0];
                    for (int i = 0; i < kucukler.Length; i++)
                    {
                        if (minmin > kucukler[i])
                        {
                            minmin = kucukler[i];
                            index = i;
                        }

                    }
                    Console.WriteLine("iyimserlik ölçütüne göre seçmeniz gereken değer:" + minmin);
                    Console.WriteLine("İyimserlik ölçütüne göre KARAR:{0}", alternatifadi[index]);

                    Console.WriteLine();
                    //satırların büyüklerini bulma
                    //Kötümserlik kısmı
                    Console.WriteLine("Kötümserlik ölçütü için işlemler:");
                    int[] buyukler = new int[satir];
                    for (int i = 0; i < satir; i++)
                    {
                        for (int j = 0; j < sutun; j++)
                        {
                            if (buyukler[i] <= matris[i, j])
                            {
                                buyukler[i] = matris[i, j];
                            }
                        }
                    }
                    Console.WriteLine("Her bir satırın en büyük değeri aşağıda gözüktüğü gibidir:");
                    for (int i = 0; i < buyukler.Length; i++)
                    {
                        Console.Write(buyukler[i]);
                        Console.WriteLine();
                    }
                    index =0;
                    //büyüklerin en küçügünü bulma
                    int maxmin = buyukler[0];
                    for (int i = 0; i < buyukler.Length; i++)
                    {
                        if (maxmin > buyukler[i])
                        {
                            maxmin = buyukler[i];
                            index = i;
                        }

                    }
                    Console.WriteLine("Kötümserlik ölçütüne göre seçmeniz gereken değer:" + maxmin);
                    Console.WriteLine("Kötümserlik ölçütüne göre KARAR:{0}", alternatifadi[index]);

                    Console.WriteLine();
                    // eş olasılık
                    Console.WriteLine("Eş olasılık ölçütü için işlemler:");
                    double[] satirtoplamlari = new double[satir];
                    for (int i = 0; i < satir; i++)
                    {
                        double satirtoplam = 0;

                        for (int j = 0; j < sutun; j++)

                        {
                            satirtoplam += matris[i, j];
                            satirtoplamlari[i] = satirtoplam;

                        }
                    }
                    Console.WriteLine("Her bir satırın kendi arasındaki toplamları:");
                    ///satirtoplamlarını ekrana yazdırma
                    for (int i = 0; i < satirtoplamlari.Length; i++)
                    {
                        Console.Write(satirtoplamlari[i]);
                        Console.WriteLine();
                    }
                    //satirtoplamlarını doğal durumların sayısına bölme ve yeni bir diziye aktarma
                    double[] esolasılık = new double[satir];
                    for (int i = 0; i < satirtoplamlari.Length; i++)
                    {
                        double bolunmushali = satirtoplamlari[i] / sutun;
                        esolasılık[i] = bolunmushali;
                    }
                    Console.WriteLine("Satır toplamlarının doğal durumların sayısına bölünmüş hallleri:");
                    //bölünmüş hallerini ekrana yazdırma
                    for (int i = 0; i < satirtoplamlari.Length; i++)
                    {
                        Console.Write(esolasılık[i]);
                        Console.WriteLine();
                    }
                    index =0;
                    //eş olasılık için en küçüğünü bulma
                    double esolasılıktaenkucuk = esolasılık[0];
                    for (int i = 0; i < esolasılık.Length; i++)
                    {
                        if (esolasılıktaenkucuk > esolasılık[i])
                        {
                            esolasılıktaenkucuk = esolasılık[i];
                            index = i;
                        }

                    }
                    Console.WriteLine("Eş olasılık ölçütüne göre seçmeniz gereken değer:" + esolasılıktaenkucuk);
                    Console.WriteLine("Eş olasılık ölçütüne göre KARAR:{0}", alternatifadi[index]);
                    //hurwics
                    Console.WriteLine();
                    Console.WriteLine("Hurwicz ölçütü için işlemler:");
                    //satırların en büyükleri ve en kucukleri
                    double[] hurwics1 = new double[satir];
                    double iyimser = 0;
                    for (int i = 0; i < buyukler.Length; i++)
                    {
                        iyimser = eksiiyimserlik * buyukler[i];
                        hurwics1[i] = iyimser;
                    }
                    /*
                    for (int i = 0; i < hurwics1.Length; i++)
                    {
                        Console.WriteLine("buyukerin çarpım sonuçları ");
                        Console.Write(hurwics1[i]);
                        Console.WriteLine();
                    }*/
                    double[] hurwics2 = new double[satir];
                    double iyimsereksi = 0;
                    for (int i = 0; i < kucukler.Length; i++)
                    {
                        iyimsereksi = iyimserlikkatsayisi * kucukler[i];
                        hurwics2[i] = iyimsereksi;
                    }
                    /*
                    for (int i = 0; i < hurwics1.Length; i++)
                    {
                        Console.WriteLine("kucuklerin çarpım sonuçları");
                        Console.Write(hurwics2[i]);
                        Console.WriteLine();
                    }
                    */
                    double[] hurwics3 = new double[satir];

                    for (int i = 0; i < buyukler.Length; i++)
                    {
                        hurwics3[i] = hurwics1[i] + hurwics2[i];
                    }
                    //her satır için çarpım sonuçları
                    Console.WriteLine("Her satırın iyimserlik katsayısı ve 1-iyimserlik katsayısı işleminden sonraki toplanmış " +
 "halleri aşağıda gözüktüğü gibidir:");
                    for (int i = 0; i < hurwics3.Length; i++)
                    {
                        Console.Write(hurwics3[i]);
                        Console.WriteLine();
                    }
                    index = 0;
                    double enkucuk2 = hurwics3[0];
                    for (int i = 0; i < hurwics3.Length; i++)
                    {
                        if (enkucuk2 > hurwics3[i])
                        {
                            enkucuk2 = hurwics3[i];
                            index = i;
                        }

                    }
                    Console.WriteLine("Hurwicz ölçütüne göre seçmeniz gereken değer:" + enkucuk2);
                    Console.WriteLine("Hurwicz ölçütüne göre KARAR:{0}", alternatifadi[index]);
                    Console.WriteLine();
                    Console.WriteLine("Pişmanlık ölçütü için işlemler:");

                    //Pişmanlık ölçütü
                    //matrisin transpozunu alma
                    int[,] tersmatris = new int[sutun, satir];
                    for (int i = 0; i < satir; i++)
                    {
                        for (int j = 0; j < sutun; j++)
                        {
                            tersmatris[j, i] = matris[i, j];
                        }
                    }
                    Console.WriteLine("Transpozu alınmış matris:");
                    //transpozunu aldığım mmatrisi ekrana yazdırma
                    for (int i = 0; i < sutun; i++)
                    {
                        for (int j = 0; j < satir; j++)
                        {
                            Console.Write(tersmatris[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    //satirların en küçüğünü bulma
                    int[] terskucukler = new int[sutun];
                    for (int i = 0; i < sutun; i++)
                    {
                        int min = matris[i, 0];
                        for (int j = 0; j < satir; j++)
                        {
                            if (min > tersmatris[i, j])
                            {
                                min = tersmatris[i, j];
                            }
                        }
                        terskucukler[i] = min;
                    }
                    //satirların en küçüğünü ekrana yazdırma
                    Console.WriteLine("Her bir satırın en küçüğü aşağıda gözüktüğü gibidir:");
                    for (int i = 0; i < terskucukler.Length; i++)
                    {
                        Console.Write(terskucukler[i]);
                        Console.WriteLine();
                    }
                    //satirların en küçüğünü her birinden çıkartma
                    int[,] pismanlikmatrisi = new int[sutun, satir];
                    for (int i = 0; i < sutun; i++)
                    {
                        for (int j = 0; j < satir; j++)
                        {
                            pismanlikmatrisi[i, j] = tersmatris[i, j] - terskucukler[i];
                        }
                    }
                    //pişmanlık tablosunu ekrana yazdirma
                    Console.WriteLine("Pişmanlık tablosu:");
                    for (int i = 0; i < sutun; i++)
                    {
                        for (int j = 0; j < satir; j++)
                        {
                            Console.Write(pismanlikmatrisi[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    //pişmanlık matrisinin tersini alma
                    int[,] tersmatris2 = new int[satir, sutun];
                    for (int i = 0; i < sutun; i++)
                    {
                        for (int j = 0; j < satir; j++)
                        {
                            tersmatris2[j, i] = pismanlikmatrisi[i, j];
                        }
                    }
                    //transpozunu aldığım mmatrisi ekrana yazdırma
                    Console.WriteLine("Pişmanlık matrisinin transpozu:");
                    for (int i = 0; i < satir; i++)
                    {
                        for (int j = 0; j < sutun; j++)
                        {
                            Console.Write(tersmatris2[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    //pişmanlık tablosunda satirların en büyüğünü alma

                    int[] pismanlikbuyukler = new int[satir];
                    for (int i = 0; i < satir; i++)
                    {
                        for (int j = 0; j < sutun; j++)
                        {
                            if (pismanlikbuyukler[i] <= tersmatris2[i, j])
                            {
                                pismanlikbuyukler[i] = tersmatris2[i, j];
                            }
                        }
                    }
                    Console.WriteLine("Pişmanlık matrisinin her bir satırının en büyükleri aşağıda gözüktüğü gibidir:");
                    //pişmanlık tablosunun en büyüklerinii ekrana yazdırma
                    for (int i = 0; i < pismanlikbuyukler.Length; i++)
                    {
                        Console.Write(pismanlikbuyukler[i]);
                        Console.WriteLine();
                    }
                    index = 0;
                    //en küçüğü bulma
                    int pismanlikenkucuk = pismanlikbuyukler[0];
                    for (int i = 0; i < pismanlikbuyukler.Length; i++)
                    {
                        if (pismanlikbuyukler[i] < pismanlikenkucuk)
                        {
                            pismanlikenkucuk = pismanlikbuyukler[i];
                            index = i;
                        }

                    }
                    Console.WriteLine("Pişmanlık ölçütüne göre seçmeniz gereken değer:" + pismanlikenkucuk);
                    Console.WriteLine("Pişmanlık ölçütüne göre KARAR:{0}", alternatifadi[index]);
                    Console.ReadLine();
                }
            }
            //iyimserlik katsayısının elsesi
            else
            {
                Console.WriteLine("Lütfen iyimserlik katsayısını 0 ve 1 aralığında bir değer olarak giriniz.");
            }
                Console.ReadLine();
            }


        }
    }



