using System.Text;

namespace DsiMasterKey;

class DsiMasterKey
{
    public static string Generate(long inquiry, int month, int day)
    {
        string inbufString = $"{month:D2}{day:D2}{inquiry % 10000:D4}";

        byte[] inbuf = Encoding.ASCII.GetBytes(inbufString);

        uint masterKey = Crc32.Compute(inbuf) % 100000;

        return $"{masterKey:D5}";
    }

    public static void Main()
    {
        Console.Write("Inquiry Number: ");
        long inquiry = long.Parse(Console.ReadLine());
        Console.Write("Month: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Day: ");
        int day = int.Parse(Console.ReadLine());
        Console.WriteLine();

        string output = Generate(inquiry, month, day);

        Console.WriteLine(output);
        Console.ReadKey();
    }
}