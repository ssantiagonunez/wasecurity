using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace waSecurity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-S9G6OAU\\SQLEXPRESS;Initial Catalog=wasecurity;Integrated Security=True";
            int contador = 0;

            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from person where apartmentID = '"+textBox1.Text+"' and personType = 'Visitor'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                if(contador == 0)
                {
                    listBox1.Items.Add("Las visitas del apartamento " + textBox1.Text.ToUpper() + " son:");
                    listBox1.Items.Add("");
                }
                
                listBox1.Items.Add ((dr["personID"].ToString() + " " + dr["personName"].ToString() + " " + dr["personLastName"].ToString()));

                contador++;
            }

            listBox1.Items.Add("");
            contador = 0;

            con.Close();

            con.Open();

            cmd = new SqlCommand("Select * from vehicle where apartmentID = '" + textBox1.Text + "'", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (contador == 0)
                {
                    listBox1.Items.Add("Los vehiculos del apartamento " + textBox1.Text.ToUpper() + " son:");
                    listBox1.Items.Add("");
                }
                    
                listBox1.Items.Add((dr["plateNumber"].ToString() + " " + dr["manufacturer"].ToString() + " " + dr["model"].ToString() + " " + dr["color"].ToString()));

                contador++;
            }
            con.Close();
        }

        private void limpiar()
        {
            listBox1.Items.Clear();
            label2.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-S9G6OAU\\SQLEXPRESS;Initial Catalog=wasecurity;Integrated Security=True";

            con.Open();

            try
            {
                string idvisitante = listBox1.SelectedItem.ToString();
                string primerostres = idvisitante.Substring(0, 3);
                SqlCommand cmd = new SqlCommand("insert into VisitsRecord values("+ primerostres + ", @value)", con);
                cmd.Parameters.AddWithValue("@value", date);
                cmd.ExecuteNonQuery();

                label2.Text = "Registro creado.";
            }
            catch (Exception ex)
            {
                label2.Text = "No se pudo crear un registro " + ex;
            }

            con.Close();
        }

        private void residenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new AnadirApartamento();
            form2.Show();
        }

        private void residenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var anadirResidente = new AnadirPersona();
            anadirResidente.Show();
        }

        private void vehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var anadirvehiculo = new AnadirVehiculo();
            anadirvehiculo.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void recordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var records = new Records();
            records.Show();
        }

        private void verTablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clave = new clave();
            clave.Show();
        }
    }
}
