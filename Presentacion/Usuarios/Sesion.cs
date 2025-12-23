using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Usuarios
{
    public static class Sesion
    {
        public static int IdUsu { get; set; }
        public static string NombreUsuario { get; set; }
        public static int IdPer { get; set; }
        public static EPermisos Permisos { get; set; }
    }
}
