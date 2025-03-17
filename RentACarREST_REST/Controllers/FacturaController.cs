using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RentACarREST_REST.DTO;
using RentACarREST_REST.DTOA;
using RentACarREST_REST.CAD;
using RentACarREST_REST.Assemblers;
using RentACarREST_REST.AssemblersDTO;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CEN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;

/*PROTECTED REGION ID(usingRentACarREST_REST_FacturaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/

namespace RentACarREST_REST.Controllers
{
    [ApiController]
    [Route("~/api/Factura")]
    public class FacturaController : BasicController
    {
        // Método para obtener todas las facturas de un cliente
        [HttpGet]
        [Route("~/api/Factura/ObtenerFacturasPorCliente")]
        public ActionResult<List<FacturaDTOA>> ObtenerFacturasPorCliente()
        {
            // CAD, CEN, EN, returnValue
            FacturaRESTCAD facturaRESTCAD = null;
            FacturaCEN facturaCEN = null;
            ClienteCEN clienteCEN = null;
            IList<FacturaEN> facturasEN = null;
            List<FacturaDTOA> returnValue = new List<FacturaDTOA>();

            try
            {
                session.SessionInitializeWithoutTransaction();

                // Obtener el token del cliente autenticado
                string token = "";
                if (Request.Headers["Authorization"].Count > 0)
                    token = Request.Headers["Authorization"].ToString();

                // Verificar el token y obtener el ID del cliente
                clienteCEN = new ClienteCEN(unitRepo.clienterepository);
                string clienteId = clienteCEN.CheckToken(token);

                // Obtener las facturas del cliente
                facturaRESTCAD = new FacturaRESTCAD(session);
                facturaCEN = new FacturaCEN(unitRepo.facturarepository);
                facturasEN = facturaCEN.ObtenerFacturasPorCliente(clienteId);

                // Convertir las facturas a DTOA
                if (facturasEN != null && facturasEN.Count > 0)
                {
                    foreach (var factura in facturasEN)
                    {
                        returnValue.Add(FacturaAssembler.Convert(factura, unitRepo, session));
                    }
                }
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

            // Retornar 204 si no hay facturas
            if (returnValue.Count == 0)
                return StatusCode(204);

            // Retornar la lista de facturas
            return returnValue;
        }

        // Método para obtener el total de una factura
        [HttpPost]
        [Route("~/api/Factura/Factura_dameTotal")]
        public ActionResult<double> Factura_dameTotal(int p_oid)
        {
            // CP, returnValue
            FacturaCP facturaCP = null;
            double returnValue;

            try
            {
                session.SessionInitializeTransaction();
                facturaCP = new FacturaCP(session, unitRepo);

                // Operación
                returnValue = facturaCP.DameTotal(p_oid);
                session.Commit();
            }
            catch (Exception e)
            {
                session.RollBack();
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

            // Retornar 200 - OK
            return returnValue;
        }

        // Método para obtener detalle de una factura
        [HttpGet]
        [Route("~/api/Factura/ObtenerFacturaPorId")]
        public ActionResult<FacturaDTOA> ObtenerFacturaPorId(int id)
        {
            FacturaRESTCAD facturaRESTCAD = null;
            FacturaCEN facturaCEN = null;
            FacturaEN facturaEN = null;
            FacturaDTOA returnValue = null;

            try
            {
                session.SessionInitializeWithoutTransaction();

                // Obtener el token del cliente autenticado
                string token = "";
                if (Request.Headers["Authorization"].Count > 0)
                    token = Request.Headers["Authorization"].ToString();

                // Verificar el token
                ClienteCEN clienteCEN = new ClienteCEN(unitRepo.clienterepository);
                string clienteId = clienteCEN.CheckToken(token);

                // Obtener la factura por ID
                facturaRESTCAD = new FacturaRESTCAD(session);
                facturaCEN = new FacturaCEN(unitRepo.facturarepository);
                facturaEN = facturaCEN.ObtenerFacturaPorId(id);

                // Convertir la factura a DTOA si existe
                if (facturaEN != null)
                {
                    returnValue = FacturaAssembler.Convert(facturaEN, unitRepo, session);
                }
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

            // Retornar 404 si no se encuentra la factura
            if (returnValue == null)
                return NotFound("Factura no encontrada");

            // Retornar la factura
            return returnValue;
        }


        /*PROTECTED REGION ID(RentACarREST_REST_FacturaControllerAzure) ENABLED START*/
        // Meter las operaciones que invoquen a las CPs
        /*PROTECTED REGION END*/
    }
}
