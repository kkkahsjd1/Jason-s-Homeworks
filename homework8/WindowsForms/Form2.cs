using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("是否添加该订单的？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    Customer customer1 = new Customer(this.username.Text, this.PhoneNum.Text);
                    OrderDetails a1 = new OrderDetails(this.Product.Text, UInt32.Parse(this.Amount.Text));
                    OrderService.AddOrder(customer1, a1);
                    DialogResult result = MessageBox.Show("成功添加订单", "提示",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    this.Show();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message , "Error Massage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                this.PhoneNum.Text = "";
                this.username.Text = "";
                this.Product.Text = "";
                this.Amount.Text = "";
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("确定退出该页面？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                Form1 form1 = (Form1)this.Owner;
                this.Close();
                form1.UpdateData();
                form1.Show();
            }
            else
            {
                this.Show();
            }
            
        }
    }
}
