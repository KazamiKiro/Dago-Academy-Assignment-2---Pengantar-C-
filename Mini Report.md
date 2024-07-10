# Dago-Academy-Assignment-2---Pengantar-C-
Membuat game "Hangman" berbahasa indonesia dengan C#

Mini Report: Implementasi OOP pada Program Hangman
1. Pendahuluan
Program Hangman yang dibuat menggunakan C# adalah sebuah permainan tebak kata sederhana yang menggunakan konsep Object-Oriented Programming (OOP) untuk mengatur berbagai fitur dan fungsionalitasnya.

2. Fitur Program
Program Hangman ini memiliki beberapa fitur utama:

- Main Menu: Pengguna dapat memilih untuk memulai permainan atau keluar dari program.
- Pemilihan Kesulitan: Pengguna dapat memilih tingkat kesulitan (mudah, sedang, sulit) yang mempengaruhi jumlah nyawa yang diberikan.
- Permainan Hangman: Permainan dimulai dengan memilih kata secara acak berdasarkan kesulitan yang dipilih. Pengguna kemudian menebak huruf untuk mengisi kata yang sedang disembunyikan.
- Tampilan Skor: Skor pengguna ditampilkan setelah permainan selesai, bersama dengan skor tertinggi yang tersimpan.

3. Implementasi OOP
"Kelas Hangman"
> Atribut Privat:
  - kataUntukDitebak: Menyimpan kata yang harus ditebak.
  - kataTebakan: Array karakter untuk menampilkan kata yang sedang ditebak.
  - kataTebakanSebelumnya: List huruf yang sudah ditebak sebelumnya.
  - nyawa: Jumlah nyawa yang tersisa.
  - skor: Skor saat ini.
  - skorTertinggi: Static, menyimpan skor tertinggi yang pernah dicapai.
  - daftarKata: List kata-kata yang dapat dipilih untuk permainan.
  - kesulitan: Tingkat kesulitan permainan yang dipilih.

> Metode Publik:
  - MulaiPermainan(): Memulai permainan Hangman, mengatur alur permainan dan interaksi dengan pengguna.
  - PeriksaKemenangan(): Memeriksa apakah kata sudah berhasil ditebak semua.
  - TampilkanKataTebakan(): Menampilkan kata yang sudah terungkap sebagian.
  - SetNyawaBerdasarkanKesulitan(): Mengatur jumlah nyawa berdasarkan tingkat kesulitan yang dipilih.
  - PilihKataBerdasarkanKesulitan(): Memilih kata secara acak berdasarkan tingkat kesulitan.
  - SimpanSkorTertinggi(int skor): Menyimpan skor tertinggi ke dalam file teks.

"Kelas Game"
> Metode Publik:
  - MainMenu(): Menampilkan menu utama, memproses pilihan pengguna untuk memulai permainan atau keluar dari program.
  - PilihKesulitan(): Menampilkan menu untuk pemilihan tingkat kesulitan dan mengembalikan pilihan yang dipilih oleh pengguna.
  - Main(string[] args): Metode utama untuk menjalankan program, memuat skor tertinggi dan memulai menu utama.

4. Kelebihan Penggunaan OOP
- Pemisahan Logika: Setiap kelas memiliki tugasnya masing-masing, seperti Hangman untuk logika permainan dan Game untuk manajemen interaksi dengan pengguna.
- Penggunaan Objek: Objek Hangman digunakan untuk menyimpan status permainan, memudahkan pengelolaan data seperti kata yang harus ditebak, skor, dan nyawa.
- Kode yang Lebih Terstruktur: OOP membantu dalam mengorganisir kode menjadi bagian-bagian yang lebih kecil dan terfokus, memudahkan pengembangan dan pemeliharaan.

5. Penutup
   Dengan menggunakan OOP, program Hangman ini dapat dikembangkan lebih lanjut dengan mudah, seperti penambahan fitur baru atau penyesuaian aturan permainan. Struktur OOP yang baik juga memungkinkan untuk memisahkan antara berbagai aspek permainan, memudahkan pengembang untuk memahami dan mengelola kode secara efisien.
