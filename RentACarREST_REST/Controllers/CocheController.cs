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


/*PROTECTED REGION ID(usingRentACarREST_REST_CocheControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace RentACarREST_REST.Controllers
{
[ApiController]
[Route ("~/api/Coche")]
public class CocheController : BasicController
{
// Voy a generar el readAll













// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadFilter Generado a partir del serviceLink

[HttpGet]

[Route ("~/api/Coche/Coche_dameCochesDisponibles")]

public ActionResult<List<CocheDTOA> > Coche_dameCochesDisponibles (int first)
{
        // CAD, CEN, EN, returnValue

        CocheRESTCAD cocheRESTCAD = null;
        CocheCEN cocheCEN = null;

        System.Collections.Generic.List<CocheEN> en;
        List<CocheDTOA> returnValue = null;

        try
        {
                session.SessionInitializeWithoutTransaction ();



                cocheRESTCAD = new CocheRESTCAD (session);
                cocheCEN = new CocheCEN (unitRepo.cocherepository);


                // CEN return


                // paginación

                en = cocheCEN.DameCochesDisponibles (first, 10).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<CocheDTOA>();
                        foreach (CocheEN entry in en)
                                returnValue.Add (CocheAssembler.Convert (entry, unitRepo, session));
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






[HttpPost]

[Route ("~/api/Coche/CrearCoche")]


public ActionResult<CocheDTOA> CrearCoche ( [FromBody] CocheDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        CocheRESTCAD cocheRESTCAD = null;
        CocheCEN cocheCEN = null;
        CocheDTOA returnValue = null;
        int returnOID = -1;

        try
        {
                session.SessionInitializeTransaction ();


                cocheRESTCAD = new CocheRESTCAD (session);
                cocheCEN = new CocheCEN (unitRepo.cocherepository);

                // Create
                returnOID = cocheCEN.CrearCoche (
                        dto.Categoria                                                                            //Atributo Primitivo: p_categoria
                        , dto.Estado                                                                                                                                                     //Atributo Primitivo: p_estado
                        );
                session.Commit ();

                // Convert return
                returnValue = CocheAssembler.Convert (cocheRESTCAD.ReadOIDDefault (returnOID), unitRepo, session);
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


        return Created ("~/api/Coche/CrearCoche/" + returnOID, returnValue);
}






[HttpPut]

[Route ("~/api/Coche/Modificar")]

public ActionResult<CocheDTOA> Modificar (int idCoche, [FromBody] CocheDTO dto)
{
        // CAD, CEN, returnValue
        CocheRESTCAD cocheRESTCAD = null;
        CocheCEN cocheCEN = null;
        CocheDTOA returnValue = null;

        try
        {
                session.SessionInitializeTransaction ();


                cocheRESTCAD = new CocheRESTCAD (session);
                cocheCEN = new CocheCEN (unitRepo.cocherepository);

                // Modify
                cocheCEN.Modificar (idCoche,
                        dto.Categoria
                        ,
                        dto.Estado
                        );

                // Return modified object
                returnValue = CocheAssembler.Convert (cocheRESTCAD.ReadOIDDefault (idCoche), unitRepo, session);

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

        // Return 404 - Not found
        if (returnValue == null)
                return StatusCode (404);
        // Return 200 - OK
        else return returnValue;
}





[HttpDelete]


[Route ("~/api/Coche/BorrarCoche")]

public ActionResult BorrarCoche (int p_coche_oid)
{
        // CAD, CEN
        CocheRESTCAD cocheRESTCAD = null;
        CocheCEN cocheCEN = null;

        try
        {
                session.SessionInitializeTransaction ();


                cocheRESTCAD = new CocheRESTCAD (session);
                cocheCEN = new CocheCEN (unitRepo.cocherepository);

                cocheCEN.BorrarCoche (p_coche_oid);
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

        // Return 204 - No Content
        return StatusCode (204);
}









/*PROTECTED REGION ID(RentACarREST_REST_CocheControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
