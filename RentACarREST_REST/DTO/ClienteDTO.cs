using System;
using System.Runtime.Serialization;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;

namespace RentACarREST_REST.DTO
{
public partial class ClienteDTO
{
private string dNI;
public string DNI {
        get { return dNI; } set { dNI = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string direccion;
public string Direccion {
        get { return direccion; } set { direccion = value;  }
}
private string telefono;
public string Telefono {
        get { return telefono; } set { telefono = value;  }
}


private System.Collections.Generic.IList<int> factura_oid;
public System.Collections.Generic.IList<int> Factura_oid {
        get { return factura_oid; } set { factura_oid = value;  }
}



private System.Collections.Generic.IList<int> reserva_oid;
public System.Collections.Generic.IList<int> Reserva_oid {
        get { return reserva_oid; } set { reserva_oid = value;  }
}

private String pass;
public String Pass {
        get { return pass; } set { pass = value;  }
}
}
}
