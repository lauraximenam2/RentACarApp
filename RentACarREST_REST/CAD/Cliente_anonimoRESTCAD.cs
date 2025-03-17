
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
public class Cliente_anonimoRESTCAD : ClienteRepository
{
public Cliente_anonimoRESTCAD()
        : base ()
{
}

public Cliente_anonimoRESTCAD(GenericSessionCP sessionAux)
        : base (sessionAux)
{
}



public IList<FacturaEN> Facturas (string DNI)
{
        IList<FacturaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM FacturaNH self inner join self.Cliente as target with target.DNI=:p_DNI";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_DNI", DNI);




                result = query.List<FacturaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException) throw;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<ReservaEN> DameReservas (string DNI)
{
        IList<ReservaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM ReservaNH self inner join self.Cliente as target with target.DNI=:p_DNI";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_DNI", DNI);




                result = query.List<ReservaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException) throw;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
