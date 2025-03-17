using Microsoft.AspNetCore.Mvc;
using RentACarRESTGen.Infraestructure.CP;
using RentACarRESTGen.Infraestructure.Repository;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;


namespace RentACarREST_REST.Controllers
{
public class BasicController : ControllerBase
{
protected GenericSessionCP session;
protected UnitOfWorkRepository unitRepo;

protected BasicController()
{
        session = new SessionCPNHibernate ();
        unitRepo = new UnitOfWorkRepository ((SessionCPNHibernate)session);
}

#region Individual Security

protected bool IsLoginID (string id)
{
        return(User.Identity.Name == id);
}

protected void Security (string id)
{
        if (User.Identity.Name == id) StatusCode (403);
}

#endregion
}
}
