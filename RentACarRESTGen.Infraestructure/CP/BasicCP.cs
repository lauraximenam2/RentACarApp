

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;
using RentACarRESTGen.Infraestructure.Repository;

namespace RentACarRESTGen.Infraestructure.CP
{
public class BasicCPNHibernate : GenericBasicCP
{
protected ISession session;

protected ITransaction tx;


protected BasicCPNHibernate(SessionCPNHibernate sessionCP, UnitOfWorkRepository unitRepo) : base (sessionCP, unitRepo)
{
        session = (ISession)sessionCP.CurrentSession;
}
}
}

