using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comanda
{
    public partial class Form1 : Form
    {
        readonly BaseDatos menus;
        public Form1()
        {
            InitializeComponent();
            this.Text = "San Jorge Restaurant";
            this.BackColor = Color.BurlyWood;
            menus = new BaseDatos();
            MenuActivo();
        }

        private void MenuActivo()
        {
            cboMenu.DataSource = menus.Listamenu;
            cboMenu.DisplayMember = "Nombre";
            cboMenu.ValueMember = "Id";
        }

        private void CboMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboMenu.SelectedIndex)
            {
                //El error fue que le faltaba poner que lista tenia que tener cada case
                
                case 1: lstBSeleccion.DataSource = menus.ListAperitivos;
                    lstBSeleccion.DisplayMember = "Nombre";
                    lstBSeleccion.ValueMember = "Id";
                    break;
                case 2: lstBSeleccion.DataSource = menus.Ensalada;
                    lstBSeleccion.DisplayMember = "Nombre";
                    lstBSeleccion.ValueMember = "Id";
                    break;
                case 3: lstBSeleccion.DataSource = menus.ListCarnes;
                    lstBSeleccion.DisplayMember = "Nombre";
                    lstBSeleccion.ValueMember = "Id";
                    break;
                case 4: lstBSeleccion.DataSource = menus.ListPescado;
                    lstBSeleccion.DisplayMember = "Nombre";
                    lstBSeleccion.ValueMember = "Id";
                    break;
                case 5: lstBSeleccion.DataSource = menus.ListPollo;
                    lstBSeleccion.DisplayMember = "Nombre";
                    lstBSeleccion.ValueMember = "Id";
                    break;
                case 6: lstBSeleccion.DataSource = menus.ListPasta;
                    lstBSeleccion.DisplayMember = "Nombre";
                    lstBSeleccion.ValueMember = "Id";
                    break;
                case 7: lstBSeleccion.DataSource = menus.ListSandwich;
                    lstBSeleccion.DisplayMember = "Nombre";
                    lstBSeleccion.ValueMember = "Id";
                    break;
                case 8: lstBSeleccion.DataSource = menus.ListPaninis;
                    lstBSeleccion.DisplayMember = "Nombre";
                    lstBSeleccion.ValueMember = "Id";
                    break;
                case 9: lstBSeleccion.DataSource = menus.ListPostre;
                    lstBSeleccion.DisplayMember = "Nombre";
                    lstBSeleccion.ValueMember = "Id";
                    break;
                case 10:
                    lstBSeleccion.DataSource = menus.ListBebida;
                    lstBSeleccion.DisplayMember = "Nombre";
                    lstBSeleccion.ValueMember = "Id";
                    break;

                default:
                    lstBSeleccion.DataSource = menus.Vacio;
                    lstBSeleccion.DisplayMember = "Nombre";
                    lstBSeleccion.ValueMember = "Id";
                    break;

            }
            
           
        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            AgregarMenu();   
        }
        private void AgregarMenu()
        {
            var valor = lstBSeleccion.SelectedIndex;
            if (valor!=0)
            {
               
                var datos = Convert.ToDouble(cboCantidad.Text) * Convert.ToDouble(txtPrecio.Text);
                var total = Convert.ToString(datos);
                DGV1.Rows.Add(lstBSeleccion.Text, cboCantidad.Text, txtPrecio.Text,total);
     
                
            }

        }

        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarAgregar();
        }

        private void Limpiar()
        {
            txtPrecio.Text = "";
            cboCantidad.Text = "0";
            cboMenu.Text = "None";
            txtTotal.Text = "";
            DGV1.Rows.Clear();
        }

        private void LimpiarAgregar()
        {
            txtPrecio.Text = "";
            cboCantidad.Text = "0";
            cboMenu.Text = "None";
            txtTotal.Text = "";
        }

        //las Mayuscrulas y los nombres de los botones estan en la sintaxis correcta
        private void CmdCobrar_Click(object sender, EventArgs e)
        {
            Cobrar();
        }

        //Mayusculas
        private void Cobrar()
        {
            decimal suma = 0;
            foreach (DataGridViewRow Celda in DGV1.Rows)
            { 
                 suma+=Convert.ToDecimal(Celda.Cells["Total"].Value);
            }

            txtTotal.Text = Convert.ToString(suma);
        }

     
        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Proyecto Poo Mayo 2019" ,"Acerca de");
        }

        private void CobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cobrar();
        }

        private void LimpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarAgregar();
        }

        private void AgregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarMenu();
        }

        private void CerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Limpiar();
        }



    }
}
