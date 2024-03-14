﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ДЕМОЭКЗАМЕН3
{
    public partial class Menu : Form
    {
        static string connString;

        public int menu_id;
        public int menu_role;
        public Menu(int current_role, int current_id)
        {
            menu_role = current_role;
            menu_id = current_id;
            InitializeComponent();
        }
        public void GetSettings()
        {
            connString = Properties.Settings.Default.connString;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.connString = connString;
            Properties.Settings.Default.Save();
        }
        private void Menu_load(object sender, EventArgs e)
        {   
            if (menu_role == 2)
            {
                PanelAdd.Visible = true;
            }
            else
            {
                PanelAdd.Visible = false;
            }
            GetSettings();
            //Заполнение таблицы 
            SqlConnection SqlConnection = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("select ProductArticleNumber, ProductName, MaxDiscount, CurrDiscount, Cost from Product", SqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            ProductGridView.DataSource = dataSet.Tables[0];

        }
        private void filterTB_TextChanged(object sender, EventArgs e)
        {   //Фильтр через запрос
            (ProductGridView.DataSource as DataTable).DefaultView.RowFilter = $"ProductName LIKE '%{filterTB.Text}'";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }   
            //фильтрация 
        private void comboBox1_Select(object sender, EventArgs e)
        {  

            switch (comboBox1.SelectedIndex)
            {

                case 0:
                    (ProductGridView.DataSource as DataTable).DefaultView.RowFilter = $"MaxDiscount <10";
                    break;
                case 1:
                    (ProductGridView.DataSource as DataTable).DefaultView.RowFilter = $"MaxDiscount >=10 and MaxDiscount <=15";
                    break;
                case 2:
                    (ProductGridView.DataSource as DataTable).DefaultView.RowFilter = $"MaxDiscount >15";
                    break;

            }
        }
        private void ProductListView_Select(object sender, EventArgs e)
        {

        }


        private void productGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = ProductGridView.HitTest(e.X, e.Y);
                if (hit.RowIndex >=0)
                {
                    ProductGridView.ClearSelection();
                    ProductGridView.Rows[hit.RowIndex].Selected = true ;
                    contextMenuStrip1.Show(ProductGridView, e.Location);
                }
            }
        }

        private void OrderBT_Click (object sender, EventArgs e)
        {
            this.Hide();
            OrdersForm form = new OrdersForm(menu_role, menu_id);
            form.Show();
        }
        private void BasketBT_Click(object sender, EventArgs e)
        {
            this.Hide();
            BasketForm form = new BasketForm(menu_role, menu_id);
            form.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
       
        }
        private void order_Click(object sender, EventArgs e)
        { //Не работает 
           /*  List<String> basket = new List<string>();
       for (int i = 0; i < ProductGridView.Rows.Count; i++)
       {
           basket.Add(ProductGridView[0, i].Value.ToString());
           MessageBox.Show(basket[i].ToString());
       }*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm form1 = new AdminForm();
            form1.Show();
        }
    }
}
