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
public static class ClienteRegistradoAssembler
{
public static ClienteRegistradoDTOA Convert (ClienteEN en, GenericUnitOfWorkRepository unitRepo, GenericSessionCP session = null)
{
        ClienteRegistradoDTOA dto = null;
        ClienteRegistradoRESTCAD clienteRegistradoRESTCAD = null;
        ClienteCEN clienteCEN = null;
        ClienteCP clienteCP = null;

        if (en != null) {
                dto = new ClienteRegistradoDTOA ();
                clienteRegistradoRESTCAD = new ClienteRegistradoRESTCAD (session);
                clienteCEN = new ClienteCEN (clienteRegistradoRESTCAD);
                clienteCP = new ClienteCP (session, unitRepo);





                //
                // Attributes

                dto.DNI = en.DNI;

                dto.Nombre = en.Nombre;


                dto.Direccion = en.Direccion;


                dto.Telefono = en.Telefono;


                //
                // TravesalLink

                /* Rol: ClienteRegistrado o--> Factura */
                dto.Facturas = null;
                List<FacturaEN> Facturas = clienteRegistradoRESTCAD.Facturas (en.DNI).ToList ();
                if (Facturas != null) {
                        dto.Facturas = new List<FacturaDTOA>();
                        foreach (FacturaEN entry in Facturas)
                                dto.Facturas.Add (FacturaAssembler.Convert (entry, unitRepo, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
