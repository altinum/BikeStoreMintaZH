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
            listBox3.DataSource = context.Products.ToList();
            listBox3.DisplayMember = "ProductName";
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCustomer = (Models.Customer)listBox1.SelectedItem;

            var orders = from x in context.Orders
                         where x.CustomerFk == selectedCustomer.CustomerSk
                         select x;

            listBox2.DataSource = orders.ToList();
            listBox2.DisplayMember = "OrderDate";
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListOrderItems();
        }

        private void ListOrderItems()
        {
            var selectdOrder = (Models.Order)listBox2.SelectedItem;
            var oderItems = from x in context.OrderItems
                            where x.OrderFk == selectdOrder.OrderSk
                            select new DetailedOrderItem
                            {
                                OrderFk = x.OrderFk,
                                ProductFk = x.ProductFk,
                                ProductName = x.ProductFkNavigation.ProductName,
                                Quantity = x.Quantity,
                                ListPrice = x.ListPrice
                            };

            detailedOrderItemBindingSource.DataSource = oderItems.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1
            var selectdOrder = (Models.Order)listBox2.SelectedItem;
            var selctedProduct = (Models.Product)listBox3.SelectedItem;

            //2 
            Models.OrderItem orderItem = new Models.OrderItem();
            orderItem.OrderFk = selectdOrder.OrderSk;
            orderItem.ProductFk = selctedProduct.ProductSk;
            orderItem.Quantity = 1;
            orderItem.ListPrice = selctedProduct.ListPrice;

            //3
            context.OrderItems.Add(orderItem);

            //4
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //5
            ListOrderItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1
            var selectedOrderItem = (DetailedOrderItem)detailedOrderItemBindingSource.Current;
            
            //2
            var ordetItemToBeDeleted = from x in context.OrderItems
                                       where
                                       x.OrderFk == selectedOrderItem.OrderFk &&
                                       x.ProductFk == selectedOrderItem.ProductFk
                                       select x;
            //3
            context.OrderItems.Remove(ordetItemToBeDeleted.FirstOrDefault());

            //4
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //5
            ListOrderItems();
        }
    }
    public class DetailedOrderItem
    {
        public int OrderFk { get; set; }
        public int ProductFk { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal? ListPrice { get; set; }
    }
}
