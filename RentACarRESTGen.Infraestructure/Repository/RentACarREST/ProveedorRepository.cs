
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
 * Clase Proveedor:
 *
 */

namespace RentACarRESTGen.Infraestructure.Repository.RentACarREST
{
public partial class ProveedorRepository : BasicRepository, IProveedorRepository
{
public ProveedorRepository() : base ()
{
}


public ProveedorRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ProveedorEN ReadOIDDefault (int id
                                   )
{
        ProveedorEN proveedorEN = null;

        try
        {
                SessionInitializeTransaction ();
                proveedorEN = (ProveedorEN)session.Get (typeof(ProveedorNH), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProveedorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proveedorEN;
}

public System.Collections.Generic.IList<ProveedorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProveedorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProveedorNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProveedorEN>();
                        else
                                result = session.CreateCriteria (typeof(ProveedorNH)).List<ProveedorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProveedorRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProveedorEN proveedor)
{
        try
        {
                SessionInitializeTransaction ();
                ProveedorNH proveedorNH = (ProveedorNH)session.Load (typeof(ProveedorNH), proveedor.Id);

                session.Update (proveedorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProveedorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ProveedorEN proveedor)
{
        ProveedorNH proveedorNH = new ProveedorNH (proveedor);

        try
        {
                SessionInitializeTransaction ();

                session.Save (proveedorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProveedorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proveedorNH.Id;
}

public void Modify (ProveedorEN proveedor)
{
        try
        {
                SessionInitializeTransaction ();
                ProveedorNH proveedorNH = (ProveedorNH)session.Load (typeof(ProveedorNH), proveedor.Id);
                session.Update (proveedorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProveedorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ProveedorNH proveedorNH = (ProveedorNH)session.Load (typeof(ProveedorNH), id);
                session.Delete (proveedorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProveedorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarCoche (int p_Proveedor_OID, System.Collections.Generic.IList<int> p_coche_OIDs)
{
        RentACarRESTGen.ApplicationCore.EN.RentACarREST.ProveedorEN proveedorEN = null;
        try
        {
                SessionInitializeTransaction ();
                proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorNH), p_Proveedor_OID);
                RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN cocheENAux = null;
                if (proveedorEN.Coche == null) {
                        proveedorEN.Coche = new System.Collections.Generic.List<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN>();
                }

                foreach (int item in p_coche_OIDs) {
                        cocheENAux = new RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN ();
                        cocheENAux = (RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN)session.Load (typeof(RentACarRESTGen.Infraestructure.EN.RentACarREST.CocheNH), item);
                        cocheENAux.Proveedor.Add (proveedorEN);

                        proveedorEN.Coche.Add (cocheENAux);
                }


                session.Update (proveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProveedorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
