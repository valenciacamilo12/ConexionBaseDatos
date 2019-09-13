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
    public partial class Form1 : Form
    {
        public static List<String> lista;
        public Form1()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public static MySqlConnection AbrirConexion()
        {
            String cadena;
            cadena = "server=localhost; user=root; database=login; password= 12345; port=3306; SSL Mode=none";
            MySqlConnection conexion = new MySqlConnection(cadena);
            conexion.Open();
            return conexion;
        }

        private void Refrescar_Grilla()
        {
            int contador = 0;
            MySqlConnection conexion = AbrirConexion();
            String query = "SELECT * FROM login";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            for (int i=0; i<daniela.Rows.Count;i++)
            {
                daniela.Rows.RemoveAt(0);
            }

            while (lector.Read())
            {
                daniela.Rows.Add();
                daniela.Rows[contador].Cells[0].Value = lector.GetInt32(0);
                daniela.Rows[contador].Cells[1].Value = lector.GetString(1);
                daniela.Rows[contador].Cells[2].Value = lector.GetString(2);
                contador++;
            }
        }

        
        private void Cargar_Click(object sender, EventArgs e)
        {
            this.Refrescar_Grilla();
        }

        private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 fila;
            fila = daniela.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (fila > 0)
            {
                MySqlConnection conexion = AbrirConexion();

                for (int i = 0; i < fila; i++)
                {
                    int filaeliminar = daniela.SelectedRows[i].Index;
                    String datoaeliminar = daniela.Rows[filaeliminar].Cells[0].Value.ToString();
                    
                    //Codigo de eliminar
                    String query = string.Format("DELETE from LOGIN where idusuario='{0}'",datoaeliminar);
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.ExecuteNonQuery();
                    

                    daniela.Rows.RemoveAt(filaeliminar);
                }

                conexion.Close();
            }
           
        }

        private void ModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 fila;
            fila = daniela.Rows.GetRowCount(DataGridViewElementStates.Selected);
            Form1.lista = new List<String>();
            if (fila > 0)
            {
                MySqlConnection conexion = AbrirConexion();

                for (int i = 0; i < fila; i++)
                {
                    int filaeliminar = daniela.SelectedRows[i].Index;
                    String dato1 = daniela.Rows[filaeliminar].Cells[0].Value.ToString();
                    String dato2 = daniela.Rows[filaeliminar].Cells[1].Value.ToString();
                    String dato3 = daniela.Rows[filaeliminar].Cells[2].Value.ToString();
                    Form1.lista.Add(dato1);
                    Form1.lista.Add(dato2);
                    Form1.lista.Add(dato3);
                    Form2 formulario;
                    formulario = new Form2();
                    formulario.Show();
                    
                    

                }
                
                conexion.Close();
                
            }
            

        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
