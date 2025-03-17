
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
 * Clase LineaFactura:
 *
 */

namespace RentACarRESTGen.Infraestructure.Repository.RentACarREST
{
public partial class LineaFacturaRepository : BasicRepository, ILineaFacturaRepository
{
public LineaFacturaRepository() : base ()
{
}


public LineaFacturaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public LineaFacturaEN ReadOIDDefault (int numLinea
                                      )
{
        LineaFacturaEN lineaFacturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaFacturaEN = (LineaFacturaEN)session.Get (typeof(LineaFacturaNH), numLinea);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaFacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaFacturaEN;
}

public System.Collections.Generic.IList<LineaFacturaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaFacturaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaFacturaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaFacturaEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaFacturaNH)).List<LineaFacturaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaFacturaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaFacturaEN lineaFactura)
{
        try
        {
                SessionInitializeTransaction ();
                LineaFacturaNH lineaFacturaNH = (LineaFacturaNH)session.Load (typeof(LineaFacturaNH), lineaFactura.NumLinea);



                lineaFacturaNH.Precio = lineaFactura.Precio;

                session.Update (lineaFacturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaFacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearLinea (LineaFacturaEN lineaFactura)
{
        LineaFacturaNH lineaFacturaNH = new LineaFacturaNH (lineaFactura);

        try
        {
                SessionInitializeTransaction ();
                if (lineaFactura.Factura != null) {
                        // Argumento OID y no colección.
                        lineaFacturaNH
                        .Factura = (RentACarRESTGen.ApplicationCore.EN.RentACarREST.FacturaEN)session.Load (typeof(RentACarRESTGen.ApplicationCore.EN.RentACarREST.FacturaEN), lineaFactura.Factura.Id);

                        lineaFacturaNH.Factura.LineaFactura
                        .Add (lineaFacturaNH);
                }
                if (lineaFactura.Reserva != null) {
                        // Argumento OID y no colección.
                        lineaFacturaNH
                        .Reserva = (RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN)session.Load (typeof(RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN), lineaFactura.Reserva.Id);

                        lineaFacturaNH.Reserva.LineaFactura
                                = lineaFacturaNH;
                }

                session.Save (lineaFacturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarRESTGen.ApplicationCore.Exceptions.ModelException)
                        throw ex;
                throw new RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaFacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaFacturaNH.NumLinea;
}
}
}
