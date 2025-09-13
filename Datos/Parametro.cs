namespace Datos
{
    public class Parametro
    {
        public string Nombre { get; set; } // Nombre del parámetro
        public object Valor { get; set; } // Valor del parámetro

        public Parametro(string nombre, object valor) // Constructor de la clase
        {
            Nombre = nombre; // Asigna nombre al parámetro
            Valor = valor; // Asigna valor al parámetro
        }
    }
}