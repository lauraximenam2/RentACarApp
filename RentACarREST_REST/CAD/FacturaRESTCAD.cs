
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
public class FacturaRESTCAD : FacturaRepository
{
public FacturaRESTCAD()
        : base ()
{
}

public FacturaRESTCAD(GenericSessionCP sessionAux)
        : base (sessionAux)
{
}



public IList<LineaFacturaEN> Lineas (int id)
{
        IList<LineaFacturaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaFacturaNH self inner join self.Factura as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaFacturaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException) throw;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
