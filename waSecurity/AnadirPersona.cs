using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace waSecurity
{
    public partial class AnadirPersona : Form
    {
        public AnadirPersona()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-S9G6OAU\\SQLEXPRESS;Initial Catalog=wasecurity;Integrated Security=True";

            string persontype;

            if (comboBox3.SelectedIndex == 0)
                persontype = "Resident";
            else
                persontype = "Visitor";

            DataRowView dv = (DataRowView)comboBox1.SelectedItem;
            string apartmentid = (string)dv.Row["apartmentid"];

            DataRowView dv2 = (DataRowView)comboBox2.SelectedItem;
            string platenumber = (string)dv2.Row["platenumber"];

            con.Open();

            if (textBox1.Text == "" || textBox3.Text == "")
                label6.Text = "Llene todos los campos";
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into person values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + apartmentid + "','" + platenumber + "','" + persontype + "')", con);
                    cmd.ExecuteNonQuery();
                    label6.Text = "Se añadió correctamente.";
                }
                catch
                {
                    label6.Text = "Ha ocurrido un error al añadir.";
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AnadirResidente_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wasecurityDataSet3.Vehicle' table. You can move, or remove it, as needed.
            this.vehicleTableAdapter.Fill(this.wasecurityDataSet3.Vehicle);
            // TODO: This line of code loads data into the 'wasecurityDataSet2.Apartment' table. You can move, or remove it, as needed.
            this.apartmentTableAdapter.Fill(this.wasecurityDataSet2.Apartment);

            comboBox3.SelectedIndex = 0;
        }
    }
}
