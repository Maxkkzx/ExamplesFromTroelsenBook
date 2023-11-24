namespace DirectoryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Directory(Info) *****\n");
            ShowWindowsDirectoryInfo();
            Console.ReadLine();

            DisplayImageFiles();
            Console.ReadLine();

            ModifyAppDirectory();
            Console.ReadLine();

            FunWithDirectoryType();
        }

        static void ShowWindowsDirectoryInfo()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine($"FullName: {dir.FullName}");
            Console.WriteLine($"Name: {dir.Name}");
            Console.WriteLine($"Parent: {dir.Parent}");
            Console.WriteLine($"Creation: {dir.CreationTime}");
            Console.WriteLine($"Attributes: {dir.Attributes}");
            Console.WriteLine($"Root: {dir.Root}");
            Console.WriteLine("*********************************\n");
        }

        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");

            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            Console.WriteLine($"Found {imageFiles.Length} *.jpg files\n");

            foreach(FileInfo f in imageFiles)
            {
                Console.WriteLine("************************");
                Console.WriteLine($"File name: {f.Name}");
                Console.WriteLine($"File size: {f.Length}");
                Console.WriteLine($"Creation: {f.CreationTime}");
                Console.WriteLine($"Attributes: {f.Attributes}");
                Console.WriteLine("************************\n");
            }
        }

        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");

            dir.CreateSubdirectory("MyFolder");

            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder2\Data");

            Console.WriteLine($"New Folder is: {myDataFolder}");
        }
        
        static void FunWithDirectoryType()
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are you drives:");

            foreach (string s in drives)
                Console.WriteLine($"--> {s}");
            Console.WriteLine("Press Enter to delete directories");
            Console.ReadLine();
            try
            {
                Directory.Delete(@"C:\MyFolder");

                Directory.Delete(@"C:\MyFolder2", true);
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}