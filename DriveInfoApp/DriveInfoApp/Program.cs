namespace DriveInfoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with DriveInfo *****\n");

            DriveInfo[] myDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in myDrives)
            {
                Console.WriteLine($"Name: {d.Name}");
                Console.WriteLine($"Type: {d.DriveType}");

                if(d.IsReady)
                {
                    Console.WriteLine($"Free Space: {d.TotalFreeSpace}");   
                    Console.WriteLine($"Format: {d.DriveFormat}");
                    Console.WriteLine($"Label: {d.VolumeLabel}");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}