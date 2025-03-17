using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using RentACarREST_REST.DTOA;
using RentACarREST_REST.CAD;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CEN.RentACarREST;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;

namespace RentACarREST_REST.Assemblers
{
public static class Cliente_anonimoAssembler
{
public static Cliente_anonimoDTOA Convert (ClienteEN en, GenericUnitOfWorkRepository unitRepo, GenericSessionCP session = null)
{
        Cliente_anonimoDTOA dto = null;
        Cliente_anonimoRESTCAD cliente_anonimoRESTCAD = null;
        ClienteCEN clienteCEN = null;
        ClienteCP clienteCP = null;

        if (en != null) {
                dto = new Cliente_anonimoDTOA ();
                cliente_anonimoRESTCAD = new Cliente_anonimoRESTCAD (session);
                clienteCEN = new ClienteCEN (cliente_anonimoRESTCAD);
                clienteCP = new ClienteCP (session, unitRepo);





                //
                // Attributes

                dto.DNI = en.DNI;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
