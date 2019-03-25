using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace waSecurity
{
    public partial class VerTablas : Form
    {
        public VerTablas()
        {
            InitializeComponent();
        }

        private void apartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "select * from apartment";
            select(query);
        }

        private void select(string select)
        {
            var con = new SqlConnection("Data Source=DESKTOP-S9G6OAU\\SQLEXPRESS;Initial Catalog=wasecurity;Integrated Security=True");
            var dataadapter = new SqlDataAdapter(select, con);

            var commandbuilder = new SqlCommandBuilder(dataadapter);
            var ds = new DataSet();
            dataadapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void personToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "select * from person";
            select(query);
        }

        private void vehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "select * from vehicle";
            select(query);
        }

        private void visitsRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "select * from visitsRecord";
            select(query);
        }

        private void VerTablas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wasecurityDataSet.Apartment' table. You can move, or remove it, as needed.
            this.apartmentTableAdapter.Fill(this.wasecurityDataSet.Apartment);
        }
    }
}
