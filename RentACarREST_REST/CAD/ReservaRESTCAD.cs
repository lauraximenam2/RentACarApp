
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
public class ReservaRESTCAD : ReservaRepository
{
public ReservaRESTCAD()
        : base ()
{
}

public ReservaRESTCAD(GenericSessionCP sessionAux)
        : base (sessionAux)
{
}



public CocheEN Coches (int id)
{
        CocheEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Coche FROM ReservaNH self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<CocheEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException) throw;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
