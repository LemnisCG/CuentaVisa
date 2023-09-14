using System.ComponentModel.Design;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        //Llamar a la clasa CuentaVista
        //Crear un meno simulando un cajero automatico
        string menu = "\tBienvenido al cajero automatico Lemniscata\n\n";
        menu += "\tPor favor Selecciona Su Transacción\n";
        menu += "1.-Retirar monto\t\t\t4.-Cambiar clave\n";
        menu += "2.-Depositar monto\t\t\t5.-Salir\n";
        menu += "3.-Consultar saldo\n";
        CuentaVisa cuenta = new CuentaVisa();
        do
        {
            Console.WriteLine(menu);
            string menuOpciones =  Console.ReadLine();
            switch (menuOpciones)
            {
                case "1":
                    Console.Write("Ingresar monto a retirar: ");
                    int monto_a_retirar = Convert.ToInt32(Console.ReadLine());
                    cuenta.Retiro(monto_a_retirar);
                    Console.Write($"Acabas de retirar -{monto_a_retirar} de tu cuenta, ahora ");
                    Console.Write(cuenta.InfoSaldo()+ "\n\n\n") ;
                    break;
                case "2":
                    Console.Write("Ingresar el monto a depositar: ");
                    int depositarMonto = Convert.ToInt32(Console.ReadLine());
                    cuenta.Deposito(depositarMonto);
                    Console.Write($"Acabas de agregar {depositarMonto} a tu cuenta, ahora" + cuenta.InfoSaldo()+ "\n\n\n");
                    break;
                case "3":
                    Console.Write(cuenta.InfoSaldo());
                    break;
                case "4":
                    Console.Write("Ingrese su nueva clave");
                    int nuevaClave = Convert.ToInt32(Console.ReadLine());
                    if(nuevaClave == cuenta.Clave)
                    {
                        Console.WriteLine("NO PUEDES REPETIR LA MISMA CLAVE,INTENTA CON OTRA");
                    }
                    else{cuenta.Clave = nuevaClave; Console.WriteLine($"Su clave se cambio ah {nuevaClave}"); }
                    break;
                default:
                    return;
                




            }
        } while (true);
    }
}





class CuentaVisa
{   
    //Variables     
    private int clave;
    private int saldo;
    private string rut;

    //crear un constructor
    public CuentaVisa()
    {
        clave = 1515;
        saldo = 1000000;
        rut = "1-9";
    }
    // llamar a las propiedades get y set
    public int Clave { get{return clave;}  set{clave = value;} }
    public int Saldo { get{return saldo;}}
    public String Rut { get{return rut;}}

    public void Retiro(int retirarMonto)
    {
        saldo -= retirarMonto;
    }
    public void Deposito(int ingresarDeposito)
    {
        saldo += ingresarDeposito;
    }
    public string InfoSaldo ()
    {
        string mensaje = " tu saldo actual es de: " + saldo;
        return mensaje;
    }
}