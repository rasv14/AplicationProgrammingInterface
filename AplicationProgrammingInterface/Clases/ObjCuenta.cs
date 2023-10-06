namespace AplicationProgrammingInterface.Clases
{
    public class ObjCuenta
    {
        public int Numero { get; set; }

        public string Tipo { get; set; }

        public decimal SaldoInicial { get; set; } = 0;

        public bool Estado { get; set; }

        public Guid IdCliente { get; set; }



        public ObjCuenta() { }

      
    }
}
