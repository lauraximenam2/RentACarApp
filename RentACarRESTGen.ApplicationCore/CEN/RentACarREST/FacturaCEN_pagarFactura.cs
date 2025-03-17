
using System;
using System.Text;
using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.Exceptions;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;


/*PROTECTED REGION ID(usingRentACarRESTGen.ApplicationCore.CEN.RentACarREST_Factura_pagarFactura) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace RentACarRESTGen.ApplicationCore.CEN.RentACarREST
{
public partial class FacturaCEN
{
public void PagarFactura (int p_oid)
{
        /*PROTECTED REGION ID(RentACarRESTGen.ApplicationCore.CEN.RentACarREST_Factura_pagarFactura) ENABLED START*/

        // Write here your custom code...

        FacturaEN en = get_IFacturaRepository ().ReadOIDDefault (p_oid);

        if (!(en.EsPagada == true))
                throw new ModelException ("La factura no puede estar pagada para pagarla");

        en.EsPagada = true;

        get_IFacturaRepository ().ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
