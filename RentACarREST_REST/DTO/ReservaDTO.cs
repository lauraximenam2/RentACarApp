using System;
using System.Runtime.Serialization;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;

namespace RentACarREST_REST.DTO
{
public partial class ReservaDTO
{
private string cliente_oid;
public string Cliente_oid {
        get { return cliente_oid; } set { cliente_oid = value;  }
}

private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private int coche_oid;
public int Coche_oid {
        get { return coche_oid; } set { coche_oid = value;  }
}



private int lineaFactura_oid;
public int LineaFactura_oid {
        get { return lineaFactura_oid; } set { lineaFactura_oid = value;  }
}

private Nullable<DateTime> inicio;
public Nullable<DateTime> Inicio {
        get { return inicio; } set { inicio = value;  }
}
private Nullable<DateTime> final;
public Nullable<DateTime> Final {
        get { return final; } set { final = value;  }
}
}
}
