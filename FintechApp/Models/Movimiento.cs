namespace FintechApp.Models
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }


        //Constructor
        //Vacio
        public Movimiento() { }
        //parametrizado
        public Movimiento(string tipo, decimal monto)
        {
            Tipo = tipo;
            Monto = monto;
            Fecha = DateTime.Now;
        }
    }
}
