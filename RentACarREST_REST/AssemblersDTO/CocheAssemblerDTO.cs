using System;
using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarREST_REST.DTO;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;

namespace RentACarREST_REST.AssemblersDTO
{
public class CocheAssemblerDTO {
public static IList<CocheEN> ConvertList (IList<CocheDTO> lista)
{
        IList<CocheEN> result = new List<CocheEN>();
        foreach (CocheDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CocheEN Convert (CocheDTO dto)
{
        CocheEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CocheEN ();



                        if (dto.Reserva_oid != -1) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.IReservaRepository reservaCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.ReservaRepository ();

                                newinstance.Reserva = reservaCAD.ReadOIDDefault (dto.Reserva_oid);
                        }
                        newinstance.NumLicencia = dto.NumLicencia;
                        newinstance.Categoria = dto.Categoria;
                        newinstance.Estado = dto.Estado;
                        if (dto.Proveedor_oid != null) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.IProveedorRepository proveedorCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.ProveedorRepository ();

                                newinstance.Proveedor = new System.Collections.Generic.List<RentACarRESTGen.ApplicationCore.EN.RentACarREST.ProveedorEN>();
                                foreach (int entry in dto.Proveedor_oid) {
                                        newinstance.Proveedor.Add (proveedorCAD.ReadOIDDefault (entry));
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
