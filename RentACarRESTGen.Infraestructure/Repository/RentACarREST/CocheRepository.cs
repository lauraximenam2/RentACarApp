
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
 * Clase Coche:
 *
 */

namespace RentACarRESTGen.Infraestructure.Repository.RentACarREST
{
public partial class CocheRepository : BasicRepository, ICocheRepository
{
public CocheRepository() : base ()
{
}


public CocheRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public CocheEN ReadOIDDefault (int numLicencia
                               )
{
        CocheEN cocheEN = null;

        try
        {
                SessionInitializeTransaction ();
                cocheEN = (CocheEN)session.Get (typeof(CocheNH), numLicencia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cocheEN;
}

public System.Collections.Generic.IList<CocheEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CocheEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CocheNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<CocheEN>();
                        else
                                result = session.CreateCriteria (typeof(CocheNH)).List<CocheEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), coche.NumLicencia);


                cocheNH.Categoria = coche.Categoria;


                cocheNH.Estado = coche.Estado;


                session.Update (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearCoche (CocheEN coche)
{
        CocheNH cocheNH = new CocheNH (coche);

        try
        {
                SessionInitializeTransaction ();

                session.Save (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cocheNH.NumLicencia;
}

public void BorrarCoche (int numLicencia
                         )
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), numLicencia);
                session.Delete (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN cocheEN = null;
        try
        {
                SessionInitializeTransaction ();
                cocheEN = (CocheEN)session.Load (typeof(CocheNH), p_Coche_OID);
                cocheEN.Reserva = (RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN)session.Load (typeof(RentACarRESTGen.Infraestructure.EN.RentACarREST.ReservaNH), p_reserva_OID);

                cocheEN.Reserva.Coche = cocheEN;




                session.Update (cocheEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        try
        {
                SessionInitializeTransaction ();
                RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN cocheEN = null;
                cocheEN = (CocheEN)session.Load (typeof(CocheNH), p_Coche_OID);

                if (cocheEN.Reserva.Id == p_reserva_OID) {
                        cocheEN.Reserva = null;
                        RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN reservaEN = (RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN)session.Load (typeof(RentACarRESTGen.Infraestructure.EN.RentACarREST.ReservaNH), p_reserva_OID);
                        reservaEN.Coche = null;
                }
                else
                        throw new ModelException ("The identifier " + p_reserva_OID + " in p_reserva_OID you are trying to unrelationer, doesn't exist in CocheEN");

                session.Update (cocheEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Modificar (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), coche.NumLicencia);

                cocheNH.Categoria = coche.Categoria;


                cocheNH.Estado = coche.Estado;

                session.Update (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN> DameCochesDisponibles (int first, int size)
{
        System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CocheNH self where FROM CocheNH coche where coche.Reserva is empty";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CocheNHdameCochesDisponiblesHQL");

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
