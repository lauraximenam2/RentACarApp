
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
public class CocheRESTCAD : CocheRepository
{
public CocheRESTCAD()
        : base ()
{
}

public CocheRESTCAD(GenericSessionCP sessionAux)
        : base (sessionAux)
{
}
}
}
