namespace FinalizableDisposableClass
{
    internal class MyResourceWrapper : IDisposable
    {
        private bool disposed = false;

        public void Dispose()
        {
            CleanUp(true);

            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {

                }
            }
            disposed = true;
        }
        ~MyResourceWrapper()
        {
            Console.Beep();

            CleanUp(false);
        }
    }
}
