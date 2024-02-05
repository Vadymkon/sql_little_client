using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL
{
    public partial class Form1 : Form
    {
    public DataTable T;
        public Form1()
        {
            InitializeComponent();
        }
        static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable T = new DataTable();
            T.Columns.Add("ID", typeof(int));
            T.Columns.Add("Ім'я", typeof(string));
            T.Columns.Add("Прізвище", typeof(string));
            T.Columns.Add("Дата народження", typeof(DateTime));

            // Here we add five DataRows.
            T.Rows.Add(25, "Німеччина", "David", DateTime.Now);
            T.Rows.Add(50, "Україна", "Sam", DateTime.Now);
            T.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            T.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            T.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return T;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            T = GetTable();
            dataGridView1.DataSource = T;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string DB = @"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog=TestDB; Integrated Security=True";
            string Query = "select * from MyVisitedCities";
            using (SqlConnection Conn = new SqlConnection(DB))
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                Conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(Query, DB);
                da.Fill(ds);
                T = ds.Tables[0];
                dataGridView1.DataSource = T;
            }
        }
    }
}
