using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0612_LINQ_EDM {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        NorthwindEntities context = new NorthwindEntities();

        private void button1_Click(object sender, EventArgs e) {
            var query = from p in context.Products
                        select p;

            dataGridView1.DataSource = query.ToList();

        }

        private void button2_Click(object sender, EventArgs e) {
            var query = from p in context.Products
                        where p.UnitPrice >= 10
                        orderby p.CategoryID descending, p.UnitPrice ascending
                        select new { id = p.ProductID, name = p.ProductName };

            dataGridView1.DataSource = query.ToList();

        }

        private void button3_Click(object sender, EventArgs e) {
            context.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e) {
            var query = from p in context.Products
                        where p.ProductID >= 1
                        select p;
            var objProduct = query.First();
            objProduct.UnitsInStock = 111;
            context.SaveChanges();
        }

        private void button5_Click(object sender, EventArgs e) {
            var query = from p in context.Products
                        where p.CategoryID == 1
                        select p;

            foreach (Product prod in query) {
                prod.UnitPrice -= 1;
            }

            // dataGridView1.DataSource = query.ToList();

            // context.SaveChanges();

        }
    }
}
