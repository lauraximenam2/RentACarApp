

using System;
using System.Collections.Generic;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;

namespace RentACarRESTGen.ApplicationCore.CP.RentACarREST
{
public abstract class GenericBasicCP
{
protected GenericSessionCP CPSession;
protected GenericUnitOfWorkRepository unitRepo;
protected GenericBasicCP (GenericSessionCP currentSession, GenericUnitOfWorkRepository unitRepo)
{
        this.CPSession = currentSession;
        this.unitRepo = unitRepo;
}
}
}

