using System;
using MySql.Data.MySqlClient;
using CapaEntidad;
using System.Windows.Forms;
using System.Data;

namespace CapaDatos
{
    public class CDcliente
    {
        string CadenaConexion = "Server=localhost;User=root;Password=123456789;Port=3306;database=clientes";

        public void PruebaConexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);

            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse" + ex.Message);
                return;
            }

            mySqlConnection.Close();
            MessageBox.Show("Conectado");

        }

        public void Crear(CEcliente ce)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `clientes` (`Nombre`, `Apellido`, `Foto`) VALUES ('" + ce.Nombre + "', '" + ce.Apellido + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(ce.Foto) + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query,mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Creado");
        }

        public void Editar(CEcliente ce)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "UPDATE `clientes` SET `Nombre`='" + ce.Nombre + "', `Apellido`='" + ce.Apellido + "', `Foto`='" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(ce.Foto) + "' WHERE  `id`="+ ce.Id +";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Actualizado");
        }

        public void Eliminar(CEcliente ce)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "DELETE FROM `clientes` WHERE  `id`="+ ce.Id +";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Eliminado");
        }


        public DataSet Listar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM `clientes` LIMIT 1000;";
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            Adaptador = new MySqlDataAdapter(Query, mySqlConnection);
            Adaptador.Fill(dataSet, "tbl");

            return dataSet;
                
         
        }
    }
}
