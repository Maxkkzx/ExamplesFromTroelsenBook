using System.Text;

namespace FileStreamApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with FileStream *****\n");

            using (FileStream fStream = File.Open(@"D:\myMessage.dat",
                FileMode.Create))
            {
                string msg = "Hello!";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);

                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                fStream.Position = 0;

                Console.WriteLine("Your message as an array of bytes: ");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];

                for(int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    Console.Write(bytesFromFile[i]);
                }
                Console.WriteLine("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }
            Console.ReadLine();
        }
    }
}