// Importa las entidades del sistema.
using Entidad;
// Importa la lógica de negocio.
using Negocio;
// Importa clases auxiliares de presentación.
using Presentacion.AAClases;
// Importa funcionalidades básicas de .NET.
using System;
// Importa colecciones genéricas de datos.
using System.Collections.Generic;
// Importa componentes de formularios Windows.
using System.Windows.Forms;

// Define el espacio de nombres.
namespace Presentacion.Usuarios
{
    // Clase del formulario de consulta.
    public partial class PUsua_Con : Form
    {
        // Crea instancia de entidad usuario.
        EUsuarios Ent = new EUsuarios();
        // Crea instancia de negocio usuario.
        NUsuarios Neg = new NUsuarios();
        // Crea instancia de negocio permisos.
        NPermisos NegPer = new NPermisos();

        // Almacena el nombre original del usuario.
        private string valorOriginalNombre = "";
        // Almacena la contraseña original del usuario.
        private string valorOriginalPass = "";

        // Constructor del formulario.
        public PUsua_Con()
        {
            // Inicializa los componentes del formulario.
            InitializeComponent();
        }

        // Evento al cargar el formulario.
        private void PUsua_Con_Load(object sender, EventArgs e)
        {
            // Recorre cada columna de la grilla.
            foreach (DataGridViewColumn columna in Grilla.Columns)
            {
                // Si columna visible y no selección.
                if (columna.Visible == true && columna.Name != "Selec")
                {
                    // Agrega columna al combo de filtros.
                    ComboBusReg.Items.Add(new Filtrar() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            // Define propiedad de texto visible.
            ComboBusReg.DisplayMember = "Texto";
            // Define propiedad de valor interno.
            ComboBusReg.ValueMember = "Valor";
            // Selecciona el primer elemento.
            ComboBusReg.SelectedIndex = 0;
            // Carga datos en la grilla.
            CarDat();
            // Aplica el tema visual ejecutivo.
            ThemeManager.ApplyExecutiveTheme(this);
            // Desmarca checkbox de eliminar.
            CheckEli.Checked = false;
            // Deshabilita checkbox de eliminar.
            CheckEli.Enabled = false;
            // Oculta botón de eliminar.
            ButEli.Visible = false;
            // Deshabilita botón de eliminar.
            ButEli.Enabled = false;
        }

        // Configura estados iniciales de eliminación.
        public void Check_funciones()
        {
            // Desmarca checkbox de eliminar.
            CheckEli.Checked = false;
            // Deshabilita checkbox de eliminar.
            CheckEli.Enabled = false;
            // Oculta botón de eliminar.
            ButEli.Visible = false;
            // Deshabilita botón de eliminar.
            ButEli.Enabled = false;
        }

        // Carga usuarios en la grilla.
        public void CarDat()
        {
            // Inicia bloque de control errores.
            try
            {
                // Limpia todas las filas actuales.
                Grilla.Rows.Clear();
                // Obtiene lista completa de usuarios.
                List<EUsuarios> Listar = new NUsuarios().Listar();

                // Recorre cada usuario de lista.
                foreach (EUsuarios item in Listar)
                {
                    // Agrega fila con datos usuario.
                    Grilla.Rows.Add(new object[] { "", item.IdUsu, item.Nombre, item.Pass, item.IdPer });
                }
            }
            // Captura cualquier error ocurrido.
            catch (Exception ex)
            {
                // Muestra mensaje de error.
                MessageBox.Show(ex.Message);
            }
            // Quita la selección de filas.
            Grilla.ClearSelection();
        }

        // Restablece visibilidad de todas filas.
        public void ResetGrid()
        {
            // Recorre cada fila de grilla.
            foreach (DataGridViewRow row in Grilla.Rows)
            {
                // Hace visible la fila actual.
                row.Visible = true;
            }
        }

        // Evento clic botón buscar.
        private void ButBus_Click(object sender, EventArgs e)
        {
            // Obtiene la columna a filtrar.
            string columnaFiltro = ((Filtrar)ComboBusReg.SelectedItem).Valor.ToString();
            // Verifica si hay filas disponibles.
            if (Grilla.Rows.Count > 0)
            {
                // Recorre cada fila de grilla.
                foreach (DataGridViewRow row in Grilla.Rows)
                {
                    // Si texto coincide con búsqueda.
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(TextBus.Text.Trim().ToUpper()))
                        // Muestra la fila actual.
                        row.Visible = true;
                    // Si no coincide con búsqueda.
                    else
                        // Oculta la fila actual.
                        row.Visible = false;
                }
            }
        }

        // Evento tecla presionada en búsqueda.
        private void TextBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si carácter es un dígito.
            if (char.IsDigit(e.KeyChar))
            {
                // Bloquea la entrada del carácter.
                e.Handled = true;
                // Muestra mensaje de solo letras.
                MessageBox.Show("Solo se permiten letras", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento cambio de texto búsqueda.
        private void TextBus_TextChanged(object sender, EventArgs e)
        {
            // Convierte texto a formato título.
            TextBus.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextBus.Text);
            // Coloca cursor al final del texto.
            TextBus.SelectionStart = TextBus.Text.Length;
        }

        // Evento clic limpiar búsqueda.
        private void ButLimBus_Click(object sender, EventArgs e)
        {
            // Limpia el campo de búsqueda.
            TextBus.Text = "";
            // Recarga todos los datos.
            CarDat();
        }

        // Evento doble clic en grilla.
        private void Grilla_DoubleClick(object sender, EventArgs e)
        {
            // Limpia el campo identificador.
            textId.Clear();
            // Limpia el campo nombre modificar.
            TextIngMod.Clear();

            // Habilita checkbox de eliminación.
            CheckEli.Enabled = true;
            // Desmarca checkbox de eliminación.
            CheckEli.CheckState = CheckState.Unchecked;

            // Asigna identificador de fila seleccionada.
            textId.Text = this.Grilla.CurrentRow.Cells[1].Value.ToString();
            // Guarda nombre original del usuario.
            valorOriginalNombre = this.Grilla.CurrentRow.Cells[2].Value.ToString();
            // Asigna nombre a campo modificar.
            TextIngMod.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString();
            // Guarda contraseña original del usuario.
            valorOriginalPass = this.Grilla.CurrentRow.Cells[3].Value.ToString();

            // Deshabilita edición del campo nombre.
            TextIngMod.Enabled = false;
        }

        // Evento cambio checkbox eliminar.
        private void CheckEli_CheckedChanged(object sender, EventArgs e)
        {
            // Si checkbox está marcado.
            if (CheckEli.CheckState == CheckState.Checked)
            {
                // Cambia texto a eliminar usuario.
                label7.Text = "Eliminar Usuario:";
                // Deshabilita edición del nombre.
                TextIngMod.Enabled = false;
                // Muestra el botón eliminar.
                ButEli.Visible = true;
                // Habilita el botón eliminar.
                ButEli.Enabled = true;
            }
            // Si checkbox está desmarcado.
            else
            {
                // Limpia el texto de etiqueta.
                label7.Text = "";
                // Oculta el botón eliminar.
                ButEli.Visible = false;
                // Deshabilita el botón eliminar.
                ButEli.Enabled = false;
            }
        }

        // Evento tecla presionada nombre modificar.
        private void TextIngMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si carácter es un dígito.
            if (char.IsDigit(e.KeyChar))
            {
                // Bloquea la entrada del carácter.
                e.Handled = true;
                // Muestra mensaje de solo letras.
                MessageBox.Show("Solo se permiten letras", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento cambio texto nombre modificar.
        private void TextIngMod_TextChanged(object sender, EventArgs e)
        {
            // Convierte texto a formato título.
            TextIngMod.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextIngMod.Text);
            // Coloca cursor al final del texto.
            TextIngMod.SelectionStart = TextIngMod.Text.Length;
        }

        // Evento cambio texto contraseña.
        private void TextPass_TextChanged(object sender, EventArgs e)
        {
            // Método vacío sin implementación.
        }

        // Evento clic botón ingresar.
        private void ButIng_Click(object sender, EventArgs e)
        {
            // Muestra diálogo de confirmación.
            var res = MessageBox.Show("¿Confirmar acción?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            // Asigna nombre a la entidad.
            Ent.Nombre = TextIngMod.Text;

            // Si usuario confirma acción.
            if (res == DialogResult.Yes)
            {
                // Ingresa nuevo usuario al sistema.
                Respuesta<bool> resultado = NUsuarios.Ingresar(Ent);
                // Si operación fue exitosa.
                if (resultado.estado)
                {
                    // Muestra mensaje de éxito.
                    MessageBox.Show("Ingreso realizado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Ejecuta clic en botón limpiar.
                    ButLim.PerformClick();
                }
                // Si operación falló.
                else
                {
                    // Muestra mensaje de error.
                    MessageBox.Show("Seleccione registro válido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Si usuario selecciona no.
            else if (res == DialogResult.No)
            {
                // Coloca foco en botón volver.
                ButVol.Focus();
            }
            // Si usuario cancela acción.
            else if (res == DialogResult.Cancel)
            {
                // Coloca foco en botón salir.
                ButSal.Focus();
            }

            // Limpia todas las filas grilla.
            Grilla.Rows.Clear();
            // Recarga los datos actualizados.
            CarDat();
        }

        // Evento clic botón modificar.
        private void ButMod_Click(object sender, EventArgs e)
        {
            // Muestra diálogo de confirmación.
            var res = MessageBox.Show("¿Confirmar acción?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            // Asigna identificador a la entidad.
            Ent.IdUsu = Convert.ToInt32(textId.Text);
            // Asigna nombre a la entidad.
            Ent.Nombre = TextIngMod.Text;

            // Si usuario confirma acción.
            if (res == DialogResult.Yes)
            {
                // Actualiza datos del usuario.
                Respuesta<bool> resultado = NUsuarios.Actualizar(Ent);
                // Si operación fue exitosa.
                if (resultado.estado)
                {
                    // Muestra mensaje de éxito.
                    MessageBox.Show("Actualización realizada correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Ejecuta clic en botón limpiar.
                    ButLim.PerformClick();
                }
                // Si operación falló.
                else
                {
                    // Muestra mensaje de error.
                    MessageBox.Show("Seleccione registro válido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Si usuario selecciona no.
            else if (res == DialogResult.No)
            {
                // Coloca foco en botón volver.
                ButVol.Focus();
            }
            // Si usuario cancela acción.
            else if (res == DialogResult.Cancel)
            {
                // Coloca foco en botón salir.
                ButSal.Focus();
            }

            // Limpia todas las filas grilla.
            Grilla.Rows.Clear();
            // Recarga los datos actualizados.
            CarDat();
        }

        // Evento clic botón eliminar.
        private void ButEli_Click(object sender, EventArgs e)
        {
            // Muestra diálogo de confirmación eliminación.
            var res = MessageBox.Show("¿Confirmar eliminación?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            // Si usuario confirma eliminación.
            if (res == DialogResult.Yes)
            {
                // Declara variable para identificador.
                int Id;
                // Intenta convertir texto a número.
                if (int.TryParse(textId.Text, out Id))
                {
                    // Elimina usuario del sistema.
                    Respuesta<bool> resultado = NUsuarios.Eliminar(Id);
                    // Si operación fue exitosa.
                    if (resultado.estado)
                    {
                        // Muestra mensaje de éxito.
                        MessageBox.Show("Eliminación realizada correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Ejecuta clic en botón limpiar.
                        ButLim.PerformClick();
                    }
                    // Si operación falló.
                    else
                    {
                        // Muestra mensaje de error eliminación.
                        MessageBox.Show("No se pudo eliminar registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // Si conversión de texto falló.
                else
                {
                    // Muestra mensaje de registro inválido.
                    MessageBox.Show("Seleccione registro válido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Si usuario selecciona no.
            else if (res == DialogResult.No)
            {
                // Coloca foco en botón volver.
                ButVol.Focus();
            }
            // Si usuario cancela acción.
            else if (res == DialogResult.Cancel)
            {
                // Coloca foco en botón salir.
                ButSal.Focus();
            }
            // Limpia todas las filas grilla.
            Grilla.Rows.Clear();
            // Recarga los datos actualizados.
            CarDat();
        }

        // Evento clic botón volver.
        private void ButVol_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual.
            this.Close();
        }

        // Evento clic botón limpiar.
        private void ButLim_Click(object sender, EventArgs e)
        {
            // Limpia el campo identificador.
            textId.Clear();
            // Limpia el campo nombre modificar.
            TextIngMod.Clear();
            // Limpia valor de nombre original.
            valorOriginalNombre = "";
            // Limpia valor de contraseña original.
            valorOriginalPass = "";
            // Deshabilita edición del nombre.
            TextIngMod.Enabled = false;
            // Restablece visibilidad de filas.
            ResetGrid();
            // Configura estados de eliminación.
            Check_funciones();
            // Recarga todos los datos.
            CarDat();
        }

        // Evento clic botón salir.
        private void ButSal_Click(object sender, EventArgs e)
        {
            // Cierra toda la aplicación.
            Application.Exit();
        }
    }
    // Cierra la clase.
}
// Cierra el namespace.
