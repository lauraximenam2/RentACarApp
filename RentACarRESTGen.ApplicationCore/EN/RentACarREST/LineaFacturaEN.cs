
using System;
// Definición clase LineaFacturaEN
namespace RentACarRESTGen.ApplicationCore.EN.RentACarREST
{
public partial class LineaFacturaEN
{
/**
 *	Atributo factura
 */
private RentACarRESTGen.ApplicationCore.EN.RentACarREST.FacturaEN factura;



/**
 *	Atributo numLinea
 */
private int numLinea;



/**
 *	Atributo reserva
 */
private RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN reserva;



/**
 *	Atributo precio
 */
private double precio;






public virtual RentACarRESTGen.ApplicationCore.EN.RentACarREST.FacturaEN Factura {
        get { return factura; } set { factura = value;  }
}



public virtual int NumLinea {
        get { return numLinea; } set { numLinea = value;  }
}



public virtual RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN Reserva {
        get { return reserva; } set { reserva = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}





public LineaFacturaEN()
{
}



public LineaFacturaEN(int numLinea, RentACarRESTGen.ApplicationCore.EN.RentACarREST.FacturaEN factura, RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN reserva, double precio
                      )
{
        this.init (NumLinea, factura, reserva, precio);
}


public LineaFacturaEN(LineaFacturaEN lineaFactura)
{
        this.init (NumLinea, lineaFactura.Factura, lineaFactura.Reserva, lineaFactura.Precio);
}

private void init (int numLinea
                   , RentACarRESTGen.ApplicationCore.EN.RentACarREST.FacturaEN factura, RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN reserva, double precio)
{
        this.NumLinea = numLinea;


        this.Factura = factura;

        this.Reserva = reserva;

        this.Precio = precio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaFacturaEN t = obj as LineaFacturaEN;
        if (t == null)
                return false;
        if (NumLinea.Equals (t.NumLinea))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.NumLinea.GetHashCode ();
        return hash;
}
}
}
