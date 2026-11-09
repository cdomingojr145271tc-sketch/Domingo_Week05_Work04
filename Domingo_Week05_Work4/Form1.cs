
using System;
using System.Windows.Forms;

namespace Domingo_Week05_Work4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;

            
            comboBox1.TextChanged += CalculateMarkup;
            comboBox3.TextChanged += CalculateMarkup;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            comboBox2.Items.Add("Electronics");
            comboBox2.Items.Add("Computer Parts");
            comboBox2.Items.Add("Accessories");
            comboBox2.Items.Add("Food");
            comboBox2.Items.Add("Beverages");
            comboBox2.Items.Add("Others");

            
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDown;

            
            comboBox4.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox4.Enabled = false;

            
            textBox1.Text = "BC" +
                DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        
        private void CalculateMarkup(object sender, EventArgs e)
        {
            decimal cost, price;

            if (decimal.TryParse(comboBox1.Text, out cost) &&
                decimal.TryParse(comboBox3.Text, out price))
            {
                if (cost > 0)
                {
                    decimal markup = ((price - cost) / cost) * 100;

                    comboBox4.Text = markup.ToString("0.00");
                }
                else
                {
                    comboBox4.Text = "";
                }
            }
            else
            {
                comboBox4.Text = "";
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            comboBox1.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Text = "";
            comboBox4.Text = "";

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            checkBox1.Checked = false;

            textBox1.Focus();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            decimal cost, price;

            
            if (textBox1.Text == "" ||
                textBox2.Text == "" ||
                comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please complete all required fields!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show(
                    "Please select product origin!",
                    "Warning");

                return;
            }

            
            if (!decimal.TryParse(comboBox1.Text, out cost) ||
                !decimal.TryParse(comboBox3.Text, out price))
            {
                MessageBox.Show(
                    "Please enter a valid Cost and Price!",
                    "Invalid Input");

                return;
            }

            if (cost <= 0 || price < 0)
            {
                MessageBox.Show(
                    "Cost must be greater than zero and Price cannot be negative!",
                    "Invalid Input");

                return;
            }

            
            string origin = "";

            if (radioButton1.Checked)
            {
                origin = "Local";
            }
            else if (radioButton2.Checked)
            {
                origin = "Abroad";
            }

            
            string status = checkBox1.Checked ? "Active" : "Inactive";

            
            string message =
                "PRODUCT INFORMATION\n\n" +
                "Barcode: " + textBox1.Text + "\n" +
                "Name: " + textBox2.Text + "\n" +
                "Description: " + textBox3.Text + "\n" +
                "Category: " + comboBox2.Text + "\n" +
                "Origin: " + origin + "\n" +
                "Status: " + status + "\n" +
                "Cost: " + cost.ToString("0.00") + "\n" +
                "Price: " + price.ToString("0.00") + "\n" +
                "Markup: " + comboBox4.Text + "%";

            MessageBox.Show(
                message,
                "Product Saved Successfully",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}
