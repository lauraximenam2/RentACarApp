
using System;
using System.Text;
using RentACarRESTGen.ApplicationCore.CEN.RentACarREST;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.Exceptions;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;
using RentACarRESTGen.Infraestructure.EN.RentACarREST;


/*
 * Clase Reserva:
 *
 */

namespace RentACarRESTGen.Infraestructure.Repository.RentACarREST
{
public partial class ReservaRepository : BasicRepository, IReservaRepository
{
public ReservaRepository() : base ()
{
}


public ReservaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ReservaEN ReadOIDDefault (int id
                                 )
{
        ReservaEN reservaEN = null;

        try
        {
                SessionInitializeTransaction ();
                reservaEN = (ReservaEN)session.Get (typeof(ReservaNH), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reservaEN;
}

public System.Collections.Generic.IList<ReservaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ReservaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ReservaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ReservaEN>();
                        else
                                result = session.CreateCriteria (typeof(ReservaNH)).List<ReservaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ReservaEN reserva)
{
        try
        {
                SessionInitializeTransaction ();
                ReservaNH reservaNH = (ReservaNH)session.Load (typeof(ReservaNH), reserva.Id);




                reservaNH.Inicio = reserva.Inicio;


                reservaNH.Final = reserva.Final;

                session.Update (reservaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearReserva (ReservaEN reserva)
{
        ReservaNH reservaNH = new ReservaNH (reserva);

        try
        {
                SessionInitializeTransaction ();
                if (reserva.Cliente != null) {
                        // Argumento OID y no colección.
                        reservaNH
                        .Cliente = (RentACarRESTGen.ApplicationCore.EN.RentACarREST.ClienteEN)session.Load (typeof(RentACarRESTGen.ApplicationCore.EN.RentACarREST.ClienteEN), reserva.Cliente.DNI);

                        reservaNH.Cliente.Reserva
                        .Add (reservaNH);
                }

                session.Save (reservaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reservaNH.Id;
}

public void BorrarReserva (int id
                           )
{
        try
        {
                SessionInitializeTransaction ();
                ReservaNH reservaNH = (ReservaNH)session.Load (typeof(ReservaNH), id);
                session.Delete (reservaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarCoche (int p_Reserva_OID, string p_cliente_OID)
{
        RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN reservaEN = null;
        try
        {
                SessionInitializeTransaction ();
                reservaEN = (ReservaEN)session.Load (typeof(ReservaNH), p_Reserva_OID);
                reservaEN.Cliente = (RentACarRESTGen.ApplicationCore.EN.RentACarREST.ClienteEN)session.Load (typeof(RentACarRESTGen.Infraestructure.EN.RentACarREST.ClienteNH), p_cliente_OID);

                reservaEN.Cliente.Reserva.Add (reservaEN);



                session.Update (reservaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
