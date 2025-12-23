// Importa dependencias.
using Entidad;
// Importa dependencias.
using Negocio;
// Importa dependencias.
using Presentacion.AAClases;
// Importa dependencias.
using System;
// Importa dependencias.
using System.Data;
// Importa dependencias.
using System.Windows.Forms;
// Importa dependencias.
using Application = System.Windows.Forms.Application;


namespace Presentacion.Proveedor
{
    public partial class PProv_Ing : Form
    {
        ValidaRut Rut = new ValidaRut(); // Instancia validador de RUT
        EProv Ent = new EProv(); // Crea un nuevo proveedor
        // NProv Neg = new NProv();
        NLocCom NegCom = new NLocCom(); // Instancia la lógica de comuna
        NLocPro NegPro = new NLocPro(); // Instancia la lógica de provincia
        NLocReg NegReg = new NLocReg(); // Instancia la lógica de región

        public PProv_Ing()
        {
            InitializeComponent();
            ThemeManager.ApplyExecutiveTheme(this); // Aplica el tema ejecutivo.
        }

        private void PProv_Ing_Load(object sender, EventArgs e)
        {

        }

        // Carga ComboBox de regiones.
        public void LleComReg()
        {
            // Muestra el nombre de la región.
            CBReg.DisplayMember = "Nombre";
            // Usa el ID de la región.
            CBReg.ValueMember = "IdReg";
            // Asigna la lista de regiones.
            CBReg.DataSource = NegReg.Listar();
        }

        // Carga ComboBox de provincias.
        private void CargaCBPro()
        {
            // Obtiene el ID de la región seleccionada.
            int IdReg = Convert.ToInt32(CBReg.SelectedValue);
            // Filtra provincias por ID de región.
            DataTable dt = NegPro.Filtrar(IdReg);
            // Muestra el nombre de la provincia.
            CBPro.DisplayMember = "Nombre";
            // Usa el ID de la provincia.
            CBPro.ValueMember = "IdPro";
            // Asigna la tabla de datos.
            CBPro.DataSource = dt;
        }

        // Carga ComboBox de comunas.
        private void CargaCBCom()
        {
            // Obtiene el ID de la provincia seleccionada.
            int IdPro = Convert.ToInt32(CBPro.SelectedValue);
            // Filtra comunas por ID de provincia.
            DataTable dt = NegCom.Filtrar(IdPro);
            // Muestra el nombre de la comuna.
            CBCom.DisplayMember = "Nombre";
            // Usa el ID de la comuna.
            CBCom.ValueMember = "IdCom";
            // Asigna la tabla de datos.
            CBCom.DataSource = dt;
        }

        // Habilita botón de Ingreso.
        public void HabBotIng() // Habilitar Boton de Ingerso
        {
            // Si todos los campos están llenos.
            if ((TextRut.Text.Trim() != "") && (TextNom.Text.Trim() != "") && (CBReg.Text.Trim() != "") && (CBPro.Text.Trim() != "") && (CBCom.Text.Trim() != "") && (TextDire.Text.Trim() != "") && (TextTel.Text.Trim() != "") && (TextEma.Text.Trim() != "") && (TextGir.Text.Trim() != "") && (TextDescr.Text.Trim() != "")) // "Y" Distinto a vacio
            {
                // Habilita el botón Ingresar.
                ButIng.Enabled = true;
            }
            // Si algún campo está vacío.
            else
            {
                // Deshabilita el botón Ingresar.
                ButIng.Enabled = false;
            }
        }

        // Habilita botón de Limpiar.
        public void HabBotLim() // Habilitar Boton de Ingreso
        {
            // Si al menos un campo tiene contenido.
            if ((TextRut.Text.Trim() != "") || (TextNom.Text.Trim() != "") || (CBReg.Text.Trim() != "") || (CBPro.Text.Trim() != "") || (CBCom.Text.Trim() != "") || (TextDire.Text.Trim() != "") || (TextTel.Text.Trim() != "") || (TextEma.Text.Trim() != "") || (TextGir.Text.Trim() != "") || (TextDescr.Text.Trim() != "")) // "O" Distinto a vacio
            {
                // Habilita el botón Limpiar.
                ButLim.Enabled = true;
            }
            // Si todos los campos están vacíos.
            else
            {
                // Deshabilita el botón Limpiar.
                ButLim.Enabled = false;
            }
        }


        // Al cambiar texto en campo Rut.
        private void TextRut_TextChanged(object sender, EventArgs e)
        {
            // Si campo Rut no está vacío.
            if (TextRut.Text.Trim() != "")
            {
                // Habilita tabulador en TextNom.
                TextNom.TabStop = true;
                // Deshabilita tabulador en TextRut.
                TextRut.TabStop = false;
            }
            // Si campo Rut está vacío.
            else
            {
                // Deshabilita tabulador en TextNom.
                TextNom.TabStop = false;
                // Habilita tabulador en TextRut.
                TextRut.TabStop = true;
            }
            // Habilita botón Ingresar.
            HabBotIng();
        }

        // Al presionar tecla en campo Nombre.
        private void TextNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si la tecla es un dígito.
            if (char.IsDigit(e.KeyChar))                                                                                                          // Ciclo para bloquear numeros
            {
                // Suprime el carácter.
                e.Handled = true;                                                                                                                   // Permitir cualquier valor menos la condición anterior
                                                                                                                                                    // Muestra mensaje de error.
                MessageBox.Show("Solo se permiten letras.", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);                                // Mensaje de OK con error que dice que solo permite letras
            }
        }

        // Al cambiar texto en campo Nombre.
        private void TextNom_TextChanged(object sender, EventArgs e)
        {
            // Capitaliza texto y ajusta cursor.
            TextNom.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextNom.Text);
            TextNom.SelectionStart = TextNom.Text.Length;
            // Si campo Nombre no está vacío.
            if (TextNom.Text.Trim() != "")
            {
                // Habilita tabulador en CBReg.
                CBReg.TabStop = true;
                // Deshabilita tabulador en TextNom.
                TextNom.TabStop = false;
                // Carga ComboBox de regiones.
                LleComReg();
            }
            // Si campo Nombre está vacío.
            else
            {
                // Deshabilita tabulador en CBReg.
                CBReg.TabStop = false;
                // Habilita tabulador en TextNom.
                TextNom.TabStop = true;
            }
            // Habilita botón Ingresar.
            HabBotIng();
        }

        // Al cambiar selección en CBReg.
        private void CBReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si ComboBox Región no está vacío.
            if (CBReg.Text.Trim() != "")
            {
                // Habilita tabulador en CBPro.
                CBPro.TabStop = true;
                // Deshabilita tabulador en CBReg.
                CBReg.TabStop = false;
                // Carga ComboBox de provincias.
                CargaCBPro();
            }
            // Si ComboBox Región está vacío.
            else
            {
                // Deshabilita tabulador en CBReg.
                CBReg.TabStop = false;
                // Habilita tabulador en CBPro.
                CBPro.TabStop = true;
            }
            // Habilita botón Limpiar.
            HabBotLim();
            // Habilita botón Ingresar.
            HabBotIng();
        }

        // Al cambiar selección en CBPro.
        private void CBPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si ComboBox Provincia no está vacío.
            if (CBPro.Text.Trim() != "")
            {
                // Habilita tabulador en CBCom.
                CBCom.TabStop = true;
                // Deshabilita tabulador en CBPro.
                CBPro.TabStop = false;
                // Carga ComboBox de comunas.
                CargaCBCom();
            }
            // Si ComboBox Provincia está vacío.
            else
            {
                // Deshabilita tabulador en CBPro.
                CBPro.TabStop = false;
                // Habilita tabulador en CBCom.
                CBCom.TabStop = true;
            }
            // Habilita botón Limpiar.
            HabBotLim();
            // Habilita botón Ingresar.
            HabBotIng();
        }

        // Al cambiar selección en CBCom.
        private void CBCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si ComboBox Comuna no está vacío.
            if (CBCom.Text.Trim() != "")
            {
                // Habilita tabulador en TextDire.
                TextDire.TabStop = true;
                // Deshabilita tabulador en CBCom.
                CBCom.TabStop = false;
            }
            // Si ComboBox Comuna está vacío.
            else
            {
                // Deshabilita tabulador en TextDire.
                TextDire.TabStop = false;
                // Habilita tabulador en CBCom.
                CBCom.TabStop = true;
            }
            // Habilita botón Limpiar.
            HabBotLim();
            // Habilita botón Ingresar.
            HabBotIng();
        }

        // Al cambiar texto en campo Dirección.
        private void TextDire_TextChanged(object sender, EventArgs e)
        {
            // Si campo Dirección no está vacío.
            if (TextDire.Text.Trim() != "")
            {
                // Habilita tabulador en TextTel.
                TextTel.TabStop = true;
                // Deshabilita tabulador en TextDire.
                TextDire.TabStop = false;
            }
            // Si campo Dirección está vacío.
            else
            {
                // Deshabilita tabulador en TextTel.
                TextTel.TabStop = false;
                // Habilita tabulador en TextDire.
                TextDire.TabStop = true;
            }
            // Habilita botón Limpiar.
            HabBotLim();
            // Habilita botón Ingresar.
            HabBotIng();
        }

        // Al cambiar texto en campo Teléfono.
        private void TextTel_TextChanged(object sender, EventArgs e)
        {
            // Si campo Teléfono no está vacío.
            if (TextTel.Text.Trim() != "")
            {
                // Habilita tabulador en TextEma.
                TextEma.TabStop = true;
                // Deshabilita tabulador en TextTel.
                TextTel.TabStop = false;
            }
            // Si campo Teléfono está vacío.
            else
            {
                // Deshabilita tabulador en TextEma.
                TextEma.TabStop = false;
                // Habilita tabulador en TextTel.
                TextTel.TabStop = true;
            }
            // Habilita botón Limpiar.
            HabBotLim();
            // Habilita botón Ingresar.
            HabBotIng();
        }

        // Al cambiar texto en campo Email.
        private void TextEma_TextChanged(object sender, EventArgs e)
        {
            // Si campo Email no está vacío.
            if (TextEma.Text.Trim() != "")
            {
                // Habilita tabulador en TextGir.
                TextGir.TabStop = true;
                // Deshabilita tabulador en TextEma.
                TextEma.TabStop = false;
            }
            // Si campo Email está vacío.
            else
            {
                // Deshabilita tabulador en TextGir.
                TextGir.TabStop = false;
                // Habilita tabulador en TextEma.
                TextEma.TabStop = true;
            }
            // Habilita botón Limpiar.
            HabBotLim();
            // Habilita botón Ingresar.
            HabBotIng();
        }

        // Al cambiar texto en campo Giro.
        private void TextGir_TextChanged(object sender, EventArgs e)
        {
            // Si campo Giro no está vacío.
            if (TextGir.Text.Trim() != "")
            {
                // Habilita tabulador en TextDescr.
                TextDescr.TabStop = true;
                // Deshabilita tabulador en TextGir.
                TextGir.TabStop = false;
            }
            // Si campo Giro está vacío.
            else
            {
                // Deshabilita tabulador en TextDescr.
                TextDescr.TabStop = false;
                // Habilita tabulador en TextGir.
                TextGir.TabStop = true;
            }
            // Habilita botón Limpiar.
            HabBotLim();
            // Habilita botón Ingresar.
            HabBotIng();
        }

        // Al cambiar texto en campo Descripción.
        private void TextDescr_TextChanged(object sender, EventArgs e)
        {
            // Si campo Descripción no está vacío.
            if (TextDescr.Text.Trim() != "")
            {
                // Habilita tabulador en ButIng.
                ButIng.TabStop = true;
                // Deshabilita tabulador en TextDescr.
                TextDescr.TabStop = false;
            }
            // Si campo Descripción está vacío.
            else
            {
                // Deshabilita tabulador en ButIng.
                ButIng.TabStop = false;
                // Habilita tabulador en TextDescr.
                TextDescr.TabStop = true;
            }
            // Habilita botón Limpiar.
            HabBotLim();
            // Habilita botón Ingresar.
            HabBotIng();
        }

        // Al hacer clic en botón Limpiar.
        private void ButLim_Click(object sender, EventArgs e)
        {
            // Limpia el campo Rut.
            TextRut.Clear();
            // Limpia el campo Nombre.
            TextNom.Clear();
            // Limpia el campo Dirección.
            TextDire.Clear();
            // Limpia el campo Teléfono.
            TextTel.Clear();
            // Limpia el campo Email.
            TextEma.Clear();
            // Limpia el campo Giro.
            TextGir.Clear();
            // Limpia el campo Descripción.
            TextDescr.Clear();
            // Establece ComboBox Región nulo.
            CBReg.DataSource = null;
            // Establece ComboBox Provincia nulo.
            CBPro.DataSource = null;
            // Establece ComboBox Comuna nulo.
            CBCom.DataSource = null;
            // Habilita botón Ingresar.
            HabBotIng();
        }

        private void ButIng_Click(object sender, EventArgs e)
        {
            // Muestra un cuadro de diálogo para confirmar la acción del usuario.
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            string Mensaje = string.Empty; // Declara una cadena para mensajes, aunque no se usa en el bloque 'else'.

            // Asigna los valores de los campos del formulario a las propiedades de la entidad 'Ent'.
            Ent.Nombre = TextNom.Text; // Asigna el nombre
            Ent.Rut = TextRut.Text; // Asigna el RUT
            Ent.IdCom = Convert.ToInt32(CBCom.SelectedValue); // Asigna ID de comuna
            Ent.Direccion = TextDire.Text; // Asigna la dirección
            Ent.Tel = TextTel.Text; // Asigna el teléfono
            Ent.Email = TextEma.Text; // Asigna el email
            Ent.Giro = TextGir.Text; // Asigna el giro
            Ent.Descr = TextDescr.Text; // Asigna la descripción

            // Si el usuario confirma la acción ("Sí").
            if (res == DialogResult.Yes)
            {
                // Intenta ingresar la entidad a través de la capa de negocio 'NProv'.
                Respuesta<bool> resultado = NProv.Ingresar(Ent);

                // Si la operación de ingreso fue exitosa.
                if (resultado.estado)
                {
                    // Muestra un mensaje de éxito al usuario.
                    MessageBox.Show("Ingreso fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Simula un clic en el botón 'ButLim' para limpiar el formulario.
                    ButLim.PerformClick();
                }
                // Si la operación de ingreso falló.
                else
                {
                    // Muestra un cuadro de mensaje con la cadena 'Mensaje' (que está vacía en este código).
                    MessageBox.Show(Mensaje);
                }
            }
            // Si el usuario selecciona "No".
            else if (res == DialogResult.No)
            {
                // Establece el foco en el botón 'ButVol'.
                ButVol.Focus();
            }
            // Si el usuario selecciona "Cancelar".
            else if (res == DialogResult.Cancel)
            {
                // Establece el foco en el botón 'ButSal'.
                ButSal.Focus();
            }
        }

        private void ButVol_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual.
        }

        private void ButSal_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra la aplicación actual.
        }

        private void TextRut_Leave_1(object sender, EventArgs e)
        {
            // Asigna texto del Rut a entidad.
            Ent.Rut = TextRut.Text;
            // Inicializa respuesta de validación.
            bool respuesta = false;
            // Valida el formato del Rut.
            respuesta = Rut.validarRut(TextRut.Text);

            // Si el Rut es inválido.
            if (respuesta == false)
            {
                // Limpia el campo Rut.
                TextRut.Clear();
                // Muestra mensaje de Rut erróneo.
                MessageBox.Show("Rut Malo", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Si el Rut es válido.
            else
            {
                // Muestra mensaje de Rut correcto.
                MessageBox.Show("Rut Bueno", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Habilita botón Limpiar.
                HabBotLim();
                // Habilita botón Ingresar.
                HabBotIng();
            }
        }
    }
}

