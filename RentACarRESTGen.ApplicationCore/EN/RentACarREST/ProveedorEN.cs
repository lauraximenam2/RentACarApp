
using System;
// Definición clase ProveedorEN
namespace RentACarRESTGen.ApplicationCore.EN.RentACarREST
{
public partial class ProveedorEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo coche
 */
private System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN> coche;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN> Coche {
        get { return coche; } set { coche = value;  }
}





public ProveedorEN()
{
        coche = new System.Collections.Generic.List<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN>();
}



public ProveedorEN(int id, System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN> coche
                   )
{
        this.init (Id, coche);
}


public ProveedorEN(ProveedorEN proveedor)
{
        this.init (Id, proveedor.Coche);
}

private void init (int id
                   , System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN> coche)
{
        this.Id = id;


        this.Coche = coche;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProveedorEN t = obj as ProveedorEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
