using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ДЕМОЭКЗАМЕН3
{
    public partial class BasketForm : Form
    {
        static string connString;
        public int basket_id;
        public int basket_role;
        public BasketForm(int current_role, int current_id)
        {
            basket_role = current_role;
            basket_id = current_id;
            InitializeComponent();
            GetSettings();
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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms[1].Show();
        }
    }
}
