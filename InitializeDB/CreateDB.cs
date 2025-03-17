
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CEN.RentACarREST;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;
using RentACarRESTGen.Infraestructure.CP;
using RentACarRESTGen.ApplicationCore.Exceptions;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;
using RentACarRESTGen.Infraestructure.Repository;
using RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local); database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN 
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                ClienteRepository clienterepository = new ClienteRepository ();
                ClienteCEN clientecen = new ClienteCEN (clienterepository);
                FacturaRepository facturarepository = new FacturaRepository ();
                FacturaCEN facturacen = new FacturaCEN (facturarepository);
                ReservaRepository reservarepository = new ReservaRepository ();
                ReservaCEN reservacen = new ReservaCEN (reservarepository);
                LineaFacturaRepository lineafacturarepository = new LineaFacturaRepository ();
                LineaFacturaCEN lineafacturacen = new LineaFacturaCEN (lineafacturarepository);
                CocheRepository cocherepository = new CocheRepository ();
                CocheCEN cochecen = new CocheCEN (cocherepository);
                ProveedorRepository proveedorrepository = new ProveedorRepository ();
                ProveedorCEN proveedorcen = new ProveedorCEN (proveedorrepository);

                // Initialising  CPs
                SessionCPNHibernate session = new SessionCPNHibernate ();
                UnitOfWorkRepository unitRep = new UnitOfWorkRepository (session);
                ClienteCP clientecp = new ClienteCP (session, unitRep);
                FacturaCP facturacp = new FacturaCP (session, unitRep);
                ReservaCP reservacp = new ReservaCP (session, unitRep);
                LineaFacturaCP lineafacturacp = new LineaFacturaCP (session, unitRep);
                CocheCP cochecp = new CocheCP (session, unitRep);
                ProveedorCP proveedorcp = new ProveedorCP (session, unitRep);


                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                clientecen.CrearCliente ("9292", "Juan Ortiz", "dir", "telf", "1234");
                clientecen.CrearCliente ("9293", "Pedro Lopez", "dir", "telf", "1234");

                //Creamos Reservas
                int res1 = reservacen.CrearReserva ("9292", DateTime.Today, new DateTime (2023, 3, 22));
                int res2 = reservacen.CrearReserva ("9293", DateTime.Today.AddDays (1), new DateTime (2023, 4, 19));


                //Creamos Coches
                int idCoche1 = cochecen.CrearCoche (CategoriaCocheEnum.estandar, EstadoCocheEnum.libre);
                int idCoche2 = cochecen.CrearCoche (CategoriaCocheEnum.lujo, EstadoCocheEnum.libre);
                int idCoche3 = cochecen.CrearCoche (CategoriaCocheEnum.estandar, EstadoCocheEnum.libre);
                int idCoche4 = cochecen.CrearCoche (CategoriaCocheEnum.lujo, EstadoCocheEnum.libre);
                int idCoche5 = cochecen.CrearCoche (CategoriaCocheEnum.estandar, EstadoCocheEnum.libre);


                //Asignamos Coches a reservas (Reservamos)

                cochecen.AsignarReserva (idCoche1, res1);
                cochecen.AsignarReserva (idCoche2, res2);
                CocheEN co1 = cochecen.get_ICocheRepository ().ReadOIDDefault (idCoche1);
                CocheEN co2 = cochecen.get_ICocheRepository ().ReadOIDDefault (idCoche2);

                cochecen.Modificar (idCoche1, co1.Categoria, EstadoCocheEnum.alquilado);
                cochecen.Modificar (idCoche2, co2.Categoria, EstadoCocheEnum.alquilado);

                // Creamos facturas
                int idFactura = facturacen.CrearFactura (DateTime.Today, false, false, "9292");

                lineafacturacen.CrearLinea (idFactura, res1, 350);
                lineafacturacen.CrearLinea (idFactura, res1, 200);
                lineafacturacen.CrearLinea (idFactura, res1, 150);

                int idFactura2 = facturacen.CrearFactura (DateTime.Today, false, false, "9293");

                lineafacturacen.CrearLinea (idFactura2, res2, 500);
                lineafacturacen.CrearLinea (idFactura2, res2, 500);
                lineafacturacen.CrearLinea (idFactura2, res2, 500);
                lineafacturacen.CrearLinea (idFactura2, res2, 500);

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
