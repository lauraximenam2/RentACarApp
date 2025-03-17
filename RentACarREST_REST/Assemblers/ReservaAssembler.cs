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
public static class ReservaAssembler
{
public static ReservaDTOA Convert (ReservaEN en, GenericUnitOfWorkRepository unitRepo, GenericSessionCP session = null)
{
        ReservaDTOA dto = null;
        ReservaRESTCAD reservaRESTCAD = null;
        ReservaCEN reservaCEN = null;
        ReservaCP reservaCP = null;

        if (en != null) {
                dto = new ReservaDTOA ();
                reservaRESTCAD = new ReservaRESTCAD (session);
                reservaCEN = new ReservaCEN (reservaRESTCAD);
                reservaCP = new ReservaCP (session, unitRepo);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Inicio = en.Inicio;


                dto.Final = en.Final;


                //
                // TravesalLink

                /* Rol: Reserva o--> Coche */
                dto.Coches = CocheAssembler.Convert ((CocheEN)en.Coche, unitRepo, session);


                //
                // Service
        }

        return dto;
}
}
}
