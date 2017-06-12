using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace test0612_RegularExpression {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        // A[XO]   AX   AO   ax  A3
        private void button1_Click(object sender, EventArgs e) {
            // Regex pattern = new Regex("^...$");
            // pattern.IsMatch(checkData) ==> Ture/False
            string sUserKeyin = textBox1.Text;
            Regex pattern = new Regex("^CI-[0-9][0-9][0-9]$");
            // if (sUserKeyin == "CI-001" || sUserKeyin == "CI-002" || )
            button1.Text = pattern.IsMatch(sUserKeyin) ? "Yes" : "No";

        }

        private void button2_Click(object sender, EventArgs e) {
            string sNationalID = textBox2.Text;
            // Regex pattern = new Regex("^[A-Z][12][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$");
            // Regex pattern = new Regex(@"^[A-Z][12]\d\d\d\d\d\d\d\d$");
            Regex pattern = new Regex(@"^[A-Z][12]\d{8}$");
            button2.Text = pattern.IsMatch(sNationalID) ? "Yes" : "No";
        }

        private void button3_Click(object sender, EventArgs e) {
            // [0-9a-zA-Z]{1,}@[0-9a-zA-Z.]{1,}
            // ...@...
            // \w+([.-]\w+)*@
            // \w+([.-]\w+)*@\w+([.-]\w+)+
            // chien@gmail.com.tw
            string sEmail = textBox3.Text;
            // Regex pattern = new Regex("^[A-Z][12][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$");
            // Regex pattern = new Regex(@"^[A-Z][12]\d\d\d\d\d\d\d\d$");
            Regex pattern = new Regex(@"^\w+([.-]\w+)*@\w+([.-]\w+)+$");
            button3.Text = pattern.IsMatch(sEmail) ? "Yes" : "No";

        }

        private void button4_Click(object sender, EventArgs e) {

            string sZip = textBox4.Text;
            // Regex pattern = new Regex(@"^\d{3}$|^\d{5}$|^\d{3}-\d{2}$");
            Regex pattern = new Regex(@"^\d{3}(-?\d[2])?$");
            button4.Text = pattern.IsMatch(sZip) ? "Yes" : "No";

        }
    }
}
