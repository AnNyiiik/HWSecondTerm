namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public void Write(object sender, EventArgs e)
        {
            label1.Text = calculationHandler.Acc;
        }

        public void CalculationProcess(object sender, EventArgs e)
        {
            var character = (sender as Button)?.Text;
            if (character == null)
            {
                MessageBox.Show("empty string");
                return;
            }
            calculationHandler.CalculationProcess(character);

        }

    }
}