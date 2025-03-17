using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace RentACarREST_REST.DTOA
{
public class ClienteRegistradoDTOA
{
private string dNI;
public string DNI
{
        get { return dNI; }
        set { dNI = value; }
}


private string nombre;
public string Nombre
{
        get { return nombre; }
        set { nombre = value; }
}

private string direccion;
public string Direccion
{
        get { return direccion; }
        set { direccion = value; }
}

private string telefono;
public string Telefono
{
        get { return telefono; }
        set { telefono = value; }
}


/* Rol: ClienteRegistrado o--> Factura */
private IList<FacturaDTOA> facturas;
public IList<FacturaDTOA> Facturas
{
        get { return facturas; }
        set { facturas = value; }
}
}
}
