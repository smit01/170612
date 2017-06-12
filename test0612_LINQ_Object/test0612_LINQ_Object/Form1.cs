using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0612_LINQ_Object {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string[] dataList = new string[] { "a1", "b", "a2", "c" };

            var query = from x in dataList
                        select x;

            foreach (var item in query) {
                MessageBox.Show(item);
            }


            //for (int i = 0; i < dataList.Length; i++) {
            //    var s = dataList[i];
            //    if (s.IndexOf("a") == 0) { // found
            //        MessageBox.Show(s);
            //    }
            //}
            //foreach (string s in dataList) {
            //    if (s.IndexOf("a") == 0) { // found
            //        MessageBox.Show(s);
            //    }
            //}

        }

        /*
           ABC   ABC   ==> ==
           -------------------
           AB  
           ABC  
           ==   ABC > AB
           -------------------
           BA  
           ABC  
           B > A ==> BA > ABC
           -------------------
           small > big
           Z>B  利大於弊
        */
        private void button2_Click(object sender, EventArgs e) {
            string[] dataList = new string[] { "a1", "b", "a2", "c" };

            var query = from data in dataList
                        orderby data ascending
                        select data;

            foreach (var item in query) {
                MessageBox.Show(item);
            }

        }

        private void button3_Click(object sender, EventArgs e) {
            string[] dataList = new string[] { "a1", "b", "a2", "c" };
            
            var query = from data in dataList
                        where data == "a2"
                        orderby data ascending
                        select data;

            foreach (var item in query) {
                MessageBox.Show(item);
            }

        }

        private void button4_Click(object sender, EventArgs e) {
            string[] dataList = new string[] { "a1", "ba", "a2", "c" };

            var query = from data in dataList
                        where data.IndexOf("a") >= 0
                        orderby data ascending
                        select data;

            foreach (var item in query) {
                MessageBox.Show(item);
            }

        }

        private void button5_Click(object sender, EventArgs e) {
            string[] dataList = new string[] { "a1", "ax", "a31x", "a2", "c" };
            System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex(@"^a[0-9]*$");

            var query = from data in dataList
                        where rx.IsMatch(data)
                        orderby data descending
                        select data;

            foreach (var item in query) {
                MessageBox.Show(item);
            }

        }

        private void button6_Click(object sender, EventArgs e) {
            string[] dataList = new string[] { "a1", "ba", "a2", "c" };

            var query = from data in dataList
                        where data.IndexOf("a") >= 0
                        orderby data ascending
                        select data.ToUpper();

            foreach (var item in query) {
                MessageBox.Show(item);
            }

        }

        private void button7_Click(object sender, EventArgs e) {
            string[] dataList = new string[] { "a1", "ba", "a2", "c" };

            var query = from data in dataList
                        where data.IndexOf("a") >= 0
                        orderby data ascending
                        select new { original = data, upperVer = data.ToUpper() };

            foreach (var item in query) {
                MessageBox.Show(item.upperVer);
            }

        }

        private void button8_Click(object sender, EventArgs e) {
            Food[] foodList = new Food[] {
                new Food() { name = "milk", price = 5 },
                new Food() { name = "bread", price = 15 },
                new Food() { name = "sugar", price = 15 },
                new Food() { name = "water", price = 2 }
            };

            var query = from food in foodList
                        where food.price > 2
                        orderby food.price ascending, food.name descending
                        select new { FoodName = food.name, Price_NT = food.price * 10 };

            foreach (var item in query) {
                MessageBox.Show(item.FoodName);
            }

        }
    }

    class Food {
        public string name { set; get; }
        public int price { set; get; }
    }

}
