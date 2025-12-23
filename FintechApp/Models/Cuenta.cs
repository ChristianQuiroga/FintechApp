namespace FintechApp.Models
{
    public class Cuenta
    {
        public string CodigoCuenta { get; set; }
        public decimal Saldo { get; private set; } //?
        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public List<Movimiento> Movimientos { get; set; } = new(); //?
        //Método
        public void Depositar(decimal monto)
        {
            if (monto <= 0)
                throw new ArgumentException("Monto inválido");

            Saldo += monto;
            Movimientos.Add(new Movimiento("Depósito", monto)); //?
        }

        public bool Retirar(decimal monto)
        {
            if(monto <= 0 || monto > Saldo)
                return false; 

            Saldo -= monto;
            Movimientos.Add(new Movimiento("Retiro", monto)); //?
            return true;
        }

    }
}
