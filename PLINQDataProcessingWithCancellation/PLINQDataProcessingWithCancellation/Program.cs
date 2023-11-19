using System.Threading;
using System.Threading.Tasks;

namespace PLINQDataProcessingWithCancellation
{
    internal class Program
    {
            static CancellationTokenSource cancelToken = new CancellationTokenSource();
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Start any key to start processing");
                Console.ReadKey();

                Console.WriteLine("Processing");
                Task.Factory.StartNew(() => ProcessIntData());

                Console.Write("Enter Q to quit:");
                string answer = Console.ReadLine();

                if (answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    cancelToken.Cancel();
                    break;
                }
            } while (true);
            Console.ReadLine();
        }

        static void ProcessIntData()
        {
            int[] source = Enumerable.Range(1, 10_000_000).ToArray();

            int[] modThreeIsZero = null;

            try
            {
                modThreeIsZero = (from num in source.AsParallel().WithCancellation(cancelToken.Token)
                                  where num % 3 == 0
                                  orderby num descending
                                  select num).ToArray();
                Console.WriteLine();

                Console.WriteLine($"Found {modThreeIsZero.Count()} numbers that match query!");
            }
            catch (OperationCanceledException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}