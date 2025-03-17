using System;
using System.Runtime.Serialization;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;

namespace RentACarREST_REST.DTO
{
public partial class CocheDTO
{
private int reserva_oid;
public int Reserva_oid {
        get { return reserva_oid; } set { reserva_oid = value;  }
}

private int numLicencia;
public int NumLicencia {
        get { return numLicencia; } set { numLicencia = value;  }
}
private RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.CategoriaCocheEnum categoria;
public RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.CategoriaCocheEnum Categoria {
        get { return categoria; } set { categoria = value;  }
}
private RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.EstadoCocheEnum estado;
public RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.EstadoCocheEnum Estado {
        get { return estado; } set { estado = value;  }
}


private System.Collections.Generic.IList<int> proveedor_oid;
public System.Collections.Generic.IList<int> Proveedor_oid {
        get { return proveedor_oid; } set { proveedor_oid = value;  }
}
}
}
