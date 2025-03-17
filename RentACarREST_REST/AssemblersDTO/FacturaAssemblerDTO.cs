using System;
using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarREST_REST.DTO;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;

namespace RentACarREST_REST.AssemblersDTO
{
public class FacturaAssemblerDTO {
public static IList<FacturaEN> ConvertList (IList<FacturaDTO> lista)
{
        IList<FacturaEN> result = new List<FacturaEN>();
        foreach (FacturaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static FacturaEN Convert (FacturaDTO dto)
{
        FacturaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new FacturaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Fecha = dto.Fecha;
                        newinstance.EsPagada = dto.EsPagada;
                        newinstance.EsAnulada = dto.EsAnulada;
                        if (dto.Cliente_oid != null) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.IClienteRepository clienteCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.ClienteRepository ();

                                newinstance.Cliente = clienteCAD.ReadOIDDefault (dto.Cliente_oid);
                        }

                        if (dto.LineaFactura != null) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.ILineaFacturaRepository lineaFacturaCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.LineaFacturaRepository ();

                                newinstance.LineaFactura = new System.Collections.Generic.List<RentACarRESTGen.ApplicationCore.EN.RentACarREST.LineaFacturaEN>();
                                foreach (LineaFacturaDTO entry in dto.LineaFactura) {
                                        newinstance.LineaFactura.Add (LineaFacturaAssemblerDTO.Convert (entry));
                                }
                        }
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
