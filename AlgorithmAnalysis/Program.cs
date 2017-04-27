using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysis
{
    class Program
    {
        public static int Sonraki(string x)
        {
            if (x.Length < 1)
            {
                return 0;
            }
            return (int)x.Last() - 48; 
        }
        /*
         * TOPLAMA
         */
        public static string Topla(string sayi1,string sayi2)
        {

            string Sonuc = "";
            string s1 = sayi1;
            string s2 = sayi2;
            int elde = 0;
            int a, b;
            

            while (s1.Length != 0 || s2.Length != 0 || elde != 0)
            {
                a = Sonraki(s1);
                
                b = Sonraki(s2);    
                int x = a + b;
                
                if ((x + elde) > 9)
                {
                    Sonuc = ((elde + x) % 10).ToString() + Sonuc;
                    elde = (x + elde) / 10;
                }
                else
                {
                    Sonuc =(x + elde).ToString() + Sonuc;
                    elde = 0;
                }
                

                if (s1.Length != 0 )
                {
                    s1 = s1.Substring(0,s1.Length - 1);
                }
                if (s2.Length != 0)
                {
                    s2 = s2.Substring(0, s2.Length - 1);
                }
            }
            return Sonuc;
        }


        
        /*
         * CIKARMA
         */
        public static string Cikar(string sayi1,string sayi2){
            string Sonuc = "";
            string s1 = sayi1, s2 = sayi2;
            bool EksiYap = false;
            if (s1.Length < s2.Length)
            {
                s1 = sayi2;
                s2 = sayi1;
                EksiYap = true;
            }
            else if (s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    int e = (Convert.ToInt32(s1.ElementAt(i)) - 48);
                    int z = (Convert.ToInt32(s2.ElementAt(i)) - 48);
                    if (e != z)
                    {
                        if (e < z)
                        {
                            
                            s1 = sayi2;
                            s2 = sayi1;
                            EksiYap = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            int a, b, elde = 0;
            
            

            while (s1.Length != 0 || s2.Length != 0)
            {
                a = Sonraki(s1);
                b = Sonraki(s2);
                a -= elde;
                elde = 0;
                int x = a - b;
                if (x < 0)
                {
                    elde = 1;
                    if (s1.Length > 1)
                    {
                        Sonuc = ((a + 10) - b) + Sonuc; 
                    }
                    else
                    {
                        
                    }
                    
                }
                else
                {
                    elde = 0;
                    Sonuc = x + Sonuc; ;
                }

                if (s1.Length != 0)
                {
                    s1 = s1.Substring(0, s1.Length - 1);
                }
                if (s2.Length != 0)
                {
                    s2 = s2.Substring(0, s2.Length - 1);
                }
            }
            if (elde != 0 || EksiYap)
            {
                Sonuc = "-" + Sonuc;
            }
            return Sonuc;

        }

        /*
         * CARPMA
         */
        public static string Carp(string sayi1, string sayi2)
        {
            string s1 = sayi1;
            string s2 = sayi2;
            int Elde = 0;

            string[] Toplanacak = new string[s2.Length];
            
            for (int i = s2.Length - 1; i >= 0; i--)
            {
                
                for (int j = s1.Length - 1; j >= 0; j--)
                {
                    
                    
                    int x = ((int)s1.ElementAt(j) - 48);
                    int y = ((int)s2.ElementAt(i) - 48);

                    if (((x*y)+Elde)>9)
                    {
                        
                        Toplanacak[i] = (((x * y) + Elde) % 10).ToString() + Toplanacak[i];
                        Elde = ((x * y)+Elde) / 10;

                        if (j == 0)
                        {
                            Toplanacak[i] = Elde.ToString() + Toplanacak[i];
                        }
                    }
                    else
                    {
                        string w = ((x * y)+Elde).ToString();
                        Toplanacak[i] = w + Toplanacak[i];
                        
                        Elde = 0;
                    }
                }
                Elde = 0;

                int k =  ((s2.Length - 1) - i);
                for (int s = 0; s < k; s++)
                {
                    Toplanacak[i] += "0";
                }
                
            }
            
            string Sonuc = "0";
            if (s2.Length > 1)
            {
                for (int i = 0; i < s2.Length; i++)
                {
                    //Toplamada Hata VAR
                    Sonuc = Topla(Sonuc, Toplanacak[i]);
                }
            }
            else
            {
                Sonuc = Toplanacak[0];
            }
            
            return Sonuc;
        }

        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            Console.WriteLine("Topla:");
            Console.WriteLine(Topla(s1, s2));
            Console.WriteLine("Cikar:");
            Console.WriteLine(Cikar(s1, s2));
            Console.WriteLine("Carp:");
            Console.WriteLine(Carp(s1, s2));

        }
    }
}
