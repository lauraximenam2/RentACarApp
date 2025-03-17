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
public static class CocheAssembler
{
public static CocheDTOA Convert (CocheEN en, GenericUnitOfWorkRepository unitRepo, GenericSessionCP session = null)
{
        CocheDTOA dto = null;
        CocheRESTCAD cocheRESTCAD = null;
        CocheCEN cocheCEN = null;
        CocheCP cocheCP = null;

        if (en != null) {
                dto = new CocheDTOA ();
                cocheRESTCAD = new CocheRESTCAD (session);
                cocheCEN = new CocheCEN (cocheRESTCAD);
                cocheCP = new CocheCP (session, unitRepo);





                //
                // Attributes

                dto.NumLicencia = en.NumLicencia;

                dto.Categoria = en.Categoria;


                dto.Estado = en.Estado;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
