
using System;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using System.Collections.Generic;

using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;

namespace RentACarREST_REST.CAD
{
public class LineaFacturaRESTCAD : LineaFacturaRepository
{
public LineaFacturaRESTCAD()
        : base ()
{
}

public LineaFacturaRESTCAD(GenericSessionCP sessionAux)
        : base (sessionAux)
{
}
}
}
