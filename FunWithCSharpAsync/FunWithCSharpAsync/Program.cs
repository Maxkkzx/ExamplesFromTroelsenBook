using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithCSharpAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Fun With Async ===>");

            List<int> l = default;

            string message = await DoWorkAsync();
            Console.WriteLine(message);
            await MethodReturningVoidAsync();
            Console.WriteLine("Void method completed");
            await MethodReturningVoidAsync();
            await MethodWithProblems(7, -5);
            await MethodWithProblemsFixed(7, -5);
            Console.WriteLine("Completed");
            Console.ReadLine();

        }

        static string DoWork()
        {
            Thread.Sleep(5000);
            return "Done with work!";
        }

        static async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5000);
                return "Done with work!";
            });
        }

        static async Task MethodReturningVoidAsync()
        {
            await Task.Run(() => 
            {
                Thread.Sleep(4000); 
            });
            Console.WriteLine("Void method completed");
        }

        static async Task MultiAwaits()
        {
            await Task.Run(() => { Thread.Sleep(2000); });
            Console.WriteLine("Done with first task");

            await Task.Run(() => { Thread.Sleep(2000); });
            Console.WriteLine("Done with second task");

            await Task.Run(() => { Thread.Sleep(2000); });
            Console.WriteLine("Done with third task");
        }

        static async Task<string> MethodWithTryCatch()
        {
            try
            {
                return "Hello";
            }
            catch (Exception ex)
            {
                await LogTheErrors();
                throw;
            }
            finally
            {
                await DoMagicCleanUp();
            }
        }
        private static Task DoMagicCleanUp()
        {
            throw new NotImplementedException();
        }
        private static Task LogTheErrors()
        {
            throw new NotImplementedException();
        }

        static async ValueTask<int> ReturnAnInt()
        {
            await Task.Delay(1000);
            return 5;
        }

        static async Task MethodWithProblems(int firstParam, int secondParam)
        {
            Console.WriteLine("Enter");
            await Task.Run(() =>
            {
                Thread.Sleep(4000);
                Console.WriteLine("FirstParam Complete");
                Console.WriteLine("Something bad happened");
            });
        }

        static async Task MethodWithProblemsFixed(int firstParam, int secondParam)
        {
            Console.WriteLine("Enter");
            if(secondParam < 0)
            {
                Console.WriteLine("Bad data");
                return;
            }
            actualImplementation();
            async Task actualImplementation()
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(4000);
                    Console.WriteLine("First Complete");

                    Console.WriteLine("Something bad happened");
                });
            }
        }
    }
}