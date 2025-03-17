using System;
using System.Runtime.Serialization;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;

namespace RentACarREST_REST.DTO
{
public partial class ProveedorDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private System.Collections.Generic.IList<int> coche_oid;
public System.Collections.Generic.IList<int> Coche_oid {
        get { return coche_oid; } set { coche_oid = value;  }
}
}
}
