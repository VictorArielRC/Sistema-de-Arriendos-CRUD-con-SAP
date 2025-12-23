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
    // Clase del formulario de modificación.
    public partial class PUsua_Mod : Form
    {
        // Crea instancia de negocio usuarios.
        NUsuarios NegUsu = new NUsuarios();
        // Crea instancia de negocio permisos.
        NPermisos NegPer = new NPermisos();

        // Constructor del formulario.
        public PUsua_Mod()
        {
            // Inicializa los componentes del formulario.
            InitializeComponent();
        }

        // Configura las columnas de la grilla.
        private void ConfigurarGrilla()
        {
            // Limpia todas las columnas existentes.
            GrillaUsuarios.Columns.Clear();
            // Agrega columna de identificador usuario.
            GrillaUsuarios.Columns.Add("IdUsu", "ID");
            // Agrega columna de nombre usuario.
            GrillaUsuarios.Columns.Add("Nombre", "Nombre");
            // Agrega columna de identificador permiso.
            GrillaUsuarios.Columns.Add("IdPer", "IdPer");
            // Oculta la columna de permiso.
            GrillaUsuarios.Columns["IdPer"].Visible = false;
            // Selecciona la fila completa al clic.
            GrillaUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Desactiva selección de múltiples filas.
            GrillaUsuarios.MultiSelect = false;
        }

        // Evento al cargar el formulario.
        private void PUsua_Mod_Load(object sender, EventArgs e)
        {
            // Configura las columnas de grilla.
            ConfigurarGrilla();
            // Carga todos los usuarios existentes.
            CarDat();
            // Limpia todos los campos del formulario.
            LimpiarFormulario();
            // Aplica el tema visual ejecutivo.
            ThemeManager.ApplyExecutiveTheme(this);
            // Oculta contraseña con asteriscos.
            TextPass.PasswordChar = '*';
            // Oculta confirmación con asteriscos.
            TextCon.PasswordChar = '*';
        }

        // Carga usuarios en la grilla.
        public void CarDat()
        {
            // Inicia bloque de control errores.
            try
            {
                // Limpia todas las filas actuales.
                GrillaUsuarios.Rows.Clear();
                // Obtiene lista completa de usuarios.
                List<EUsuarios> Listar = new NUsuarios().Listar();

                // Recorre cada usuario de la lista.
                foreach (EUsuarios item in Listar)
                {
                    // Agrega fila con datos del usuario.
                    GrillaUsuarios.Rows.Add(item.IdUsu, item.Nombre, item.IdPer);
                }
            }
            // Captura cualquier error ocurrido.
            catch (Exception ex)
            {
                // Muestra mensaje de error al usuario.
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Quita la selección de filas.
            GrillaUsuarios.ClearSelection();
        }

        // Carga permisos según identificador dado.
        public void CargarPermisos(int idPer)
        {
            // Inicia bloque de control errores.
            try
            {
                // Obtiene permisos por identificador.
                EPermisos permisos = NPermisos.ObtenerPorId(idPer);

                // Verifica si existen los permisos.
                if (permisos != null)
                {
                    // Guarda identificador de permiso.
                    textIdPer.Text = permisos.IdPer.ToString();

                    // Marca permiso ingresar localidad comuna.
                    ILCom.Checked = permisos.ILCom == "SI";
                    // Marca permiso actualizar localidad comuna.
                    ALCom.Checked = permisos.ALCom == "SI";
                    // Marca permiso eliminar localidad comuna.
                    ELCom.Checked = permisos.ELCom == "SI";

                    // Marca permiso ingresar localidad provincia.
                    ILPro.Checked = permisos.ILPro == "SI";
                    // Marca permiso actualizar localidad provincia.
                    ALPro.Checked = permisos.ALPro == "SI";
                    // Marca permiso eliminar localidad provincia.
                    ELPro.Checked = permisos.ELPro == "SI";

                    // Marca permiso ingresar localidad región.
                    ILReg.Checked = permisos.ILReg == "SI";
                    // Marca permiso actualizar localidad región.
                    ALReg.Checked = permisos.ALReg == "SI";
                    // Marca permiso eliminar localidad región.
                    ELReg.Checked = permisos.ELReg == "SI";

                    // Marca permiso ingresar cliente.
                    ICliente.Checked = permisos.ICliente == "SI";
                    // Marca permiso actualizar cliente.
                    ACliente.Checked = permisos.ACliente == "SI";
                    // Marca permiso eliminar cliente.
                    ECliente.Checked = permisos.ECliente == "SI";

                    // Marca permiso ingresar proveedor.
                    IProv.Checked = permisos.IProv == "SI";
                    // Marca permiso actualizar proveedor.
                    AProv.Checked = permisos.AProv == "SI";
                    // Marca permiso eliminar proveedor.
                    EProv.Checked = permisos.EProv == "SI";

                    // Marca permiso ingresar productos.
                    IProductos.Checked = permisos.IProductos == "SI";
                    // Marca permiso actualizar productos.
                    AProductos.Checked = permisos.AProductos == "SI";
                    // Marca permiso eliminar productos.
                    EProductos.Checked = permisos.EProductos == "SI";

                    // Marca permiso ingresar usuario.
                    IUsu.Checked = permisos.IUsu == "SI";
                    // Marca permiso actualizar usuario.
                    AUsu.Checked = permisos.AUsu == "SI";
                    // Marca permiso eliminar usuario.
                    EUsu.Checked = permisos.EUsu == "SI";
                }
                // Si no encuentra permisos.
                else
                {
                    // Informa que no hay permisos.
                    MessageBox.Show("No se encontraron permisos", "Información");
                    // Desmarca todos los checkboxes.
                    LimpiarCheckboxes();
                }
            }
            // Captura cualquier error ocurrido.
            catch (Exception ex)
            {
                // Muestra mensaje de error al usuario.
                MessageBox.Show($"Error al cargar permisos: {ex.Message}", "Error");
                // Desmarca todos los checkboxes.
                LimpiarCheckboxes();
            }
        }

        // Desmarca todos los permisos.
        public void LimpiarCheckboxes()
        {
            // Desmarca ingresar localidad comuna.
            ILCom.Checked = false;
            // Desmarca actualizar localidad comuna.
            ALCom.Checked = false;
            // Desmarca eliminar localidad comuna.
            ELCom.Checked = false;

            // Desmarca ingresar localidad provincia.
            ILPro.Checked = false;
            // Desmarca actualizar localidad provincia.
            ALPro.Checked = false;
            // Desmarca eliminar localidad provincia.
            ELPro.Checked = false;

            // Desmarca ingresar localidad región.
            ILReg.Checked = false;
            // Desmarca actualizar localidad región.
            ALReg.Checked = false;
            // Desmarca eliminar localidad región.
            ELReg.Checked = false;

            // Desmarca ingresar cliente.
            ICliente.Checked = false;
            // Desmarca actualizar cliente.
            ACliente.Checked = false;
            // Desmarca eliminar cliente.
            ECliente.Checked = false;

            // Desmarca ingresar proveedor.
            IProv.Checked = false;
            // Desmarca actualizar proveedor.
            AProv.Checked = false;
            // Desmarca eliminar proveedor.
            EProv.Checked = false;

            // Desmarca ingresar productos.
            IProductos.Checked = false;
            // Desmarca actualizar productos.
            AProductos.Checked = false;
            // Desmarca eliminar productos.
            EProductos.Checked = false;

            // Desmarca ingresar usuario.
            IUsu.Checked = false;
            // Desmarca actualizar usuario.
            AUsu.Checked = false;
            // Desmarca eliminar usuario.
            EUsu.Checked = false;
        }

        // Limpia todos los campos del formulario.
        public void LimpiarFormulario()
        {
            // Limpia campo identificador modificar.
            textIdMod.Clear();
            // Limpia campo identificador permiso.
            textIdPer.Clear();
            // Limpia campo nombre usuario.
            TextIngMod.Clear();
            // Limpia campo contraseña.
            TextPass.Clear();
            // Limpia campo confirmar contraseña.
            TextCon.Clear();
            // Desmarca todos los checkboxes.
            LimpiarCheckboxes();
            // Quita selección de la grilla.
            GrillaUsuarios.ClearSelection();
            // Desactiva botón de guardar.
            ButGua.Enabled = false;
        }

        // Verifica si hay usuario seleccionado.
        private bool ValidarSeleccion()
        {
            // Si no hay fila seleccionada.
            if (GrillaUsuarios.CurrentRow == null)
            {
                // Muestra mensaje de advertencia.
                MessageBox.Show("Seleccione un usuario", "Advertencia");
                // Retorna validación fallida.
                return false;
            }
            // Retorna validación exitosa.
            return true;
        }

        // Evento clic botón cargar permisos.
        private void ButCar_Click(object sender, EventArgs e)
        {
            // Si no hay selección sale.
            if (!ValidarSeleccion()) return;

            // Inicia bloque de control errores.
            try
            {
                // Obtiene identificador de permiso seleccionado.
                int idPer = Convert.ToInt32(GrillaUsuarios.CurrentRow.Cells["IdPer"].Value);
                // Carga permisos del usuario seleccionado.
                CargarPermisos(idPer);
                // Activa botón de guardar.
                ButGua.Enabled = true;
            }
            // Captura cualquier error ocurrido.
            catch (Exception ex)
            {
                // Muestra mensaje de error.
                MessageBox.Show($"Error al cargar permisos: {ex.Message}", "Error");
            }
        }

        // Evento clic botón guardar cambios.
        private void ButGua_Click(object sender, EventArgs e)
        {
            // Inicia bloque de control errores.
            try
            {
                // Si campo identificador está vacío.
                if (string.IsNullOrEmpty(textIdMod.Text.Trim()))
                {
                    // Muestra advertencia de selección.
                    MessageBox.Show("Debe seleccionar un usuario para actualizar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Sale del método.
                    return;
                }

                // Si campo nombre está vacío.
                if (string.IsNullOrEmpty(TextIngMod.Text.Trim()))
                {
                    // Muestra advertencia de nombre vacío.
                    MessageBox.Show("El nombre no puede estar vacío", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Sale del método.
                    return;
                }

                // Muestra diálogo de confirmación.
                var confirmacion = MessageBox.Show("¿Está seguro de actualizar este usuario?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si usuario confirma la acción.
                if (confirmacion == DialogResult.Yes)
                {
                    // Crea objeto de permisos.
                    EPermisos permisos = new EPermisos();
                    // Asigna identificador de permiso.
                    permisos.IdPer = Convert.ToInt32(textIdPer.Text);
                    // Asigna permiso ingresar localidad comuna.
                    permisos.ILCom = ILCom.Checked ? "SI" : "NO";
                    // Asigna permiso actualizar localidad comuna.
                    permisos.ALCom = ALCom.Checked ? "SI" : "NO";
                    // Asigna permiso eliminar localidad comuna.
                    permisos.ELCom = ELCom.Checked ? "SI" : "NO";
                    // Asigna permiso ingresar localidad provincia.
                    permisos.ILPro = ILPro.Checked ? "SI" : "NO";
                    // Asigna permiso actualizar localidad provincia.
                    permisos.ALPro = ALPro.Checked ? "SI" : "NO";
                    // Asigna permiso eliminar localidad provincia.
                    permisos.ELPro = ELPro.Checked ? "SI" : "NO";
                    // Asigna permiso ingresar localidad región.
                    permisos.ILReg = ILReg.Checked ? "SI" : "NO";
                    // Asigna permiso actualizar localidad región.
                    permisos.ALReg = ALReg.Checked ? "SI" : "NO";
                    // Asigna permiso eliminar localidad región.
                    permisos.ELReg = ELReg.Checked ? "SI" : "NO";
                    // Asigna permiso ingresar cliente.
                    permisos.ICliente = ICliente.Checked ? "SI" : "NO";
                    // Asigna permiso actualizar cliente.
                    permisos.ACliente = ACliente.Checked ? "SI" : "NO";
                    // Asigna permiso eliminar cliente.
                    permisos.ECliente = ECliente.Checked ? "SI" : "NO";
                    // Asigna permiso ingresar productos.
                    permisos.IProductos = IProductos.Checked ? "SI" : "NO";
                    // Asigna permiso actualizar productos.
                    permisos.AProductos = AProductos.Checked ? "SI" : "NO";
                    // Asigna permiso eliminar productos.
                    permisos.EProductos = EProductos.Checked ? "SI" : "NO";
                    // Asigna permiso ingresar proveedor.
                    permisos.IProv = IProv.Checked ? "SI" : "NO";
                    // Asigna permiso actualizar proveedor.
                    permisos.AProv = AProv.Checked ? "SI" : "NO";
                    // Asigna permiso eliminar proveedor.
                    permisos.EProv = EProv.Checked ? "SI" : "NO";
                    // Asigna permiso ingresar usuario.
                    permisos.IUsu = IUsu.Checked ? "SI" : "NO";
                    // Asigna permiso actualizar usuario.
                    permisos.AUsu = AUsu.Checked ? "SI" : "NO";
                    // Asigna permiso eliminar usuario.
                    permisos.EUsu = EUsu.Checked ? "SI" : "NO";

                    // Actualiza permisos en la base.
                    var resultadoPermisos = NPermisos.Actualizar(permisos);

                    // Si falla actualización de permisos.
                    if (!resultadoPermisos.estado)
                    {
                        // Muestra error de actualización permisos.
                        MessageBox.Show("Error al actualizar permisos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Sale del método.
                        return;
                    }

                    // Crea objeto de usuario.
                    EUsuarios usuario = new EUsuarios();
                    // Asigna identificador de usuario.
                    usuario.IdUsu = Convert.ToInt32(textIdMod.Text);
                    // Asigna nombre del usuario.
                    usuario.Nombre = TextIngMod.Text.Trim();
                    // Asigna contraseña del usuario.
                    usuario.Pass = TextPass.Text.Trim();
                    // Asigna identificador de permiso.
                    usuario.IdPer = Convert.ToInt32(textIdPer.Text);

                    // Declara variable de resultado.
                    Respuesta<bool> resultadoUsuario;

                    // Si hay contraseña ingresada.
                    if (!string.IsNullOrEmpty(TextPass.Text.Trim()))
                    {
                        // Actualiza con contraseña e identificador.
                        resultadoUsuario = NUsuarios.Actualizar2(usuario);
                    }
                    // Si no hay contraseña.
                    else
                    {
                        // Actualiza solo el nombre.
                        resultadoUsuario = NUsuarios.Actualizar(usuario);
                    }

                    // Si actualización fue exitosa.
                    if (resultadoUsuario.estado)
                    {
                        // Muestra mensaje de éxito.
                        MessageBox.Show("Usuario y permisos actualizados correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Recarga datos de la grilla.
                        CarDat();
                        // Limpia todos los campos.
                        LimpiarFormulario();
                    }
                    // Si falla actualización de usuario.
                    else
                    {
                        // Muestra mensaje de error.
                        MessageBox.Show("No se pudo actualizar el usuario", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Captura cualquier error ocurrido.
            catch (Exception ex)
            {
                // Muestra mensaje de error detallado.
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento clic botón limpiar.
        private void ButLim_Click(object sender, EventArgs e)
        {
            // Limpia todos los campos.
            LimpiarFormulario();
        }

        // Evento clic botón volver.
        private void ButVol_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual.
            this.Close();
        }

        // Evento clic botón salir.
        private void ButSal_Click(object sender, EventArgs e)
        {
            // Cierra toda la aplicación.
            Application.Exit();
        }

        // Evento clic en celda grilla.
        private void GrillaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Método vacío sin implementación.
        }

        // Evento doble clic en grilla.
        private void GrillaUsuarios_DoubleClick(object sender, EventArgs e)
        {
            // Obtiene la fila seleccionada actualmente.
            var filaSeleccionada = GrillaUsuarios.CurrentRow;

            // Si no hay fila sale.
            if (filaSeleccionada == null) return;

            // Carga identificador en campo modificar.
            textIdMod.Text = filaSeleccionada.Cells["IdUsu"].Value?.ToString() ?? string.Empty;
            // Carga nombre en campo modificar.
            TextIngMod.Text = filaSeleccionada.Cells["Nombre"].Value?.ToString() ?? string.Empty;

            // Obtiene identificador de permiso.
            int idPer = Convert.ToInt32(filaSeleccionada.Cells["IdPer"].Value);
            // Carga permisos del usuario.
            CargarPermisos(idPer);

            // Activa botón de guardar.
            ButGua.Enabled = true;
        }

        // Evento cambio checkbox mostrar contraseña.
        private void CheckPass_CheckedChanged(object sender, EventArgs e)
        {
            // Muestra u oculta caracteres contraseña.
            TextPass.PasswordChar = CheckPass.Checked ? '\0' : '*';
        }

        // Evento cambio checkbox mostrar confirmación.
        private void CheckCon_CheckedChanged(object sender, EventArgs e)
        {
            // Muestra u oculta caracteres confirmación.
            TextCon.PasswordChar = CheckCon.Checked ? '\0' : '*';
        }
    }
    // Cierra la clase.
}
// Cierra el namespace.
