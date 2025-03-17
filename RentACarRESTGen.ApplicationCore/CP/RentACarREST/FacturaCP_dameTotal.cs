
using System;
using System.Text;

using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.Exceptions;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;
using RentACarRESTGen.ApplicationCore.CEN.RentACarREST;



/*PROTECTED REGION ID(usingRentACarRESTGen.ApplicationCore.CP.RentACarREST_Factura_dameTotal) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace RentACarRESTGen.ApplicationCore.CP.RentACarREST
{
public partial class FacturaCP : GenericBasicCP
{
public double DameTotal (int p_oid)
{
        /*PROTECTED REGION ID(RentACarRESTGen.ApplicationCore.CP.RentACarREST_Factura_dameTotal) ENABLED START*/

        FacturaCEN facturaCEN = null;

        double result = 0;


        try
        {
                CPSession.SessionInitializeTransaction ();
                facturaCEN = new  FacturaCEN (unitRepo.facturarepository);



                // Write here your custom transaction ...
                FacturaEN factura = facturaCEN.get_IFacturaRepository ().ReadOIDDefault (p_oid);
                foreach (LineaFacturaEN linea in factura.LineaFactura) {
                        result += linea.Precio;
                }


                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
