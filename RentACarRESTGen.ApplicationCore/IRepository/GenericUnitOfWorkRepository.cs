
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarRESTGen.ApplicationCore.IRepository.RentACarREST
{
public abstract class GenericUnitOfWorkRepository
{
public IClienteRepository clienterepository {
        set; get;
}
public IFacturaRepository facturarepository {
        set; get;
}
public IReservaRepository reservarepository {
        set; get;
}
public ILineaFacturaRepository lineafacturarepository {
        set; get;
}
public ICocheRepository cocherepository {
        set; get;
}
public IProveedorRepository proveedorrepository {
        set; get;
}
}
}
