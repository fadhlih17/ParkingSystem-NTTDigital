using System.Text.RegularExpressions;

List<string> plats = new List<string> {"B-7777-KKK", "B-6666-OOP", "B-5432-TTR"};

foreach (var plat in plats)
{
    // Menggunakan ekspresi reguler untuk mencari nomor pada plat
    var platNumber = Regex.Match(plat, @"\d+").Value;

    // Mengonversi nomor plat menjadi bilangan bulat dan memeriksa apakah itu ganjil
    if (int.TryParse(platNumber, out int number) && number % 2 != 0)
    {
        Console.WriteLine("Ganjil : " + plat);
    }
}