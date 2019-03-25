using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace waSecurity
{
    public partial class clave : Form
    {
        public clave()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-S9G6OAU\\SQLEXPRESS;Initial Catalog=wasecurity;Integrated Security=True";

            string clave = textBox1.Text;
            clave = obtenersha1(clave);

            con.Open();

            SqlCommand cmd = new SqlCommand("select userpassword from users where userpassword = '" + clave + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                var vertablas = new VerTablas();
                vertablas.Show();
                this.Hide();
            }
            else
                label2.Text = "La clave es incorrecta.";
        }

        private string obtenersha1(string texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();

            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);

            StringBuilder str = new StringBuilder();

            foreach (byte i in hash)
            {
                str.AppendFormat("{0:x2}", i);
            }
            return str.ToString();
        }

    }
}
