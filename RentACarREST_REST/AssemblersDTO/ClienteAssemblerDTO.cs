using System;
using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarREST_REST.DTO;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;

namespace RentACarREST_REST.AssemblersDTO
{
public class ClienteAssemblerDTO {
public static IList<ClienteEN> ConvertList (IList<ClienteDTO> lista)
{
        IList<ClienteEN> result = new List<ClienteEN>();
        foreach (ClienteDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ClienteEN Convert (ClienteDTO dto)
{
        ClienteEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ClienteEN ();



                        newinstance.DNI = dto.DNI;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Direccion = dto.Direccion;
                        newinstance.Telefono = dto.Telefono;
                        if (dto.Factura_oid != null) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.IFacturaRepository facturaCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.FacturaRepository ();

                                newinstance.Factura = new System.Collections.Generic.List<RentACarRESTGen.ApplicationCore.EN.RentACarREST.FacturaEN>();
                                foreach (int entry in dto.Factura_oid) {
                                        newinstance.Factura.Add (facturaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Reserva_oid != null) {
                                RentACarRESTGen.ApplicationCore.IRepository.RentACarREST.IReservaRepository reservaCAD = new RentACarRESTGen.Infraestructure.Repository.RentACarREST.ReservaRepository ();

                                newinstance.Reserva = new System.Collections.Generic.List<RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN>();
                                foreach (int entry in dto.Reserva_oid) {
                                        newinstance.Reserva.Add (reservaCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Pass = dto.Pass;
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
