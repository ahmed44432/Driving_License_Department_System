using static System.Net.Mime.MediaTypeNames;
using System.IO;

class Program
{
  
    static void Main()
    {
        Console.WriteLine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent);

        //Path.Combine(Application.StartupPath, "DVLD_People_Images");
    }
}
