
using System;
using System.Text;
using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.Exceptions;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;
using RentACarRESTGen.ApplicationCore.CEN.RentACarREST;



namespace RentACarRESTGen.ApplicationCore.CP.RentACarREST
{
public partial class ReservaCP : GenericBasicCP
{
public ReservaCP(GenericSessionCP currentSession, GenericUnitOfWorkRepository unitRepo)
        : base (currentSession, unitRepo)
{
}
}
}
