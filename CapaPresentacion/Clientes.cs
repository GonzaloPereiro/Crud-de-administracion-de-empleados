using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class Clientes : Form
    {
        CNcliente cNcliente = new CNcliente();
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            gridDatos.DataSource = cNcliente.ObtenerDatos().Tables["tbl"];
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }

        private void LimpiarForm()
        {

            txtId.Value = 0;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            picFoto.Image = null;
        }

        private void linkSeleccionar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            opdFoto.FileName = string.Empty;

            if (opdFoto.ShowDialog() == DialogResult.OK)
            {
                picFoto.Load(opdFoto.FileName);
            }

            opdFoto.FileName = string.Empty;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool Resultado; 
            CEcliente cEcliente = new CEcliente();
            cEcliente.Id = (int)txtId.Value;
            cEcliente.Nombre = txtNombre.Text;
            cEcliente.Apellido = txtApellido.Text;
            cEcliente.Foto = picFoto.ImageLocation;

            Resultado = cNcliente.ValidarDatos(cEcliente);
            if (Resultado == false)
            {
                return;
            }
            if (cEcliente.Id == 0)
            {
                cNcliente.CrearCliente(cEcliente);  
            }
            else
            {
                cNcliente.EditarCliente(cEcliente);
            }

            CargarDatos();
            LimpiarForm();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Value == 0) return;

            if(MessageBox.Show("¿Deseas eliminar el registro?","Titulo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CEcliente ce = new CEcliente();
                ce.Id = (int)txtId.Value;
                cNcliente.EliminarCliente(ce);
                CargarDatos();
                LimpiarForm();
            }
        }

        private void gridDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Value = (int)gridDatos.CurrentRow.Cells["id"].Value;
            txtNombre.Text = gridDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtApellido.Text = gridDatos.CurrentRow.Cells["apellido"].Value.ToString();
            picFoto.Load(gridDatos.CurrentRow.Cells["foto"].Value.ToString());
        }
    }
}
