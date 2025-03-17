
using System;
using System.Text;
using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.Exceptions;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;


/*PROTECTED REGION ID(usingRentACarRESTGen.ApplicationCore.CEN.RentACarREST_Coche_desreservar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace RentACarRESTGen.ApplicationCore.CEN.RentACarREST
{
public partial class CocheCEN
{
public void Desreservar (int p_oid)
{
        /*PROTECTED REGION ID(RentACarRESTGen.ApplicationCore.CEN.RentACarREST_Coche_desreservar) ENABLED START*/

        // Write here your custom code...

        CocheEN en = get_ICocheRepository ().ReadOIDDefault (p_oid);

        if (!(en.Estado == Enumerated.RentACarREST.EstadoCocheEnum.libre))
                throw new ModelException ("El coche debe estar reservado para desreservar");

        en.Estado = Enumerated.RentACarREST.EstadoCocheEnum.libre;

        get_ICocheRepository ().ModifyDefault (en);


        /*PROTECTED REGION END*/
}
}
}
