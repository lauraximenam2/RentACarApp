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


/*PROTECTED REGION ID(usingRentACarREST_REST_Cliente_anonimoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace RentACarREST_REST.Controllers
{
[ApiController]
[Route ("~/api/Cliente_anonimo")]
public class Cliente_anonimoController : BasicController
{
// Voy a generar el readAll















[HttpPost]

[Route ("~/api/Cliente_anonimo/Login")]


public ActionResult<string> Login ( [FromBody] ClienteDTO dto)
{
        // CAD, CEN, returnValue
        Cliente_anonimoRESTCAD cliente_anonimoRESTCAD = null;
        ClienteCEN clienteCEN = null;
        string token = null;

        try
        {
                session.SessionInitializeTransaction ();
                cliente_anonimoRESTCAD = new Cliente_anonimoRESTCAD (session);
                clienteCEN = new ClienteCEN (unitRepo.clienterepository);


                // Operation
                token = clienteCEN.Login (
                        dto.DNI
                        , dto.Pass
                        );

                session.Commit ();
        }

        catch (Exception e)
        {
                session.RollBack ();

                StatusCodeResult result = StatusCode (500);
                if (e.GetType () == typeof(RentACarRESTGen.ApplicationCore.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) result = StatusCode (403);
                else if (e.GetType () == typeof(RentACarRESTGen.ApplicationCore.Exceptions.ModelException) || e.GetType () == typeof(RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException)) result = StatusCode (400);
                return result;
        }
        finally
        {
                session.SessionClose ();
        }

        // Return 200 - OK
        if (token != null)
                return token;
        else
                return StatusCode (403);
}



















/*PROTECTED REGION ID(RentACarREST_REST_Cliente_anonimoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
