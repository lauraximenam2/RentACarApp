using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace RentACarREST_REST.DTOA
{
public class CocheDTOA
{
private int numLicencia;
public int NumLicencia
{
        get { return numLicencia; }
        set { numLicencia = value; }
}

private RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.CategoriaCocheEnum categoria;
public RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.CategoriaCocheEnum Categoria
{
        get { return categoria; }
        set { categoria = value; }
}

private RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.EstadoCocheEnum estado;
public RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.EstadoCocheEnum Estado
{
        get { return estado; }
        set { estado = value; }
}
}
}
