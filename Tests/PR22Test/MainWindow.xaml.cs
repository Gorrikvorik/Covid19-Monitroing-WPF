using System;
using System.Threading;
using System.Windows;


namespace PR22Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Thread(ComputeValue).Start();
        }
        private void ComputeValue() 
        {
            var value = LongProcess(DateTime.Now);
            if (ResultBlock.Dispatcher.CheckAccess())
                ResultBlock.Text = value;
            else
                ResultBlock.Dispatcher.Invoke(() => ResultBlock.Text = value); // синхронный вызов
                ResultBlock.Dispatcher.BeginInvoke(new Action(() => ResultBlock.Text = value)); //Асинхронный вызов
        }

        private string LongProcess (DateTime Time)
        {
            Thread.Sleep(5000);
            return $"Value is {Time}";
        }
    
    }
}
