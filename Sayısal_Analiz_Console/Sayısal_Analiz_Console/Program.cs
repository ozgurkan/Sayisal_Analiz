using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sayısal_Analiz_Console
{
    class Program
    {

        static int DenklemDerecesi, i = 0; 
        static double[] dizi = new double[100];
        static double[] diziTurev = new double[100]; 
        
        static Double power(Double taban, Double us)
        {
             double  sonuc = 1.0;         
             for (int i = 1; i <= us; i++)
                {
                    sonuc = sonuc * taban;
                }
            return sonuc;
        }

        static void baslangic() {
            int SecilenYontemNo;

            Console.WriteLine(" KÖK BULMA YÖNTEMLERİ ");
            Console.WriteLine("    1-)GRAFİK YÖNTEMİ");
            Console.WriteLine("    2-)YARIYA BÖLME YÖNTEMİ");
            Console.WriteLine("    3-)REGULA FALSE YÖNTEMİ");
            Console.WriteLine("    4-)NEWTON RAPHSON YÖNTEMİ");
            Console.WriteLine("\n MATRİS İŞLEMLERİ");
            Console.WriteLine("    5-)MATRİSİN İNVERSİNİN ALINMASI");
            Console.WriteLine("\n DOĞRUSAL DENKLEM TAKIMLARNIN ÇÖZÜMÜ");
            Console.WriteLine("    6-)GAUSS JORDAN ELEMİNASYON YÖNTEMİ");
            Console.WriteLine("\n NÜMERİK İNTEGRAL");
            Console.WriteLine("    7-)TRAPEZ YÖNTEMİ");
            Console.WriteLine("    8-)SİMPSON YÖNTEMİ");
            Console.WriteLine("\n NÜMERİK TÜREV");
            Console.WriteLine("    9-)İLERİ,GERİ VE MERKEZİ TÜREV");


            Console.Write("\n\n  Lütefen seçeceğiniz yöntemin numarasını giriniz:");
            SecilenYontemNo = Convert.ToInt32(Console.ReadLine());




            while (SecilenYontemNo > 9 || SecilenYontemNo < 1)
            {
                Console.WriteLine("Yanlış bir giriş yaptınız.Lütfen bir numara giriniz.");
                SecilenYontemNo = Convert.ToInt32(Console.ReadLine());
            }

            if (SecilenYontemNo == 1)
            {               
                Console.WriteLine("GRAFİK YÖNTEMİ");
                fonksiyon_alma();
                Grafik_Yöntemi();
            }
            else if (SecilenYontemNo == 2)
            {
                Console.WriteLine("YARIYA BÖLME YÖNTEMİ");
                fonksiyon_alma();
                Yariya_Bolme();
            }
            else if (SecilenYontemNo == 3)
            {
                Console.WriteLine("REGULA FALSE YÖNTEMİ");
                fonksiyon_alma();
                Regula_False();
            }
            else if (SecilenYontemNo == 4)
            { 
                Console.WriteLine("NEWTON RAPHSON YÖNTEMİ");
                fonksiyon_alma();
                Newton_Rapson();               
            }
            else if (SecilenYontemNo == 5)
            {
                Console.WriteLine("MATRİSİN İNVERSİNİN ALINMASI");
                Matrisin_Inversi();
            }
            else if (SecilenYontemNo == 6)
            {
                Console.WriteLine("GAUSS JORDAN ELEMİNASYON YÖNTEMİ");
                Gauss_Jordan_Elemination();
            }
            else if (SecilenYontemNo == 7)
            {
                Console.WriteLine("TRAPEZ YÖNTEMİ");
                fonksiyon_alma();
                Trapez_Yöntemi();
            }
            else if (SecilenYontemNo == 8)
            {
                Console.WriteLine("SİMPSON YÖNTEMİ");
                fonksiyon_alma();
                Simpson_Yöntemi();
                
            }
            else if (SecilenYontemNo == 9)
            {
                Console.WriteLine("NÜMERİK TÜREV");
                fonksiyon_alma();
                Numerik_Turev();
            }
        }

        static void fonksiyon_alma(){            
                       
            Console.Write("Denklemin Derecesini giriniz:");
            DenklemDerecesi = Convert.ToInt32(Console.ReadLine());
            for (i = DenklemDerecesi; i >= 0; --i)
            {
                Console.Write("\n X^" + i + "=");
                dizi[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("Girilen Denklem");
            for (i = DenklemDerecesi; i >= 0;--i)
            {
                if (dizi[i] >= 0)
                {
                    Console.Write("+{0}", dizi[i] + "X^" + i);
                }
                else {
                    Console.Write(dizi[i]+"X^"+i);
                }
                
            }
        }

        static void Turev_Alma(){
            Console.WriteLine("\n \n Girilen Denklemin Türevi");
            for (i = DenklemDerecesi-1; i >= 0; --i) {
                diziTurev[i] = dizi[i + 1] * (i + 1);
            }
            
              for (i = DenklemDerecesi-1; i >= 0; --i)
            {
                if (diziTurev[i] >= 0)
                {
                    Console.Write("+{0}", diziTurev[i] + "X^" + i);
                }
                else
                {
                    Console.Write(diziTurev[i] + "X^" + i);
                }

            }
        }

        static void Grafik_Yöntemi()
        {
            
            Double BaslangicDegeri, ArtimMiktari, EpsilonDegeri;
            Double FonksiyonDegeri = 0;
            Console.Write("\n Lütfen bir başlangıç değeri giriniz:");
            BaslangicDegeri = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Lütfen bir artım miktarı giriniz:");
            ArtimMiktari = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Lütfen bir epsilom değeri giriniz:");
            EpsilonDegeri = Convert.ToDouble(Console.ReadLine());

            for (i = DenklemDerecesi; i >= 0; --i)
            {
                FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(BaslangicDegeri, i));

            }
            Console.WriteLine("X={0}        F(X)={1}", BaslangicDegeri, FonksiyonDegeri);
            
            
            do{
                
                if(FonksiyonDegeri<0){
                    FonksiyonDegeri = 0;
                    BaslangicDegeri = BaslangicDegeri + ArtimMiktari;
                    for (i = DenklemDerecesi; i >= 0; --i)
                    {
                        FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(BaslangicDegeri, i));

                    }
                    Console.WriteLine("X={0}        F(X)={1}", BaslangicDegeri, FonksiyonDegeri);
                    if(FonksiyonDegeri>0){
                        BaslangicDegeri = BaslangicDegeri - ArtimMiktari;
                        FonksiyonDegeri = 0;
                        for (i = DenklemDerecesi; i >= 0; --i)
                        {
                            FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(BaslangicDegeri, i));

                        }
                        Console.WriteLine("X={0}        F(X)={1}", BaslangicDegeri, FonksiyonDegeri);
                        ArtimMiktari = ArtimMiktari / 2;
                    }

                }else if(FonksiyonDegeri>0){
                    FonksiyonDegeri = 0;
                    BaslangicDegeri = BaslangicDegeri + ArtimMiktari;
                    for (i = DenklemDerecesi; i >= 0; --i)
                    {
                        FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(BaslangicDegeri, i));

                    }
                    Console.WriteLine("X={0}        F(X)={1}", BaslangicDegeri, FonksiyonDegeri);
                    if (FonksiyonDegeri < 0)
                    {
                        BaslangicDegeri = BaslangicDegeri - ArtimMiktari;
                        FonksiyonDegeri = 0;
                        for (i = DenklemDerecesi; i >= 0; --i)
                        {
                            FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(BaslangicDegeri, i));

                        }
                        Console.WriteLine("X={0}        F(X)={1}", BaslangicDegeri, FonksiyonDegeri);
                        ArtimMiktari = ArtimMiktari / 2;
                    }
                }
               

              
            }while(BaslangicDegeri-(BaslangicDegeri-ArtimMiktari)>EpsilonDegeri && FonksiyonDegeri!=0);

            FonksiyonDegeri = 0;
            BaslangicDegeri = BaslangicDegeri + ArtimMiktari;
            for (i = DenklemDerecesi; i >= 0; --i)
            {
                FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(BaslangicDegeri, i));

            }
            Console.WriteLine("X={0}        F(X)={1}", BaslangicDegeri, FonksiyonDegeri);
            Console.WriteLine("\n KÖK DEĞERİ YAKLAŞIK={0}", BaslangicDegeri-ArtimMiktari);

            
        }

        static void Yariya_Bolme()
        {

            int kontrol = new int();
            kontrol = 0;
            Double a,b,c=0, EpsilonDegeri;
            Double FonksiyonADegeri=0, FonksiyonBDegeri=0,FonksiyonCDegeri = 0;
            Console.Write("\n Lütfen birinci aralık değerini giriniz:");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Lütfen ikinci aralık değerini giriniz:");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Epsilon değerini giriniz:");
            EpsilonDegeri = Convert.ToDouble(Console.ReadLine());

            do{                   
            for (i = DenklemDerecesi; i >= 0; --i)
            {
                FonksiyonADegeri = FonksiyonADegeri + (dizi[i] * power(a, i));

            }
            a = Math.Round(a, 6);
            FonksiyonADegeri = Math.Round(FonksiyonADegeri, 6);            
            Console.Write("A={0}    F(A)={1}", a, FonksiyonADegeri);

            for (i = DenklemDerecesi; i >= 0; --i)
            {
                FonksiyonBDegeri = FonksiyonBDegeri + (dizi[i] * power(b, i));

            }
            b = Math.Round(b, 6);
            FonksiyonBDegeri = Math.Round(FonksiyonBDegeri, 6); 
            Console.Write("     B={0}    F(B)={1}", b, FonksiyonBDegeri);



            if (FonksiyonADegeri * FonksiyonBDegeri > 0)
            {
                Console.Write("\n Bu aralıkta kök yoktur.");
                kontrol = 1;
                break;
            }
            else if (FonksiyonADegeri * FonksiyonBDegeri == 0)
            {
                if (FonksiyonADegeri == 0)
                {
                    a = Math.Round(a, 6);                    
                    Console.WriteLine("Kök değeri={0}",a);
                }
                else if (FonksiyonBDegeri == 0)
                {
                    b = Math.Round(b, 6);
                    Console.WriteLine("Kök değeri={0}", b);
                }
                else if (FonksiyonADegeri == 0 && FonksiyonBDegeri == 0)
                {
                    a = Math.Round(a, 6);
                    b = Math.Round(b, 6); 
                    Console.WriteLine("Kök değeri={0} ve {1} 'dir.",a, b);
                }
            }
            else if (FonksiyonADegeri * FonksiyonBDegeri < 0)
            {
                c = (a + b) / 2;
                for (i = DenklemDerecesi; i >= 0; --i)
                {
                    FonksiyonCDegeri = FonksiyonCDegeri + (dizi[i] * power(c, i));

                }
                c = Math.Round(c, 6);
                FonksiyonCDegeri = Math.Round(FonksiyonCDegeri, 6); 
                Console.Write("     C={0}   F(C)={1}", c, FonksiyonCDegeri);
                if (FonksiyonCDegeri == 0 || Math.Abs(FonksiyonCDegeri)<=EpsilonDegeri)
                {
                    c = Math.Round(c, 6);
                    Console.WriteLine("\n \n Kök değeri={0}", c);
                    kontrol = 1;
                    break;
                }else{
                    if (FonksiyonADegeri * FonksiyonCDegeri < 0)
                    {
                        b = c;
                    }
                    else if (FonksiyonBDegeri * FonksiyonCDegeri < 0)
                    {
                        a = c;
                    }                
                }           
            }
            FonksiyonADegeri = 0;
            FonksiyonBDegeri = 0;
            FonksiyonCDegeri = 0;
            Console.WriteLine("");
            } while (Math.Abs(b - a )> EpsilonDegeri);
            c = Math.Round(c, 6);
            if(kontrol==0){
            Console.WriteLine("\n \n Kök değeri={0}", c);
            }
            
        }

        static void Regula_False() {
            int kontrol = new int();
            kontrol = 0;
            Double a, b, c = 0, EpsilonDegeri;
            Double FonksiyonADegeri = 0, FonksiyonBDegeri = 0, FonksiyonCDegeri = 0;
            Console.Write("\n Lütfen birinci aralık değerini giriniz:");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Lütfen ikinci aralık değerini giriniz:");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Epsilon değerini giriniz:");
            EpsilonDegeri = Convert.ToDouble(Console.ReadLine());

            do
            {
                for (i = DenklemDerecesi; i >= 0; --i)
                {
                    FonksiyonADegeri = FonksiyonADegeri + (dizi[i] * power(a, i));

                }
                a = Math.Round(a, 6);
                FonksiyonADegeri = Math.Round(FonksiyonADegeri, 6);
                Console.Write("A={0}    F(A)={1}", a, FonksiyonADegeri);

                for (i = DenklemDerecesi; i >= 0; --i)
                {
                    FonksiyonBDegeri = FonksiyonBDegeri + (dizi[i] * power(b, i));

                }
                b = Math.Round(b, 6);
                FonksiyonBDegeri = Math.Round(FonksiyonBDegeri, 6);
                Console.Write("     B={0}    F(B)={1}", b, FonksiyonBDegeri);



                if (FonksiyonADegeri * FonksiyonBDegeri > 0)
                {
                    Console.Write("\n Bu aralıkta kök yoktur.");
                    kontrol = 1;
                    break;
                }
                else if (FonksiyonADegeri * FonksiyonBDegeri == 0)
                {
                    if (FonksiyonADegeri == 0)
                    {
                        a = Math.Round(a, 6);
                        Console.WriteLine("Kök değeri={0}", a);
                    }
                    else if (FonksiyonBDegeri == 0)
                    {
                        b = Math.Round(b, 6);
                        Console.WriteLine("Kök değeri={0}", b);
                    }
                    else if (FonksiyonADegeri == 0 && FonksiyonBDegeri == 0)
                    {
                        a = Math.Round(a, 6);
                        b = Math.Round(b, 6);
                        Console.WriteLine("Kök değeri={0} ve {1} 'dir.", a, b);
                    }
                }
                else if (FonksiyonADegeri * FonksiyonBDegeri < 0)
                {
                    c = (b*FonksiyonADegeri-a*FonksiyonBDegeri)/(FonksiyonADegeri-FonksiyonBDegeri);
                    for (i = DenklemDerecesi; i >= 0; --i)
                    {
                        FonksiyonCDegeri = FonksiyonCDegeri + (dizi[i] * power(c, i));

                    }
                    c = Math.Round(c, 6);
                    FonksiyonCDegeri = Math.Round(FonksiyonCDegeri, 6);
                    Console.Write("     C={0}   F(C)={1}", c, FonksiyonCDegeri);
                    if (FonksiyonCDegeri == 0 || Math.Abs(FonksiyonCDegeri) <= EpsilonDegeri)
                    {
                        c = Math.Round(c, 6);
                        Console.WriteLine("\n \n Kök değeri={0}", c);
                        kontrol = 1;
                        break;
                    }
                    else
                    {
                        if (FonksiyonADegeri * FonksiyonCDegeri < 0)
                        {
                            b = c;
                        }
                        else if (FonksiyonBDegeri * FonksiyonCDegeri < 0)
                        {
                            a = c;
                        }
                    }
                }
                FonksiyonADegeri = 0;
                FonksiyonBDegeri = 0;
                FonksiyonCDegeri = 0;
                Console.WriteLine("");
            } while (b - a > EpsilonDegeri);
            c = Math.Round(c, 6);
            if(kontrol==0){
            Console.WriteLine("\n \n Kök değeri={0}", c);  
            }
                  
        }

        static void Newton_Rapson() {
            
            Turev_Alma();
            Double x0,x1=0,xtemp=0, EpsilonDegeri;
            Double FonksiyonDegeri = 0,FonksiyonunTurevDegeri=0;
            Console.Write("\n Lütfen bir başlangıç değeri giriniz:");
            x0 = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Lütfen bir epsilom değeri giriniz:");
            EpsilonDegeri = Convert.ToDouble(Console.ReadLine());
            
            for (i = DenklemDerecesi - 1; i >= 0; --i)
                {
                    FonksiyonunTurevDegeri = FonksiyonunTurevDegeri + (diziTurev[i] * power(x0, i));

                }

            if (FonksiyonunTurevDegeri == 0)
            {
                do{
                Console.Write("\n Lütfen başka bir başlangıç değeri giriniz.Çünkü bu değer fonksiyonun türevini sıfır yapıyor.");
                x0 = Convert.ToDouble(Console.ReadLine());
                
                 for (i = DenklemDerecesi - 1; i >= 0; --i)
                {
                    FonksiyonunTurevDegeri = FonksiyonunTurevDegeri + (diziTurev[i] * power(x0, i));

                }    

                }while(FonksiyonunTurevDegeri == 0);
                
            }
            
                do
                {


                    for (i = DenklemDerecesi; i >= 0; --i)
                    {
                        FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(x0, i));

                    }

                    for (i = DenklemDerecesi - 1; i >= 0; --i)
                    {
                        FonksiyonunTurevDegeri = FonksiyonunTurevDegeri + (diziTurev[i] * power(x0, i));

                    }


                    x1 = x0 - (FonksiyonDegeri / FonksiyonunTurevDegeri);


                    x0 = Math.Round(x0, 6);
                    x1 = Math.Round(x1, 6);
                    Console.Write("X0={0}", x0);
                    Console.WriteLine(" X1={0}", x1);

                    xtemp = x0;
                    x0 = x1;


                    FonksiyonDegeri = 0;
                    FonksiyonunTurevDegeri = 0;
                } while (Math.Abs(xtemp - x1) > EpsilonDegeri);
                Console.WriteLine("\n \n Kök değeri={0}", x1);
            
        }


        static void Matrisin_Inversi() {
            int n, i, j, x, y;
            double sayi, degerTut;
            double[,] matris1 = new double[10, 10];
            double[,] matris2 = new double[10, 10];
            Console.Write("Matrisin boyutunu girniz:");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write("Matrisin {0}  {1} elemaini giriniz:", i, j);
                    sayi = Convert.ToDouble(Console.ReadLine());
                    matris1[i, j] = sayi;
                }
            }

            /*Birim matrisi olusturduk*/
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    matris2[i, j] = 0;
                    matris2[i, i] = 1;
                }
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write("{0}  ", matris1[i, j]);

                }
                for (j = 0; j < n; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("  |    {0}  ", matris2[i, j]);
                    }
                    else
                    {
                        Console.Write("  {0}  ", matris2[i, j]);
                    }
                }
                Console.WriteLine("\n");
            }



            for (i = 0; i < n; i++)
            {

                degerTut = matris1[i, i];
                if (degerTut != 0)
                {
                    for (j = 0; j < n; j++)
                    {
                        matris1[i, j] = (float)matris1[i, j] / degerTut;
                        matris2[i, j] = (float)matris2[i, j] / degerTut;
                    }
                    if (i == 0)
                    {
                        for (x = i + 1; x < n; x++)
                        {
                            degerTut = matris1[x, i];
                            for (y = 0; y < n; y++)
                            {
                                matris1[x, y] = matris1[x, y] - (matris1[i, y] * degerTut);
                                matris2[x, y] = matris2[x, y] - (matris2[i, y] * degerTut);
                            }
                        }
                    }
                    else
                    {

                        for (x = i + 1; x < n; x++)
                        {
                            degerTut = matris1[x, i];
                            for (y = 0; y < n; y++)
                            {
                                matris1[x, y] = matris1[x, y] - (matris1[i, y] * degerTut);
                                matris2[x, y] = matris2[x, y] - (matris2[i, y] * degerTut);
                            }
                        }

                        for (x = i - 1; x >= 0; x--)
                        {
                            degerTut = matris1[x, i];
                            for (y = 0; y < n; y++)
                            {
                                matris1[x, y] = matris1[x, y] - (matris1[i, y] * degerTut);
                                matris2[x, y] = matris2[x, y] - (matris2[i, y] * degerTut);
                            }
                        }



                    }
                }

            }
            Console.WriteLine("-------------------------------------------------");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    matris1[i, j] = Math.Round(matris1[i, j], 3);
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    matris2[i, j] = Math.Round(matris2[i, j], 3);
                }
            }




            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (matris1[i, j] == -0.000)
                    {
                        matris1[i, j] = 0.0;
                    }
                    Console.Write("{0}    ", matris1[i, j]);

                }

                for (j = 0; j < n; j++)
                {

                    if (matris2[i, j] == -0.000)
                    {
                        matris2[i, j] = 0.0;
                    }
                    if (j == 0)
                    {
                        Console.Write("  |    {0}  ", matris2[i, j]);
                    }
                    else
                    {
                        Console.Write("  {0}  ", matris2[i, j]);
                    }
                }
                Console.WriteLine("\n");
            }

            //ilk matrisin birim matris olup olmadığını kontrol ediyoruz.
            //Birim matris değilse matrisin tersi yoktur.
            Boolean kontrol = false;
            for (i = 0; i < n; i++)
            {
                if (matris1[i, i] == 1)
                {
                    kontrol = false;
                }
                else {
                    kontrol = true;
                    break;
                }
            }

            if (kontrol == false)
            {

                Console.WriteLine("\n Girdiğiniz Matrisin Tersi(İnversi):");

                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        Console.Write("  {0}  ", matris2[i, j]);
                    }
                    Console.WriteLine("");
                }
            }
            else {
                Console.WriteLine("\n Girdiğiniz Matrisin Tersi(İnversi) YOKTUR.");
            }

        
}


        static void Gauss_Jordan_Elemination() { 
            int SatirSayisi,SutunSayisi,i,j,x,y;
            double sayi,degerTut,sum;
            double[,] matris1 = new double[10, 10];
            double[] matris2 = new double[10];
            double[] X = new double[10];
            
    Console.Write("Matrisin satir sayisini girimiz:");
    SatirSayisi = Convert.ToInt32(Console.ReadLine());
            
    Console.Write("Matrisin sutun sayisini girimiz:");
    SutunSayisi = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("");
    Console.WriteLine("Sistemin birinci matrisini giriniz:");
    for(i=0;i<SatirSayisi;i++){
        for(j=0;j<SutunSayisi;j++){
            Console.Write("Matrisin {0}  {1} elemaini giriniz:",i,j);
            sayi = Convert.ToDouble(Console.ReadLine());
            matris1[i,j]=sayi;
        }
    }

    Console.WriteLine("");
    Console.Write("Sistemin ikinci matrisini giriniz:");
    Console.WriteLine("");
     for(i=0;i<SatirSayisi;i++){
            Console.Write("Matrisin {0} elemaini giriniz:",i);
            sayi = Convert.ToDouble(Console.ReadLine());
            matris2[i]=sayi;
    }

    for(i=0;i<SatirSayisi;i++){
        for(j=0;j<SutunSayisi;j++){
            Console.Write("{0}  ",matris1[i,j]);

        } Console.Write("  | {0}",matris2[i]);
        Console.WriteLine(" ");
    }


    for(i=0;i<SatirSayisi;i++){
        degerTut=matris1[i,i];
         for(j=0;j<SutunSayisi;j++){
            if(degerTut!=0){
               matris1[i,j]=(double)matris1[i,j]/degerTut;
            }

        }
        if(degerTut!=0){
           matris2[i]=matris2[i]/degerTut;
        }



        for(x=i+1;x<SatirSayisi;x++){
                degerTut=matris1[x,i];

            for(y=0;y<SutunSayisi;y++){

               matris1[x,y]=matris1[x,y]-(matris1[i,y]*degerTut);
            }matris2[x]=matris2[x]-matris2[i]*degerTut;

        }



    }

        Console.WriteLine("\n*********************\n");
                             for(i=0;i<SatirSayisi;i++){
                        for(j=0;j<SutunSayisi;j++){
                                if(matris1[i,j]==-0.0){
                                matris1[i,j]=0.0;
                            }
                            if(matris2[i]==-0.0){
                                matris2[i]=0.0;
                            }



                            Console.Write(" {0}     ", Math.Round(matris1[i, j], 3));

                        } Console.Write("   | {0}", Math.Round(matris2[i], 3));
                        Console.WriteLine();
                    }


                             ///////////MATRİS RANK BULMA//////////
                             int RankA = 0, RankAB = 0, Rankkontrol = 0;
                             for (i = 0; i < SatirSayisi; i++)
                             {
                                 for (j = 0; j < SutunSayisi; j++)
                                 {
                                     if (matris1[i, j] != 0.0)
                                     {
                                         RankA++;
                                         RankAB++;
                                         Rankkontrol = 0;
                                         break;
                                     }
                                     else if (matris1[i, j] == 0.0)
                                     {
                                         Rankkontrol = 1;
                                     }
                                 }
                                 if (Rankkontrol==1 && matris2[i] != 0.0)
                                 {
                                     RankAB++;
                                 }
                               
                             }
                             Console.WriteLine("Rank A:{0}", RankA);
                             Console.WriteLine("Rank AB:{0}", RankAB);

            if(RankA!=RankAB){
                Console.Write("\n Sistemin çözümü yoktur.");
            }
            else if(RankA==RankAB){
                if(RankA==SutunSayisi){
                    Console.Write("\n Sistemin tek bir çözümü vardır.");
                    Console.Write("\n*********-------------------------------************\n");
                    X[SatirSayisi - 1] = matris2[SatirSayisi - 1];

                    for (i = SatirSayisi - 2; i >= 0; i--)
                    {
                        sum = 0.0;
                        for (j = i + 1; j < SatirSayisi; j++)
                        {
                            sum = sum + matris1[i, j] * X[j];
                        }
                        X[i] = matris2[i] - sum;
                    }


                    for (i = 0; i < SatirSayisi; i++)
                    {
                        Console.Write("X{0} degeri:{1}\n", i + 1, Math.Round(X[i], 3));
                    }
                }
                else if(RankA<SutunSayisi){
                    Console.Write("\n Sistemin {0} keyfi değişkene bağlı sonsuz çözümü vardır.",SutunSayisi-RankA);
                }

            }





                 
        }



        static void Trapez_Yöntemi() {
            Double a, b, h;
            int n,say=0;
            Double FonksiyonDegeri = 0;
            Double Fonksiyonilkdegeri = 0;
            Double Fonksiyonsondegeri = 0;
            Double Fonksiyontoplamlari = 0;
            Double sonuc;
            
            Console.Write("\n Lütfen bir başlangıç a değeri giriniz:");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Lütfen bir bitiş b değeri giriniz:");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Lütfen bir adım n değeri giriniz:");
            n = Convert.ToInt32(Console.ReadLine());
                
            h = (b-a) / n;



              Console.WriteLine("******Gerçek değer*******");
            Double FonksiyonGercekilk = 0, FonksiyonGercekSon = 0,gercekdeger=0;
            for (i = DenklemDerecesi; i >= 0; --i)
            {
                
                    //Console.Write("{0}X^{1}/{2}     " ,dizi[i],i+1,i+1);
                    FonksiyonGercekilk = FonksiyonGercekilk + ((dizi[i] * power(a, i + 1)) / (i + 1));
                    FonksiyonGercekSon = FonksiyonGercekSon + ((dizi[i] * power(b, i + 1)) / (i + 1));

            }
            gercekdeger = FonksiyonGercekSon-FonksiyonGercekilk;
            Console.WriteLine("GERÇEK DEĞER={0}",gercekdeger);
            Console.WriteLine("*************");


            do{
                for (i = DenklemDerecesi; i >= 0; --i)
                {
                    FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(a, i));

                }
                Console.WriteLine("X{0}={1}        F(X)={2}",say, a, FonksiyonDegeri);
                
                if(say==0){
                    Fonksiyonilkdegeri = FonksiyonDegeri;
                }
                else if (say < n)
                {
                    Fonksiyontoplamlari = Fonksiyontoplamlari + FonksiyonDegeri;
                }
                else {
                    Fonksiyonsondegeri = FonksiyonDegeri;
                }
                
                
                say++;
                FonksiyonDegeri = 0;
                a = a + h;
            }while(say<=n);

            sonuc=h*(  (Fonksiyonilkdegeri+Fonksiyonsondegeri)/2+Fonksiyontoplamlari );
            Console.WriteLine("BULDUĞUMUZ SONUÇ={0}",sonuc);

            Console.WriteLine("******    HATA   *******");
            Console.WriteLine("HATA={0}", Math.Abs(gercekdeger-sonuc));
            
        }

        static void Simpson_Yöntemi() {
            Double a, b, h;
            int n, say = 0;
            Double FonksiyonDegeri = 0;
            Double Fonksiyonilkdegeri = 0;
            Double Fonksiyonsondegeri = 0;
            Double Fonksiyontektoplamlari = 0;
            Double Fonksiyoncifttoplamlari = 0;
            Double sonuc;

            Console.Write("\n Lütfen bir başlangıç a değeri giriniz:");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Lütfen bir bitiş b değeri giriniz:");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Lütfen bir adım n değeri giriniz:");
            n = Convert.ToInt32(Console.ReadLine());

            h = (b - a) / n;



            Console.WriteLine("******Gerçek değer*******");
            Double FonksiyonGercekilk = 0, FonksiyonGercekSon = 0, gercekdeger = 0;
            for (i = DenklemDerecesi; i >= 0; --i)
            {
                FonksiyonGercekilk = FonksiyonGercekilk + ((dizi[i] * power(a, i + 1)) / (i + 1));
                FonksiyonGercekSon = FonksiyonGercekSon + ((dizi[i] * power(b, i + 1)) / (i + 1));

            }
            gercekdeger = FonksiyonGercekSon - FonksiyonGercekilk;
            Console.WriteLine("GERÇEK DEĞER={0}", gercekdeger);
            Console.WriteLine("*************");


            do
            {
                for (i = DenklemDerecesi; i >= 0; --i)
                {
                    FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(a, i));

                }
                Console.WriteLine("X{0}={1}        F(X)={2}", say, a, FonksiyonDegeri);

                if (say == 0)
                {
                    Fonksiyonilkdegeri = FonksiyonDegeri;
                }
                else if (say < n)
                {
                    if(say%2==0){
                    Fonksiyoncifttoplamlari = Fonksiyoncifttoplamlari + FonksiyonDegeri;
                    }else{
                    Fonksiyontektoplamlari = Fonksiyontektoplamlari + FonksiyonDegeri;
                    }                    
                }
                else
                {
                    Fonksiyonsondegeri = FonksiyonDegeri;
                }


                say++;
                FonksiyonDegeri = 0;
                a = a + h;
            } while (say <= n);

            sonuc = (h /3)* ((Fonksiyonilkdegeri + Fonksiyonsondegeri) +(4*Fonksiyontektoplamlari)+(2*Fonksiyoncifttoplamlari));
            Console.WriteLine("BULDUĞUMUZ SONUÇ={0}", sonuc);

            Console.WriteLine("******    HATA   *******");
            Console.WriteLine("HATA={0}", Math.Abs(gercekdeger - sonuc));
            
        
        }


        static void Numerik_Turev(){
            Double X0, h,FonksiyonDegeri=0;
            Double x, y;
            
            Console.Write("\n Lütfen bir başlangıç X0 değeri giriniz:");
            X0 = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n Lütfen bir DX (h) değeri giriniz:");
            h = Convert.ToDouble(Console.ReadLine());

            
            /*İLERİ FARK YÖNTEMİ*/

            for (i = DenklemDerecesi; i >= 0; --i)
            {
                FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(X0+h, i));

            }
            x = FonksiyonDegeri;
            FonksiyonDegeri = 0;

            for (i = DenklemDerecesi; i >= 0; --i)
            {
                FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(X0, i));

            }
            y = FonksiyonDegeri;
            FonksiyonDegeri = 0;

            Console.WriteLine("\n İleri Fark ile türev:  {0}",(x-y)/h);

            /*GERİ FARK YÖNTEMİ*/
            for (i = DenklemDerecesi; i >= 0; --i)
            {
                FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(X0, i));

            }
            x = FonksiyonDegeri;
            FonksiyonDegeri = 0;

            for (i = DenklemDerecesi; i >= 0; --i)
            {
                FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(X0-h, i));

            }
            y = FonksiyonDegeri;
            FonksiyonDegeri = 0;

            Console.WriteLine("\n Geri Fark ile türev:  {0}", (x - y) / h);

            /*MERKEZİ FARK YÖNTEMİ*/
            for (i = DenklemDerecesi; i >= 0; --i)
            {
                FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(X0+h, i));

            }
            x = FonksiyonDegeri;
            FonksiyonDegeri = 0;

            for (i = DenklemDerecesi; i >= 0; --i)
            {
                FonksiyonDegeri = FonksiyonDegeri + (dizi[i] * power(X0 - h, i));

            }
            y = FonksiyonDegeri;
            FonksiyonDegeri = 0;

            Console.WriteLine("\n Merkezi Fark ile türev:  {0}", (x - y) / (2*h));
        }

        static void Main(string[] args)
        {
           //int taban, us;
            // ... Width is the number of columns of text.
            Console.WindowWidth = 170;
            // ... Height is the number of lines of text.
            Console.WindowHeight = 35;
            //Console.BackgroundColor = ConsoleColor.DarkYellow;
            //Console.ForegroundColor = ConsoleColor.White;
            
            string tus;
            do{
            Console.WriteLine("                          Today's date: {0:D}", DateTime.Now);
            Console.WriteLine("           DİKKAT!!!!!==>  LÜTFEN ONDALIKLI SAYILARI VİRGÜL İLE GİRİNİZ.... \n \n");
            baslangic();   
            Console.WriteLine("\n \n \n Devam etmek istiyormusunuz.Evet için E, hayır  için H'ye basınız.");
                tus=Convert.ToString(Console.ReadKey().Key);
                if (tus == "E") {
                    Console.Clear();
                }
                /*else if (tus == "H")
                {
                    Console.WriteLine("\n \n Çıkış yapılıyor.İyi günler.");
                    
                }*/
            }while(tus=="E");          
            
            
            Console.ReadKey();
        }


   
    }
} 

     
