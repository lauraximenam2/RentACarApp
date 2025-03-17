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
public static class LineaFacturaAssembler
{
public static LineaFacturaDTOA Convert (LineaFacturaEN en, GenericUnitOfWorkRepository unitRepo, GenericSessionCP session = null)
{
        LineaFacturaDTOA dto = null;
        LineaFacturaRESTCAD lineaFacturaRESTCAD = null;
        LineaFacturaCEN lineaFacturaCEN = null;
        LineaFacturaCP lineaFacturaCP = null;

        if (en != null) {
                dto = new LineaFacturaDTOA ();
                lineaFacturaRESTCAD = new LineaFacturaRESTCAD (session);
                lineaFacturaCEN = new LineaFacturaCEN (lineaFacturaRESTCAD);
                lineaFacturaCP = new LineaFacturaCP (session, unitRepo);





                //
                // Attributes

                dto.NumLinea = en.NumLinea;

                dto.Precio = en.Precio;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
