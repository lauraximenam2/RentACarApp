

using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;
using RentACarRESTGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarRESTGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
public UnitOfWorkRepository()
{
        this.clienterepository = new ClienteRepository ();
        this.facturarepository = new FacturaRepository ();
        this.reservarepository = new ReservaRepository ();
        this.lineafacturarepository = new LineaFacturaRepository ();
        this.cocherepository = new CocheRepository ();
        this.proveedorrepository = new ProveedorRepository ();
}

public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.clienterepository = new ClienteRepository ();
        this.clienterepository.setSessionCP (session);
        this.facturarepository = new FacturaRepository ();
        this.facturarepository.setSessionCP (session);
        this.reservarepository = new ReservaRepository ();
        this.reservarepository.setSessionCP (session);
        this.lineafacturarepository = new LineaFacturaRepository ();
        this.lineafacturarepository.setSessionCP (session);
        this.cocherepository = new CocheRepository ();
        this.cocherepository.setSessionCP (session);
        this.proveedorrepository = new ProveedorRepository ();
        this.proveedorrepository.setSessionCP (session);
}
}
}

