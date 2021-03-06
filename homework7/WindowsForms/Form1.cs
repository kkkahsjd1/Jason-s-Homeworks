﻿using System;
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
    public partial class Form1 : Form
    {
        public string KeyWord1 { get; set; }
        public string KeyWord2 { get; set; }
        public string KeyWord3 { get; set; }
        public Form1()
        {
            InitializeComponent();
            InitialData();
            orderDetailsBindingSource1.DataSource = OrderService.GetList();
            textBox1.DataBindings.Add("Text", this, "KeyWord1");
            textBox2.DataBindings.Add("Text", this, "KeyWord2");
            textBox3.DataBindings.Add("Text", this, "KeyWord3");    
        }
        
        private void InitialData()
        {
            Customer customer1 = new Customer("lry", "13092787491");
            Customer customer2= new Customer("ljh", "13274574319");
            Customer customer3 = new Customer("lgr", "13092783343");
            Product.AddProducts(new Product("banana", 10030));
            Product.AddProducts(new Product("apple", 11299));
            Product.AddProducts(new Product("computer", 8939));
            Product.AddProducts(new Product("laptop", 12000));
            Product.AddProducts(new Product("earphone", 13000));
            OrderDetails a1 = new OrderDetails("20181111829", "banana", 7);
            OrderDetails a2 = new OrderDetails("20181111423", "apple", 2);
            OrderDetails a3 = new OrderDetails("20181111859", "computer", 3);
            OrderDetails a4 = new OrderDetails("20181111821", "laptop", 5);
            OrderDetails a5 = new OrderDetails("20181111800", "earphone", 6);
            OrderService.AddOrder(customer1,a1);
            OrderService.AddOrder(customer1, a2);
            OrderService.AddOrder(customer2, a3);
            OrderService.AddOrder(customer3, a4);
            OrderService.AddOrder(customer3, a5);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Client")
            {
                textBox1.ReadOnly = false;
                orderDetailsBindingSource1.DataSource =
                   OrderService.GetList().Where(s => s.Client == KeyWord1);
                
            }
            else if (comboBox1.SelectedItem.ToString() == "Num" )
            {
                textBox1.ReadOnly = false;
                orderDetailsBindingSource1.DataSource =
                   OrderService.GetList().Where(s => s.Num == uint.Parse(KeyWord1));
               
            }
            else if (comboBox1.SelectedItem.ToString() == "Product")
            {
                textBox1.ReadOnly = false;
                orderDetailsBindingSource1.DataSource =
                   OrderService.GetList().Where(s => s.Product == KeyWord1);
                
            }
            else if (comboBox1.SelectedItem.ToString() == "Price")
            {
                textBox1.ReadOnly = false;
                if (KeyWord2 == null)
                {
                    orderDetailsBindingSource1.DataSource = from n in OrderService.GetList()
                                                           where n.Price <= uint.Parse(KeyWord3)
                                                           orderby n.Price descending
                                                           select n;

                }
                if(KeyWord3 == null)
                {
                    orderDetailsBindingSource1.DataSource = from n in OrderService.GetList()
                                                           where  n.Price >= uint.Parse(KeyWord2)
                                                           orderby n.Price descending
                                                           select n;

                }
                if (KeyWord3 != null && KeyWord2 != null && uint.Parse(KeyWord3) > uint.Parse(KeyWord2))
                {
                    orderDetailsBindingSource1.DataSource = from n in OrderService.GetList()
                                                           where (n.Price <= uint.Parse(KeyWord3)) && (n.Price >= uint.Parse(KeyWord2))
                                                           orderby n.Price descending
                                                           select n;
                }
                else {
                    MessageBox.Show("您输入的信息有误，请重新输入", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Text = null;
                    textBox3.Text = null;
                }

            }

        }

        private void orderDetailsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Price")
            {
                textBox2.Visible = true;
                textBox3.Visible = true;
                label3.Visible = true;
                textBox1.ReadOnly = true;
            }
            else if (comboBox1.SelectedItem.ToString() == "Client")
            {
                textBox1.ReadOnly = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                label3.Visible = false;
            }
            else if (comboBox1.SelectedItem.ToString() == "Num")
            {
                textBox1.ReadOnly = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                label3.Visible = false;

            }
            else if (comboBox1.SelectedItem.ToString() == "Product")
            {
                textBox1.ReadOnly = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                label3.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //选中的行数
                //int iCount = dataGridView1.SelectedRows.Count;
                //if (iCount < 1)
                //{
                //    MessageBox.Show("Delete Data Fail!", "Error", MessageBoxButtons.OK,
                //       MessageBoxIcon.Error);
                //    return;
                //}
                //if (DialogResult.Yes == MessageBox.Show("是否删除选中的数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                //{
                //    for (int i = 0; i < this.dataGridView1.Rows.Count-1; i++)  
                //    {
                //        if (true == this.dataGridView1.Rows[i].Selected)
                //            this.dataGridView1.Rows.RemoveAt(i);
                //    }
                //}

                foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                {
                    if (!r.IsNewRow)
                    {
                        dataGridView1.Rows.Remove(r);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orderServiceBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
