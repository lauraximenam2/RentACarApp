using System;
using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarREST_REST.DTO;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;

namespace RentACarREST_REST.AssemblersDTO
{
public class ReservaAssemblerDTO {
public static IList<ReservaEN> ConvertList (IList<ReservaDTO> lista)
{
        IList<ReservaEN> result = new List<ReservaEN>();
        foreach (ReservaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ReservaEN Convert (ReservaDTO dto)
{
        ReservaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ReservaEN ();



                        if (dto.Cliente_oid != null) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.IClienteRepository clienteCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.ClienteRepository ();

                                newinstance.Cliente = clienteCAD.ReadOIDDefault (dto.Cliente_oid);
                        }
                        newinstance.Id = dto.Id;
                        if (dto.Coche_oid != -1) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.ICocheRepository cocheCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.CocheRepository ();

                                newinstance.Coche = cocheCAD.ReadOIDDefault (dto.Coche_oid);
                        }
                        if (dto.LineaFactura_oid != -1) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.ILineaFacturaRepository lineaFacturaCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.LineaFacturaRepository ();

                                newinstance.LineaFactura = lineaFacturaCAD.ReadOIDDefault (dto.LineaFactura_oid);
                        }
                        newinstance.Inicio = dto.Inicio;
                        newinstance.Final = dto.Final;
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
