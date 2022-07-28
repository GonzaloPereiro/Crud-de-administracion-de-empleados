using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class CNcliente
    {
        CDcliente cDcliente = new CDcliente();
        public bool ValidarDatos(CEcliente cliente)
        {
            bool Resultado = true;

            if(cliente.Nombre == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El campo es obligatorio");
            }

            if (cliente.Apellido == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El campo es obligatorio");
            }

            if(cliente.Foto == null)
            {
                Resultado = false;
                MessageBox.Show("La foto es obligatoria");
            }

            return Resultado;
        }

        public void CrearCliente(CEcliente cE)
        {
            cDcliente.Crear(cE); 
        }


        public void EditarCliente(CEcliente cE)
        {
            cDcliente.Editar(cE);
        }

        public void EliminarCliente(CEcliente cE)
        {
            cDcliente.Eliminar(cE);
        }


        public DataSet ObtenerDatos()
        {
            return cDcliente.Listar();
        }
                
    }
}
    