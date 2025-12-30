using FintechApp.Models;

public class Cuenta
{
    public string CodigoCuenta { get; set; }
    public decimal Saldo { get; private set; }
    public string EmailCliente { get; set; }

    public List<Movimiento> Movimientos { get; set; } = new();

    // 👇 CONSTRUCTOR
    public Cuenta(decimal saldoInicial)
    {
        if (saldoInicial < 0)
            throw new ArgumentException("Saldo inicial inválido");

        Saldo = saldoInicial;
    }

    public void Depositar(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentException("Monto inválido");

        Saldo += monto;
        Movimientos.Add(new Movimiento("Depósito", monto));
    }

    public bool Retirar(decimal monto)
    {
        if (monto <= 0 || monto > Saldo)
            return false;

        Saldo -= monto;
        Movimientos.Add(new Movimiento("Retiro", monto));
        return true;
    }
}



//namespace FintechApp.Models
//{
//    public class Cuenta
//    {
//        public string CodigoCuenta { get; set; }
//        /// <summary>
//        ///public decimal Saldo { get; private set; } //?
//        public decimal Saldo { get; set; } //?
//        /// </summary>

//        public int ClienteId { get; set; }
//        public Cliente Cliente { get; set; }
//        public string EmailCliente {  get; set; }

//        public List<Movimiento> Movimientos { get; set; } = new(); //?


//        //Métodos
//        public void Depositar(decimal monto)
//        {
//            if (monto <= 0)
//                throw new ArgumentException("Monto inválido");

//            Saldo += monto;
//            Movimientos.Add(new Movimiento("Depósito", monto)); //?
//        }

//        public bool Retirar(decimal monto)
//        {
//            if(monto <= 0 || monto > Saldo)
//                return false; 

//            Saldo -= monto;
//            Movimientos.Add(new Movimiento("Retiro", monto)); //?
//            return true;
//        }

//    }
//}
