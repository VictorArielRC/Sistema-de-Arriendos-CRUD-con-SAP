// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using Negocio;
// Accede a códigos de otra librería
using System;
// Accede a códigos de otra librería
using System.Windows.Forms;
// Accede a códigos de otra librería
using static System.Net.Mime.MediaTypeNames;
// Accede a códigos de otra librería
using Application = System.Windows.Forms.Application;


namespace Presentacion.Usuarios
{
    public partial class PUsua_Ing : Form
    {
        //ELogin Ent = new ELogin();
        public PUsua_Ing()
        {
            InitializeComponent();
        }

        public void HabBotIng()
        {
            if ((TextNom.Text.Trim() != "") || (TextPass.Text.Trim() != "") || (TextCon.Text.Trim() != ""))
            {
                ButLim.Enabled = true;
                if ((TextNom.Text.Trim() != "") && (TextPass.Text.Trim() != "") && (TextCon.Text.Trim() != ""))
                {
                    ButIng.Enabled = true;
                }
                else
                {
                    ButIng.Enabled = false;
                }
            }
            else
            {
                ButLim.Enabled = false;
            }
        }

        private void Usua_Ing_Load(object sender, EventArgs e)
        {

        }

        private void TextNom_TextChanged(object sender, EventArgs e)
        {
            HabBotIng();
        }

        private void TextPass_TextChanged(object sender, EventArgs e)
        {
            HabBotIng();
        }
        private void CHBVPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CHBVPass.CheckState == CheckState.Checked)
            {
                TextPass.PasswordChar = '\0';
            }
            else
            {
                TextPass.PasswordChar = '*';
            }
        }

        private void TextCon_TextChanged(object sender, EventArgs e)
        {
            HabBotIng();
        }

        private void CHBCPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CHBCPass.CheckState == CheckState.Checked)
            {
                TextCon.PasswordChar = '\0';
            }
            else
            {
                TextCon.PasswordChar = '*';
            }
        }

        private void ButIng_Click(object sender, EventArgs e)
        {
            if (TextPass.Text.Trim() == TextCon.Text.Trim())
            {
                var res = MessageBox.Show("¿Está seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    EUsua Ent = new EUsua
                    {
                        Nombre = TextNom.Text,
                        Pass = TextPass.Text
                    };
                    // Llamada a la capa de negocio
                    Respuesta<bool> resultado = NUsua.Insertar(Ent);
                    if (resultado.estado)
                    {
                        MessageBox.Show("El ingreso fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Limpiar los campos de texto
                        ButLim.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar usuario", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Es distinta la contraseña de la confirmación", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButLim_Click(object sender, EventArgs e)
        {
            TextNom.Text = ""; 
            TextPass.Text = "";
            TextCon.Text = "";
        }

        private void ButSal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
