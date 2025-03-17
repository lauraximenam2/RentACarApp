using System;
using System.Runtime.Serialization;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;

namespace RentACarREST_REST.DTO
{
public partial class LineaFacturaDTO
{
private int factura_oid;
public int Factura_oid {
        get { return factura_oid; } set { factura_oid = value;  }
}

private int numLinea;
public int NumLinea {
        get { return numLinea; } set { numLinea = value;  }
}


private int reserva_oid;
public int Reserva_oid {
        get { return reserva_oid; } set { reserva_oid = value;  }
}

private double precio;
public double Precio {
        get { return precio; } set { precio = value;  }
}
}
}
