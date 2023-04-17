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
    }
}