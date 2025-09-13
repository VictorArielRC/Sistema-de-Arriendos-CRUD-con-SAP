// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using Negocio;
// Accede a códigos de otra librería
using Presentacion.AAClases;
// Accede a códigos de otra librería
using System;
// Accede a códigos de otra librería
using System.Collections.Generic;
// Accede a códigos de otra librería
using System.ComponentModel;
// Accede a códigos de otra librería
using System.Data;
// Accede a códigos de otra librería
using System.Drawing;
// Accede a códigos de otra librería
using System.Linq;
// Accede a códigos de otra librería
using System.Text;
// Accede a códigos de otra librería
using System.Threading.Tasks;
// Accede a códigos de otra librería
using System.Windows.Forms;


namespace Presentacion.Usuarios
{
    public partial class PUsua_Con : Form
    {
        EUsua Ent = new EUsua();
        NUsua Neg = new NUsua();
        public PUsua_Con()
        {
            InitializeComponent();
        }

        private void PUsua_Con_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in Grilla.Columns)
            {

                if (columna.Visible == true && columna.Name != "Selec")
                {
                    ComboBusReg.Items.Add(new Filtrar() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            ComboBusReg.DisplayMember = "Texto";
            ComboBusReg.ValueMember = "Valor";
            ComboBusReg.SelectedIndex = 0;
            CarDat();
        }
        public void CarDat()
        {
            try
            {
                Grilla.Rows.Clear();
                List<EUsua> Listar = new NUsua().Listar();
                foreach (EUsua item in Listar)
                {
                    Grilla.Rows.Add(new object[] { "", item.IdUsu, item.Nombre, item.Pass });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Grilla.ClearSelection();
        }

    }
}
