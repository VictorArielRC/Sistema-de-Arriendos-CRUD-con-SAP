using System;
// Accede a códigos de otra librería

namespace Presentacion.AAClases
{
    public class ValidaRut
    {
        public string formatoRut(string rut) // Formato del rut
        {
            int cont = 0; // Inicializa un contador.
            string format; // Declara una cadena para el formato.

            // Elimina puntos y guiones del RUT.
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");

            // Formatea el dígito verificador.
            format = "-" + rut.Substring(rut.Length - 1);

            // Itera el RUT de derecha a izquierda.
            for (int i = rut.Length - 2; i >= 0; i--)
            {
                // Añade el dígito actual al formato.
                format = rut.Substring(i, 1) + format;
                cont++; // Incrementa el contador.

                // Si el contador llega a 3 y no es el inicio del RUT.
                if (cont == 3 && i != 0)
                {
                    // Añade un punto al formato.
                    format = "." + format;
                    cont = 0; // Reinicia el contador.
                }
            }
            return format; // Retorna el RUT formateado.
        }

        // Valida un RUT chileno.
        public bool validarRut(string rut)
        {
            bool validacion = false; // Inicializa la validación como falsa.
            try // Bloque para manejar errores.
            {
                rut = rut.ToUpper(); // Convierte el RUT a mayúsculas.
                rut = rut.Replace(".", ""); // Elimina puntos.
                rut = rut.Replace("-", ""); // Elimina guiones.

                // Extrae el cuerpo del RUT y el dígito verificador.
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1; // Inicializa variables para el cálculo.
                                  // Calcula el dígito verificador esperado.
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }

                // Compara el dígito verificador.
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true; // El RUT es válido.
                }
            }
            catch (Exception) // Captura cualquier excepción.
            {
                // No hace nada, la validación permanece falsa.
            }
            return validacion; // Retorna el resultado de la validación.
        }
    }
}