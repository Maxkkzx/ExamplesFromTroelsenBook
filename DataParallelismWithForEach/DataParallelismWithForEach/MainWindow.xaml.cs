using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public MainWindow()
        {

            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }

        private void cmdProccess_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => ProcessFiles());
        }

        private void ProcessFiles()
        {
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            string[] files = Directory.GetFiles(@".\TestPictures", "*.jpg",
                SearchOption.AllDirectories);

            string newDir = @".\ModifiedPictures";
            Directory.CreateDirectory(newDir);

            try
            {
                Parallel.ForEach(files, currentFile =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();

                    string filename = Path.GetFileName(currentFile);

                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(System.IO.Path.Combine(newDir, filename));

                        this.Dispatcher.Invoke((Action)delegate
                        {
                            this.Title = $"Proccesing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
                        });
                    }
                });
                this.Dispatcher.Invoke((Action)delegate
                {
                    this.Title = "Done!";
                });
            }
            catch (OperationCanceledException ex)
            {
                this.Dispatcher.Invoke((Action)delegate
                {
                    this.Title = ex.Message;
                });
            }
        }
    }
}
