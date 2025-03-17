using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace RentACarREST_REST.DTOA
{
public class ReservaDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private Nullable<DateTime> inicio;
public Nullable<DateTime> Inicio
{
        get { return inicio; }
        set { inicio = value; }
}

private Nullable<DateTime> final;
public Nullable<DateTime> Final
{
        get { return final; }
        set { final = value; }
}


/* Rol: Reserva o--> Coche */
private CocheDTOA coches;
public CocheDTOA Coches
{
        get { return coches; }
        set { coches = value; }
}
}
}
