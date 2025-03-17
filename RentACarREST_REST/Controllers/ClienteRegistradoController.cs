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


/*PROTECTED REGION ID(usingRentACarREST_REST_ClienteRegistradoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace RentACarREST_REST.Controllers
{
[ApiController]
[Route ("~/api/ClienteRegistrado")]
public class ClienteRegistradoController : BasicController
{
// Voy a generar el readAll











[HttpGet]
// [Route("{idClienteRegistrado}", Name="GetOIDClienteRegistrado")]

[Route ("~/api/ClienteRegistrado")]

public ActionResult<ClienteRegistradoDTOA> ReadOID ()
{
        // CAD, CEN, EN, returnValue
        ClienteRegistradoRESTCAD clienteRegistradoRESTCAD = null;
        ClienteCEN clienteCEN = null;
        ClienteEN clienteEN = null;
        ClienteRegistradoDTOA returnValue = null;

        try
        {
                session.SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers ["Authorization"].Count > 0)
                        token = Request.Headers ["Authorization"].ToString ();
                string id = new ClienteCEN (unitRepo.clienterepository).CheckToken (token);



                clienteRegistradoRESTCAD = new ClienteRegistradoRESTCAD (session);
                clienteCEN = new ClienteCEN (unitRepo.clienterepository);

                // Data
                clienteEN = clienteCEN.ReadOID (id);

                // Convert return
                if (clienteEN != null) {
                        returnValue = ClienteRegistradoAssembler.Convert (clienteEN, unitRepo, session);
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
        if (returnValue == null)
                return StatusCode (204);
        // Return 200 - OK
        else return returnValue;
}





















/*PROTECTED REGION ID(RentACarREST_REST_ClienteRegistradoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
