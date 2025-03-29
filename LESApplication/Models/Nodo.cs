namespace LESApplication.Models
{
    public class Nodo
    {
        public int Dato { get; set; }
        public string Informacion { get; set; }
        public Nodo Referencia { get; set; }
        public Nodo(string informacion)
        {
            Informacion = informacion;
            if (int.TryParse(informacion, out int dato))
            {
                Dato = dato;
            }
            else
            {
                Dato = 0;
            }
            Referencia = null;
        }
    }
}
