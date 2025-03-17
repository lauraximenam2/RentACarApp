
using System;
// Definición clase CocheEN
namespace RentACarRESTGen.ApplicationCore.EN.RentACarREST
{
public partial class CocheEN
{
/**
 *	Atributo reserva
 */
private RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN reserva;



/**
 *	Atributo numLicencia
 */
private int numLicencia;



/**
 *	Atributo categoria
 */
private RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.CategoriaCocheEnum categoria;



/**
 *	Atributo estado
 */
private RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.EstadoCocheEnum estado;



/**
 *	Atributo proveedor
 */
private System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.ProveedorEN> proveedor;






public virtual RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN Reserva {
        get { return reserva; } set { reserva = value;  }
}



public virtual int NumLicencia {
        get { return numLicencia; } set { numLicencia = value;  }
}



public virtual RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.CategoriaCocheEnum Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.EstadoCocheEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.ProveedorEN> Proveedor {
        get { return proveedor; } set { proveedor = value;  }
}





public CocheEN()
{
        proveedor = new System.Collections.Generic.List<RentACarRESTGen.ApplicationCore.EN.RentACarREST.ProveedorEN>();
}



public CocheEN(int numLicencia, RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN reserva, RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.CategoriaCocheEnum categoria, RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.EstadoCocheEnum estado, System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.ProveedorEN> proveedor
               )
{
        this.init (NumLicencia, reserva, categoria, estado, proveedor);
}


public CocheEN(CocheEN coche)
{
        this.init (NumLicencia, coche.Reserva, coche.Categoria, coche.Estado, coche.Proveedor);
}

private void init (int numLicencia
                   , RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN reserva, RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.CategoriaCocheEnum categoria, RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.EstadoCocheEnum estado, System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.ProveedorEN> proveedor)
{
        this.NumLicencia = numLicencia;


        this.Reserva = reserva;

        this.Categoria = categoria;

        this.Estado = estado;

        this.Proveedor = proveedor;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CocheEN t = obj as CocheEN;
        if (t == null)
                return false;
        if (NumLicencia.Equals (t.NumLicencia))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.NumLicencia.GetHashCode ();
        return hash;
}
}
}
