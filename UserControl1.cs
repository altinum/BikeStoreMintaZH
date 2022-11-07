using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeStoreMintaZH
{
    public partial class UserControl1 : UserControl
    {
        Models.se_bikestoreContext context = new();
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            FilterCustomers();
        }

        private void FilterCustomers()
        {
            var customers = from x in context.Customers
                            where x.Email.Contains(textBox1.Text)
                            select x;
            listBox1.DataSource = customers.ToList();
            listBox1.DisplayMember = "Email";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterCustomers();
        }
    }
}
