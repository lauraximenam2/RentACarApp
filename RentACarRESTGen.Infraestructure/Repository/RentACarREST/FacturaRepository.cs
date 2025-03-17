
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
using System.Collections.Generic;


/*
 * Clase Factura:
 *
 */

namespace RentACarRESTGen.Infraestructure.Repository.RentACarREST
{
public partial class FacturaRepository : BasicRepository, IFacturaRepository
{
public FacturaRepository() : base ()
{
}


public FacturaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FacturaEN ReadOIDDefault (int id
                                 )
{
        FacturaEN facturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                facturaEN = (FacturaEN)session.Get (typeof(FacturaNH), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return facturaEN;
}

public System.Collections.Generic.IList<FacturaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FacturaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FacturaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FacturaEN>();
                        else
                                result = session.CreateCriteria (typeof(FacturaNH)).List<FacturaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FacturaEN factura)
{
        try
        {
                SessionInitializeTransaction ();
                FacturaNH facturaNH = (FacturaNH)session.Load (typeof(FacturaNH), factura.Id);

                facturaNH.Fecha = factura.Fecha;


                facturaNH.EsPagada = factura.EsPagada;


                facturaNH.EsAnulada = factura.EsAnulada;



                session.Update (facturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearFactura (FacturaEN factura)
{
        FacturaNH facturaNH = new FacturaNH (factura);

        try
        {
                SessionInitializeTransaction ();
                if (factura.Cliente != null) {
                        // Argumento OID y no colección.
                        facturaNH
                        .Cliente = (RentACarRESTGen.ApplicationCore.EN.RentACarREST.ClienteEN)session.Load (typeof(RentACarRESTGen.ApplicationCore.EN.RentACarREST.ClienteEN), factura.Cliente.DNI);

                        facturaNH.Cliente.Factura
                        .Add (facturaNH);
                }

                session.Save (facturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return facturaNH.Id;
}

public void Modificar (FacturaEN factura)
{
        try
        {
                SessionInitializeTransaction ();
                FacturaNH facturaNH = (FacturaNH)session.Load (typeof(FacturaNH), factura.Id);

                facturaNH.Fecha = factura.Fecha;


                facturaNH.EsPagada = factura.EsPagada;


                facturaNH.EsAnulada = factura.EsAnulada;

                session.Update (facturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

        //Implementación del método ObtenerFacturasPorCliente
        public IList<FacturaEN> ObtenerFacturasPorCliente(string clienteDNI)
        {
            IList<FacturaEN> facturas = null;

            try
            {
                SessionInitializeTransaction();

                facturas = session.QueryOver<FacturaNH>()
                    .Where(f => f.Cliente.DNI == clienteDNI)
                    .List<FacturaEN>();

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ModelException) throw ex;
                throw new DataLayerException("Error en FacturaRepository.ObtenerFacturasPorCliente", ex);
            }
            finally
            {
                SessionClose();
            }

            return facturas;
        }

        //Implementación del método ObtenerFacturaPorId
        public FacturaEN ObtenerFacturaPorId(int id)
        {
            FacturaEN factura = null;
            try
            {
                SessionInitializeTransaction();
                factura = session.Get<FacturaNH>(id);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ModelException) throw ex;
                throw new DataLayerException("Error en FacturaRepository.ObtenerFacturaPorId", ex);
            }
            finally
            {
                SessionClose();
            }
            return factura;
        }
    }
}


