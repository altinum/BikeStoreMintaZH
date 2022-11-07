namespace BikeStoreMintaZH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserControl1 uc = new UserControl1();
            Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
    }
}