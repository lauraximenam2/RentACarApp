
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
namespace RentACarRESTGen.Infraestructure.EN.RentACarREST
{
public partial class ReservaNH : ReservaEN {
public ReservaNH ()
{
}

public ReservaNH (ReservaEN dto)
{
        this.Id = dto.Id;


        this.Inicio = dto.Inicio;


        this.Final = dto.Final;
}
}
}
