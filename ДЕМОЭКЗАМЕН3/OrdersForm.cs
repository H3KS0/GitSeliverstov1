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
    public partial class OrdersForm : Form
    {
        static string connString;
        public int order_id;
        public int order_role;
        public OrdersForm(int current_role, int current_id)
        {
            order_role = current_role;
            order_id = current_id;
            InitializeComponent();
        }
        private void OrdersForm_load(object sender, EventArgs e)
        {
            GetSettings();
            //select с вложенным запросом
            SqlConnection SqlConnection = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("SELECT o.OrderID, o.DeliveryData, o.CodeToGet, s.ProductArticleNumber, (SELECT PointOfIssue as pointofissue FROM dbo.PointOfIssue WHERE IssueID = PointIssue) FROM dbo.[Order] as o INNER JOIN  dbo.[OrderProduct] as s on (s.OrderID = o.OrderID)", SqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            ProductGridView.DataSource = dataSet.Tables[0];

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
