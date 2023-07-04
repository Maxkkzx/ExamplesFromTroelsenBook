using System.Diagnostics;

namespace ProcessManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Processes *****\n");
            ListAllRunningProcesses();

            Console.WriteLine("***** Enter PID of processto investigate *****");
            Console.Write("PID: ");
            string pID = Console.ReadLine();
            int theProcID = int.Parse(pID);

            EnumThreadsForPid(theProcID);
            Console.ReadLine();
            Console.WriteLine();

            EnumModsForPid(theProcID);

            StartAndKillProcess();
        }

        static void ListAllRunningProcesses()
        {
            var runningProcs = from proc in Process.GetProcesses(".")
                               orderby proc.Id select proc;

            foreach (var p in runningProcs)
            {
                string info = $"-> PID: {p.Id}\tName: {p.ProcessName}";
                Console.WriteLine(info);
            }
            Console.WriteLine("***************************************\n");
        }

        static void GetSpecificProcess()
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(987);
            }
            catch ( ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void EnumThreadsForPid(int Pid)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(Pid);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Here are the threads used by: {0}", theProc.ProcessName);

            ProcessThreadCollection theThreads = theProc.Threads;

            foreach(ProcessThread pt in theThreads)
            {
                string info =
                    $"-> Thread ID: {pt.Id}\tStart Time: {pt.StartTime.ToShortTimeString()}\tPriority: {pt.PriorityLevel}";
                Console.WriteLine(info);
            }
            Console.WriteLine("*********************************************************************************************\n");
        }

        static void EnumModsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch( ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Here are the loaded modules for: {0}",
                theProc.ProcessName);

            ProcessModuleCollection theMods = theProc.Modules;

            foreach(ProcessModule pm in theMods)
            {
                string info = $"-> Mod Name: {pm.ModuleName}";
                Console.WriteLine(info);
            }
            Console.WriteLine("********************************");
        }
            
        static void StartAndKillProcess()
        {
            Process ffProc = null;

            try
            {
                ProcessStartInfo startInfo = new
                    ProcessStartInfo("Firefox.exe", "www.facebook.com");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;

                ffProc = Process.Start(startInfo);   
            }
            catch (InvalidOperationException ex) 
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("--> Hit enter to kill {0}...", ffProc.ProcessName);
            Console.ReadLine();

            try
            {
                ffProc.Kill();
            }
            catch (InvalidOperationException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}