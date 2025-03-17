
using System;
using System.Text;
using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.Exceptions;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;


/*PROTECTED REGION ID(usingRentACarRESTGen.ApplicationCore.CEN.RentACarREST_Factura_anularFactura) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace RentACarRESTGen.ApplicationCore.CEN.RentACarREST
{
public partial class FacturaCEN
{
public void AnularFactura (int p_oid)
{
        /*PROTECTED REGION ID(RentACarRESTGen.ApplicationCore.CEN.RentACarREST_Factura_anularFactura) ENABLED START*/

        // Write here your custom code...

        FacturaEN en = get_IFacturaRepository ().ReadOIDDefault (p_oid);

        if (!(en.EsAnulada == true))
                throw new ModelException ("La factura no puede estar anulada para anularla");

        en.EsAnulada = true;

        get_IFacturaRepository ().ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
