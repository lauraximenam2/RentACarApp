using System;
using System.Runtime.Serialization;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;

namespace RentACarREST_REST.DTO
{
public partial class FacturaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}
private bool esPagada;
public bool EsPagada {
        get { return esPagada; } set { esPagada = value;  }
}
private bool esAnulada;
public bool EsAnulada {
        get { return esAnulada; } set { esAnulada = value;  }
}


private string cliente_oid;
public string Cliente_oid {
        get { return cliente_oid; } set { cliente_oid = value;  }
}

private System.Collections.Generic.IList<LineaFacturaDTO> lineaFactura;
public System.Collections.Generic.IList<LineaFacturaDTO> LineaFactura {
        get { return lineaFactura; } set { lineaFactura = value;  }
}
}
}
