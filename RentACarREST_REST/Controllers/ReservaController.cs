using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RentACarREST_REST.DTO;
using RentACarREST_REST.DTOA;
using RentACarREST_REST.CAD;
using RentACarREST_REST.Assemblers;
using RentACarREST_REST.AssemblersDTO;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CEN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;


/*PROTECTED REGION ID(usingRentACarREST_REST_ReservaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace RentACarREST_REST.Controllers
{
[ApiController]
[Route ("~/api/Reserva")]
public class ReservaController : BasicController
{
// Voy a generar el readAll







[HttpGet]

[Route ("~/api/Reserva/DameReservas")]

public ActionResult<List<ReservaDTOA> > DameReservas (string idClienteRegistrado)
{
        // CAD, EN
        ClienteRegistradoRESTCAD clienteRegistradoRESTCAD = null;
        ClienteEN clienteEN = null;

        // returnValue
        List<ReservaEN> en = null;
        List<ReservaDTOA> returnValue = null;

        try
        {
                session.SessionInitializeWithoutTransaction ();


                clienteRegistradoRESTCAD = new ClienteRegistradoRESTCAD (session);

                // Exists ClienteRegistrado
                clienteEN = clienteRegistradoRESTCAD.ReadOIDDefault (idClienteRegistrado);
                if (clienteEN == null) return NotFound ();

                // Rol
                // TODO: paginación


                en = clienteRegistradoRESTCAD.DameReservas (idClienteRegistrado).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<ReservaDTOA>();
                        foreach (ReservaEN entry in en)
                                returnValue.Add (ReservaAssembler.Convert (entry, unitRepo, session));
                }
        }

        catch (Exception e)
        {
                StatusCodeResult result = StatusCode (500);
                if (e.GetType () == typeof(RentACarRESTGen.ApplicationCore.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) result = StatusCode (403);
                else if (e.GetType () == typeof(RentACarRESTGen.ApplicationCore.Exceptions.ModelException) || e.GetType () == typeof(RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException)) result = StatusCode (400);
                return result;
        }
        finally
        {
                session.SessionClose ();
        }

        // Return 204 - Empty
        if (returnValue == null || returnValue.Count == 0)
                return StatusCode (204);
        // Return 200 - OK
        else return returnValue;
}

        [HttpGet]
        [Route("~/api/Reserva/DameReserva")]
        public ActionResult<ReservaDTOA> DameReserva(int idReserva)
        {
            // CAD, EN
            ReservaRESTCAD reservaRESTCAD = null;
            ReservaEN reservaEN = null;
            ReservaDTOA returnValue = null;

            try
            {
                session.SessionInitializeWithoutTransaction();
                reservaRESTCAD = new ReservaRESTCAD(session);

                // Busca la reserva por ID
                reservaEN = reservaRESTCAD.ReadOIDDefault(idReserva);
                if (reservaEN == null) return NotFound();

                // Convertir a DTOA
                returnValue = ReservaAssembler.Convert(reservaEN, unitRepo, session);
            }
            catch (Exception e)
            {
                StatusCodeResult result = StatusCode(500);
                if (e is RentACarRESTGen.ApplicationCore.Exceptions.ModelException && e.Message.Equals("El token es incorrecto"))
                    result = StatusCode(403);
                else if (e is RentACarRESTGen.ApplicationCore.Exceptions.ModelException || e is RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException)
                    result = StatusCode(400);

                return result;
            }
            finally
            {
                session.SessionClose();
            }

            return returnValue ?? (ActionResult<ReservaDTOA>)StatusCode(204);
        }

























        /*PROTECTED REGION ID(RentACarREST_REST_ReservaControllerAzure) ENABLED START*/
        // Meter las operaciones que invoquen a las CPs
        /*PROTECTED REGION END*/
    }
}
