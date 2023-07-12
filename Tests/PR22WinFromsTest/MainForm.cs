namespace PR22WinFromsTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            new Thread(ComputeValue).Start();
        }
        private void ComputeValue()
        {
           var value = LongProcess(DateTime.Now);
            SetResultValue(value);
           // if(ResultLabel.InvokeRequired)
           // {
           //     ResultLabel.Invoke(new Action(() => ResultLabel.Text = value));
           // }
           // else
           //ResultLabel.Text = value;    
        }

        private void SetResultValue(string value)
        {
            if (ResultLabel.InvokeRequired)
                ResultLabel.Invoke(new Action<string>(SetResultValue), value);
            else
                ResultLabel.Text = value;
        }

        private string LongProcess(DateTime Time)
        {
            Thread.Sleep(5000);
            return $"Value is {Time}";
        }
    }
}