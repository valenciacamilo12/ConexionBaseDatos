using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Epacolombia
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            
            txtid.Text = Form1.lista.ElementAt(0);
            txtusuario.Text = Form1.lista.ElementAt(1);
            txtpassword.Text = Form1.lista.ElementAt(2);

        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            Form1.AbrirConexion();
            String query = "UPDATE login SET  usuario ='" + txtusuario.Text + "', contrasena='" + txtpassword.Text + "' WHERE idusuario = '" + txtid.Text + "';";
            MySqlCommand comando = new MySqlCommand(query, Form1.AbrirConexion());
            comando.ExecuteNonQuery();
            MessageBox.Show("El campo se ha actualizado correctamente");
            this.Close();

        }
    }
}
