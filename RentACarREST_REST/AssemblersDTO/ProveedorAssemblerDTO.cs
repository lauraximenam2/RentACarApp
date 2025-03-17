using System;
using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarREST_REST.DTO;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;

namespace RentACarREST_REST.AssemblersDTO
{
public class ProveedorAssemblerDTO {
public static IList<ProveedorEN> ConvertList (IList<ProveedorDTO> lista)
{
        IList<ProveedorEN> result = new List<ProveedorEN>();
        foreach (ProveedorDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ProveedorEN Convert (ProveedorDTO dto)
{
        ProveedorEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ProveedorEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Coche_oid != null) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.ICocheRepository cocheCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.CocheRepository ();

                                newinstance.Coche = new System.Collections.Generic.List<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN>();
                                foreach (int entry in dto.Coche_oid) {
                                        newinstance.Coche.Add (cocheCAD.ReadOIDDefault (entry));
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
