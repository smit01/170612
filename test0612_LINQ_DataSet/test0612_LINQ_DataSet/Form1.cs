using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0612_LINQ_DataSet {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            da.Fill(ds.Products);

            DataTable dt = ds.Products;
            // DataTable dt = ds.Tables["xxx"]

            var query = from p in dt.AsEnumerable()
                        select new { id = p["ProductID"], name = p["ProductName"] };

            dataGridView1.DataSource = query.ToList();

        }

        private void button2_Click(object sender, EventArgs e) {
            da.Fill(ds.Products);

            // NorthwindDataSet.ProductsDataTable dt = ds.Products;

            var query = from p in ds.Products
                        where p.UnitPrice >= 10 && p.UnitPrice <= 20
                        orderby p.UnitPrice ascending
                        select p;
        
            dataGridView1.DataSource = query.ToList();

        }

        private void button3_Click(object sender, EventArgs e) {
            da.Fill(ds);

            var query = from p in ds.Products
                        where p.ProductID == 1
                        select p;

            // NorthwindDataSet.ProductsRow objProduct = query.Single();
            var objProduct = query.Single();

            objProduct.UnitPrice = 1530;

            dataGridView1.DataSource = ds.Products;

        }
    }
}
