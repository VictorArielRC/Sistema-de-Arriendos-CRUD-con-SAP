namespace Entidad
{
    public class Respuesta<T>
    {
        public bool estado { get; set; } // Indica el estado de algo
        public string valor { get; set; } // Almacena un valor de texto
        public T objeto { get; set; } // Objeto de tipo genérico
        public bool mensaje { get; set; } // Indica un estado de mensaje
    }
}
