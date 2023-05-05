
var cuenta1 = new CajaAhorro("123456",Cuenta.eTipoCuenta.CajaAhorro,10000);

var cuenta2 = new CuentaCorriente("222555",Cuenta.eTipoCuenta.CuentaCorriente,15000);

var cuenta3 = new CuentaSueldo("4455",Cuenta.eTipoCuenta.CuentaSueldo,2500);

var cliente1= new Cliente("rsmeagol");
var cliente2= new Cliente("Legolas1");

cliente1.AgregarCuentas(cuenta1);
cliente1.AgregarCuentas(cuenta2);
cliente2.AgregarCuentas(cuenta3);
cliente1.CambiarClave("Nueva Clave");


Console.WriteLine(cliente1.Usuario);
Console.WriteLine(cliente1.Clave);
cliente1.CambiarClave("Cambie la Clave");
Console.WriteLine(cliente1.cantidadCuentas);
Console.WriteLine(cliente1.Clave);
Console.WriteLine(cliente2.Usuario);
Console.WriteLine(cliente2.cantidadCuentas);
Console.WriteLine(cuenta1.Numero);
cuenta1.CobrarMantenimiento(1000);






public abstract class Cuenta
{
    public Cuenta(string numeroCuenta, eTipoCuenta tipocuenta, double saldo){
        Numero = numeroCuenta;
        TipoCuenta = tipocuenta;
        Saldo = saldo;
    }
    
    public string Numero{get;}
    public enum eTipoCuenta{
        CajaAhorro,
        CuentaCorriente,
        CuentaSueldo
    }
    public eTipoCuenta TipoCuenta{get;}
    public double Saldo{get;}

    public abstract void CobrarMantenimiento(double mantenimiento);
    
    

}

public class CajaAhorro:Cuenta{
public CajaAhorro(string numeroCuenta, eTipoCuenta tipocuenta, double saldo):base(numeroCuenta,tipocuenta,saldo){

}
public override void CobrarMantenimiento(double mantenimiento){
    double Descubierto = 0;
    if(this.Saldo <= mantenimiento){
        Descubierto = this.Saldo - mantenimiento;
        Console.WriteLine($"Verificar Descubierto {Descubierto}");
    }
    else
    {
        
    }
}
}

public class CuentaCorriente:Cuenta{
public CuentaCorriente(string numeroCuenta, eTipoCuenta tipocuenta, double saldo):base(numeroCuenta,tipocuenta,saldo){
    
}
public override void CobrarMantenimiento(double mantenimiento){
    
}
}

public class CuentaSueldo:Cuenta{
public CuentaSueldo(string numeroCuenta, eTipoCuenta tipocuenta, double saldo):base(numeroCuenta,tipocuenta,saldo){
    
}
public override void CobrarMantenimiento(double mantenimiento){
    
}
}

public class Cliente
{
    private List<Cuenta> Cuentas;

    public Cliente(string usuario){
        Usuario=usuario;
    }
    public string Nombre{get;set;}
    public string Apellido{get;set;}
    public string Usuario{get;}
    public string Clave{get; private set;}
    public double LimiteCredito{get;set;}

    public int cantidadCuentas{
        get{
            var cuentasTotal =0;
                foreach(var cuenta in Cuentas)
                {
                    cuentasTotal++;
                }
            return cuentasTotal;
        }
    }
    
    
    public void CambiarClave(string ClaveNueva){
        this.Clave=ClaveNueva;
    }

    public void AgregarCuentas(Cuenta cuenta){
        if (Cuentas is null)
        Cuentas = new List<Cuenta>();
        Cuentas.Add(cuenta);
    }

}

public class Movimiento
{
    public DateTime Fecha{get;set;}
    public int Monto{get;set;}
    public enum eTipoMovimiento{
        Debito,
        Credito
    }

}