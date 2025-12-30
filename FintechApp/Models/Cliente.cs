namespace FintechApp.Models
{
    public class Cliente
    {
        public int IdCliente {  get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Cuenta> Cuentas { get; set; } = new(); //

        //Métodos


    }
}
