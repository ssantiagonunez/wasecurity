using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace waSecurity
{
    public partial class AnadirApartamento : Form
    {
        public AnadirApartamento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-S9G6OAU\\SQLEXPRESS;Initial Catalog=wasecurity;Integrated Security=True";

            con.Open();

            if(textBox1.Text.Length != 4)
                label2.Text = "El nombre del apartamento debe ser de \ncuatro carácteres";
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into Apartment values('" + textBox1.Text.ToUpper() + "')", con);
                    cmd.ExecuteNonQuery();
                    label2.Text = "Se añadió correctamente."; 
                }
                catch
                {
                    label2.Text = "Este apartamento ya está registrado";
                }
            }

            con.Close();
        }
    }
}
