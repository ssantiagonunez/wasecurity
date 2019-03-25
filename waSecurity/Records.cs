using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace waSecurity
{
    public partial class Records : Form
    {
        public Records()
        {
            InitializeComponent();
        }

        private void Records_Load(object sender, EventArgs e)
        {
            var select = "select visitRecordID, visitsRecord.personID, personName, personLastName, recorddate from VisitsRecord inner join person on VisitsRecord.personid = Person.personID";
            var con = new SqlConnection("Data Source=DESKTOP-S9G6OAU\\SQLEXPRESS;Initial Catalog=wasecurity;Integrated Security=True");
            var dataadapter = new SqlDataAdapter(select, con);

            var commandbuilder = new SqlCommandBuilder(dataadapter);
            var ds = new DataSet();
            dataadapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
