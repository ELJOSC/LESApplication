using LESApplication.Models;
using System.Collections.Generic;

namespace LESApplication.Services
{
    public class LES
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public LES()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        bool EstaVacia()
        {
            return PrimerNodo == null;
        }

        public string AgregarNodoFinal(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            return "Nodo agregado al final de la lista";
        }

        public string AgregarNodoInicio(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
            }
            return "Nodo agregado al inicio de la lista";
        }

        public string AgregarNodoAntesDe(Nodo nuevoNodo, int datoX)
        {
            if (EstaVacia())
            {
                return "La lista está vacía";
            }

            if (PrimerNodo.Dato == datoX)
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
                return "Nodo agregado antes del primer nodo";
            }

            Nodo actual = PrimerNodo;
            while (actual.Referencia != null)
            {
                if (actual.Referencia.Dato == datoX)
                {
                    nuevoNodo.Referencia = actual.Referencia;
                    actual.Referencia = nuevoNodo;
                    return "Nodo agregado antes del dato " + datoX;
                }
                actual = actual.Referencia;
            }

            return "Dato " + datoX + " no encontrado en la lista";
        }

        public string AgregarNodoDespuesDe(Nodo nuevoNodo, int datoX)
        {
            if (EstaVacia())
            {
                return "La lista está vacía";
            }

            Nodo actual = PrimerNodo;
            while (actual != null)
            {
                if (actual.Dato == datoX)
                {
                    nuevoNodo.Referencia = actual.Referencia;
                    actual.Referencia = nuevoNodo;
                    if (actual == UltimoNodo)
                    {
                        UltimoNodo = nuevoNodo;
                    }
                    return "Nodo agregado después del dato " + datoX;
                }
                actual = actual.Referencia;
            }

            return "Dato " + datoX + " no encontrado en la lista";
        }

        public string AgregarNodoEnPosicion(Nodo nuevoNodo, int posicion)
        {
            if (posicion < 0)
            {
                return "Posición inválida";
            }

            if (posicion == 0)
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
                if (UltimoNodo == null)
                {
                    UltimoNodo = nuevoNodo;
                }
                return "Nodo agregado en la posición 0";
            }

            Nodo actual = PrimerNodo;
            int contador = 0;
            while (actual != null && contador < posicion - 1)
            {
                actual = actual.Referencia;
                contador++;
            }

            if (actual == null)
            {
                return "Posición fuera de rango";
            }

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;

            if (nuevoNodo.Referencia == null)
            {
                UltimoNodo = nuevoNodo;
            }

            return "Nodo agregado en la posición " + posicion;
        }

        public string AgregarNodoAntesDePosicion(Nodo nuevoNodo, int posicion)
        {
            if (posicion < 0)
            {
                return "Posición inválida";
            }

            if (posicion == 0)
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
                if (UltimoNodo == null)
                {
                    UltimoNodo = nuevoNodo;
                }
                return "Nodo agregado antes de la posición 0";
            }

            Nodo actual = PrimerNodo;
            int contador = 0;
            while (actual != null && contador < posicion - 1)
            {
                actual = actual.Referencia;
                contador++;
            }

            if (actual == null || actual.Referencia == null)
            {
                return "Posición fuera de rango";
            }

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;
            return "Nodo agregado antes de la posición " + posicion;
        }

        public string AgregarNodoDespuesDePosicion(Nodo nuevoNodo, int posicion)
        {
            if (posicion < 0)
            {
                return "Posición inválida";
            }

            if (posicion == 0)
            {
                if (PrimerNodo != null)
                {
                    nuevoNodo.Referencia = PrimerNodo.Referencia;
                    PrimerNodo.Referencia = nuevoNodo;
                    if (nuevoNodo.Referencia == null)
                    {
                        UltimoNodo = nuevoNodo;
                    }
                    return "Nodo agregado después de la posición 0";
                }
                else
                {
                    return "La lista está vacía";
                }
            }

            Nodo actual = PrimerNodo;
            int contador = 0;
            while (actual != null && contador < posicion)
            {
                actual = actual.Referencia;
                contador++;
            }

            if (actual == null)
            {
                return "Posición fuera de rango";
            }

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;

            if (nuevoNodo.Referencia == null)
            {
                UltimoNodo = nuevoNodo;
            }

            return "Nodo agregado después de la posición " + posicion;
        }

        public Nodo BuscarElementoPorPosicion(int posicion)
        {
            if (posicion < 0)
            {
                return null;
            }

            Nodo actual = PrimerNodo;
            int contador = 0;

            while (actual != null && contador < posicion)
            {
                actual = actual.Referencia;
                contador++;
            }

            return actual; 
        }

        public List<string> RecorridoRecursivo(Nodo nodo, List<string> resultado)
        {
            if (nodo != null)
            {
                resultado.Add(nodo.Informacion); 
                RecorridoRecursivo(nodo.Referencia, resultado);
            }
            return resultado;
        }
    }
}