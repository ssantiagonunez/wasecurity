using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace waSecurity
{
    public partial class AnadirVehiculo : Form
    {
        public AnadirVehiculo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-S9G6OAU\\SQLEXPRESS;Initial Catalog=wasecurity;Integrated Security=True";

            DataRowView dv = (DataRowView)comboBox1.SelectedItem;
            string apartmentid = (string)dv.Row["apartmentid"];

            con.Open();

            if (textBox1.Text == "" || textBox1.Text.Length != 6 || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                label6.Text = "Llene todos los campos\nEl número de tablilla debe tener seis carácteres";
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into vehicle values ('" + textBox1.Text.ToUpper() + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + apartmentid + "')", con);
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

        private void AnadirVehiculo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wasecurityDataSet2.Apartment' table. You can move, or remove it, as needed.
            this.apartmentTableAdapter.Fill(this.wasecurityDataSet2.Apartment);

        }
    }
}
