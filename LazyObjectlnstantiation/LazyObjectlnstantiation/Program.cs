namespace LazyObjectlnstantiation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lazy Instation *****\n");

            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();

            MediaPlayer yourPlayer = new MediaPlayer();
            AllTracks yourMusic = yourPlayer.GetAllTracks();

        }
    }
}