using System;
using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarREST_REST.DTO;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;

namespace RentACarREST_REST.AssemblersDTO
{
public class LineaFacturaAssemblerDTO {
public static IList<LineaFacturaEN> ConvertList (IList<LineaFacturaDTO> lista)
{
        IList<LineaFacturaEN> result = new List<LineaFacturaEN>();
        foreach (LineaFacturaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static LineaFacturaEN Convert (LineaFacturaDTO dto)
{
        LineaFacturaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new LineaFacturaEN ();



                        if (dto.Factura_oid != -1) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.IFacturaRepository facturaCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.FacturaRepository ();

                                newinstance.Factura = facturaCAD.ReadOIDDefault (dto.Factura_oid);
                        }
                        newinstance.NumLinea = dto.NumLinea;
                        if (dto.Reserva_oid != -1) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.IReservaRepository reservaCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.ReservaRepository ();

                                newinstance.Reserva = reservaCAD.ReadOIDDefault (dto.Reserva_oid);
                        }
                        newinstance.Precio = dto.Precio;
                }
        }
        catch (Exception)
        {
                throw;
        }
        return newinstance;
}
}
}
