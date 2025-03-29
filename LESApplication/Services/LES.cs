using LESApplication.Models;
using System.Collections.Generic;
namespace LESApplication.Services
{
    namespace LESApplication.Services
    {
        public class LESService
        {
            public Nodo PrimerNodo { get; set; }
            public Nodo UltimoNodo { get; set; }
            public string Mensaje { get; set; }

            public LESService()
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }

        }
    }
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
        bool EsValorValido(Nodo nodo)
        {
            return nodo.Dato != 0;
        }
        public string AgregarNodoFinal(Nodo nuevoNodo)
        {
            if (!EsValorValido(nuevoNodo))
            {
                return "Error: El valor del nodo está vacío o no es válido.";
            }
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
            if (!EsValorValido(nuevoNodo))
            {
                return "Error: El valor del nodo está vacío o no es válido.";
            }
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
            if (!EsValorValido(nuevoNodo))
            {
                return "Error: El valor del nodo está vacío o no es válido.";
            }
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
            if (!EsValorValido(nuevoNodo))
            {
                return "Error: El valor del nodo está vacío o no es válido.";
            }
            if (posicion <= 0) 
            {
                return "Error: No existe posición antes de la posición 0";
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
        public string AgregarNodoDespuesDePosicion(Nodo nuevoNodo, int
       posicion)
        {
            if (!EsValorValido(nuevoNodo))
            {
                return "Error: El valor del nodo está vacío o no es válido.";
            }
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
        public List<string> RecorridoRecursivo(Nodo nodo, List<string>
       resultado)
        {
            if (nodo != null)
            {
                resultado.Add(nodo.Informacion);
                RecorridoRecursivo(nodo.Referencia, resultado);
            }
            return resultado;
        }

        public string EliminarNodoInicio()
        {
            if (EstaVacia())
            {
                return "La lista está vacía";
            }

            PrimerNodo = PrimerNodo.Referencia;
            if (PrimerNodo == null)
            {
                UltimoNodo = null;
            }
            return "Nodo eliminado al inicio de la lista";
        }

        public string EliminarNodoFinal()
        {
            if (EstaVacia())
            {
                return "La lista está vacía";
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
                return "Nodo eliminado al final de la lista";
            }

            Nodo actual = PrimerNodo;
            while (actual.Referencia != UltimoNodo)
            {
                actual = actual.Referencia;
            }

            actual.Referencia = null;
            UltimoNodo = actual;
            return "Nodo eliminado al final de la lista";
        }

        public string EliminarNodoAntesDe(int datoX)
        {
            if (EstaVacia())
            {
                return "La lista está vacía";
            }

            if (PrimerNodo.Dato == datoX)
            {
                return "No hay nodo antes del primer elemento";
            }

            if (PrimerNodo.Referencia != null && PrimerNodo.Referencia.Dato == datoX)
            {
                PrimerNodo = PrimerNodo.Referencia;
                if (PrimerNodo == null)
                {
                    UltimoNodo = null;
                }
                return "Nodo eliminado antes del dato " + datoX;
            }

            Nodo actual = PrimerNodo;
            while (actual.Referencia != null && actual.Referencia.Referencia != null)
            {
                if (actual.Referencia.Referencia.Dato == datoX)
                {
                    actual.Referencia = actual.Referencia.Referencia;
                    return "Nodo eliminado antes del dato " + datoX;
                }
                actual = actual.Referencia;
            }

            return "Dato " + datoX + " no encontrado o no tiene nodo anterior";
        }

        public string EliminarNodoDespuesDe(int datoX)
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
                    if (actual.Referencia == null)
                    {
                        return "No hay nodo después del dato " + datoX;
                    }

                    actual.Referencia = actual.Referencia.Referencia;

                    if (actual.Referencia == null)
                    {
                        UltimoNodo = actual;
                    }
                    return "Nodo eliminado después del dato " + datoX;
                }
                actual = actual.Referencia;
            }

            return "Dato " + datoX + " no encontrado en la lista";
        }

        public string EliminarNodoEnPosicion(int posicion)
        {
            if (EstaVacia())
            {
                return "La lista está vacía";
            }

            if (posicion < 0)
            {
                return "Posición inválida";
            }

            if (posicion == 0)
            {
                PrimerNodo = PrimerNodo.Referencia;
                if (PrimerNodo == null)
                {
                    UltimoNodo = null;
                }
                return "Nodo eliminado en la posición 0";
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

            actual.Referencia = actual.Referencia.Referencia;

            if (actual.Referencia == null)
            {
                UltimoNodo = actual;
            }

            return "Nodo eliminado en la posición " + posicion;
        }

        // Método de ordenamiento (burbuja)
        public string OrdenarLista()
        {
            if (EstaVacia())
            {
                return "La lista está vacía";
            }

            bool huboCambios;
            do
            {
                huboCambios = false;
                Nodo anterior = null;
                Nodo actual = PrimerNodo;

                while (actual != null && actual.Referencia != null)
                {
                    if (actual.Dato > actual.Referencia.Dato)
                    {
                       
                        Nodo temp = actual.Referencia;
                        actual.Referencia = temp.Referencia;
                        temp.Referencia = actual;

                        if (anterior == null)
                        {
                            PrimerNodo = temp;
                        }
                        else
                        {
                            anterior.Referencia = temp;
                        }

                        if (actual.Referencia == null)
                        {
                            UltimoNodo = actual;
                        }

                        huboCambios = true;
                    }

                    anterior = actual;
                    actual = actual.Referencia;
                }
            } while (huboCambios);

            return "Lista ordenada correctamente";
        }
    }
}

