using System;
using System.Collections.Generic;
using System.IO;

namespace HangmanGame
{
    class Hangman
    {
        private string kataUntukDitebak;
        private char[] kataTebakan;
        private List<char> kataTebakanSebelumnya;
        private int nyawa;
        private int skor;
        private static int skorTertinggi;
        private List<string> daftarKata;
        private string kesulitan;

        public Hangman(string kesulitan)
        {
            this.kesulitan = kesulitan;
            daftarKata = new List<string> { "pemrograman", "hangman", "komputer", "tantangan", "teknologi", "informatika", "matematika" };
            kataTebakanSebelumnya = new List<char>();
            nyawa = SetNyawaBerdasarkanKesulitan();
            skor = 0;
        }

        public void MulaiPermainan()
        {
            Random random = new Random();
            kataUntukDitebak = PilihKataBerdasarkanKesulitan(random);
            kataTebakan = new string('_', kataUntukDitebak.Length).ToCharArray();
            kataTebakanSebelumnya.Clear();
            skor = 0;
            nyawa = SetNyawaBerdasarkanKesulitan();

            while (nyawa > 0 && !PeriksaKemenangan())
            {
                TampilkanKataTebakan();
                TampilkanHangman();
                Console.Write("Tebak huruf: ");
                char tebakan = Console.ReadLine()[0];

                if (kataTebakanSebelumnya.Contains(tebakan))
                {
                    Console.WriteLine("Anda sudah menebak huruf ini. Coba lagi.");
                }
                else
                {
                    kataTebakanSebelumnya.Add(tebakan);
                    if (kataUntukDitebak.Contains(tebakan))
                    {
                        for (int i = 0; i < kataUntukDitebak.Length; i++)
                        {
                            if (kataUntukDitebak[i] == tebakan)
                            {
                                kataTebakan[i] = tebakan;
                                skor += 10;
                            }
                        }
                    }
                    else
                    {
                        nyawa--;
                        skor -= 5;
                        Console.WriteLine($"Salah tebak! Nyawa tersisa: {nyawa}");
                    }
                }
            }

            TampilkanHangman();

            if (PeriksaKemenangan())
            {
                Console.WriteLine($"Selamat! Anda berhasil menebak kata: {kataUntukDitebak}");
                SimpanSkorTertinggi(skor);
            }
            else
            {
                Console.WriteLine($"Game over! Kata yang benar adalah: {kataUntukDitebak}");
            }

            Console.WriteLine($"Skor Anda: {skor}");
            Console.WriteLine($"Skor tertinggi: {skorTertinggi}");
        }

        private bool PeriksaKemenangan()
        {
            return new string(kataTebakan) == kataUntukDitebak;
        }

        private void TampilkanKataTebakan()
        {
            Console.WriteLine($"Kata: {new string(kataTebakan)}");
        }

        private int SetNyawaBerdasarkanKesulitan()
        {
            switch (kesulitan.ToLower())
            {
                case "mudah":
                    return 6;  // Maksimal 6 nyawa agar sesuai dengan jumlah gambar hangman
                case "sedang":
                    return 4;
                case "sulit":
                    return 2;
                default:
                    return 6;
            }
        }

        private string PilihKataBerdasarkanKesulitan(Random random)
        {
            List<string> kataBerdasarkanKesulitan = new List<string>();

            switch (kesulitan.ToLower())
            {
                case "mudah":
                    kataBerdasarkanKesulitan = daftarKata.FindAll(k => k.Length <= 5);
                    break;
                case "sedang":
                    kataBerdasarkanKesulitan = daftarKata.FindAll(k => k.Length > 5 && k.Length <= 8);
                    break;
                case "sulit":
                    kataBerdasarkanKesulitan = daftarKata.FindAll(k => k.Length > 8);
                    break;
                default:
                    kataBerdasarkanKesulitan = daftarKata;
                    break;
            }

            if (kataBerdasarkanKesulitan.Count == 0)
            {
                kataBerdasarkanKesulitan = daftarKata;
            }

            return kataBerdasarkanKesulitan[random.Next(kataBerdasarkanKesulitan.Count)];
        }

        private void SimpanSkorTertinggi(int skor)
        {
            if (skor > skorTertinggi)
            {
                skorTertinggi = skor;
                File.WriteAllText("skor_tertinggi.txt", skorTertinggi.ToString());
            }
        }

        public static void MuatSkorTertinggi()
        {
            if (File.Exists("skor_tertinggi.txt"))
            {
                skorTertinggi = int.Parse(File.ReadAllText("skor_tertinggi.txt"));
            }
            else
            {
                skorTertinggi = 0;
            }
        }

        private void TampilkanHangman()
        {
            string[] gambarHangman = new string[]
            {
                @"
                   -----
                   |   |
                   |   
                   |  
                   |   
                   |   
                 -----
                ",
                @"
                   -----
                   |   |
                   |   O
                   |  
                   |   
                   |   
                 -----
                ",
                @"
                   -----
                   |   |
                   |   O
                   |   |
                   |   
                   |   
                 -----
                ",
                @"
                   -----
                   |   |
                   |   O
                   |  /|
                   |   
                   |   
                 -----
                ",
                @"
                   -----
                   |   |
                   |   O
                   |  /|\
                   |   
                   |   
                 -----
                ",
                @"
                   -----
                   |   |
                   |   O
                   |  /|\
                   |  / 
                   |   
                 -----
                ",
                @"
                   -----
                   |   |
                   |   O
                   |  /|\
                   |  / \
                   |   
                 -----
                "
            };

            Console.WriteLine(gambarHangman[6 - nyawa]);
        }
    }

    class Game
    {
        public void MainMenu()
        {
            bool keluar = false;

            while (!keluar)
            {
                Console.Clear();
                Console.WriteLine("Selamat datang di permainan Hangman!");
                Console.WriteLine("Tebaklah kata rahasia yang terdapat pada game ini untuk memenangkan nya!");
                Console.WriteLine("1. Mulai Permainan");
                Console.WriteLine("2. Keluar");
                Console.Write("Pilih opsi: ");

                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        string kesulitan = PilihKesulitan();
                        Hangman hangman = new Hangman(kesulitan);
                        hangman.MulaiPermainan();
                        Console.WriteLine("Tekan tombol apa saja untuk kembali ke menu utama...");
                        Console.ReadKey();
                        break;
                    case "2":
                        keluar = true;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Coba lagi.");
                        break;
                }
            }
        }

        private string PilihKesulitan()
        {
            Console.Clear();
            Console.WriteLine("Pilih tingkat kesulitan:");
            Console.WriteLine("1. Mudah");
            Console.WriteLine("2. Sedang");
            Console.WriteLine("3. Sulit");
            Console.Write("Masukkan pilihan (1/2/3): ");

            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    return "mudah";
                case "2":
                    return "sedang";
                case "3":
                    return "sulit";
                default:
                    Console.WriteLine("Pilihan tidak valid. Menggunakan kesulitan sedang.");
                    return "sedang";
            }
        }

        static void Main(string[] args)
        {
            Hangman.MuatSkorTertinggi();
            Game game = new Game();
            game.MainMenu();
        }
    }
}
