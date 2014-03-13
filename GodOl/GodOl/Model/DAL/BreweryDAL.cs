 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GodOl.Model.DAL
{
    public class BreweryDAL : BaseDAL
    {
        /// <summary>
        /// Hämtar alla bryggerier i databasen
        /// </summary>
        /// <returns>Lista med referenser till Brewery-objekt</returns>
        public IEnumerable<Brewery> GetBreweries()
        {
            //Skapar ett SQLConnection-objekt från Bas-klassen
            using (var con = CreateConnection())
            {
                var breweries = new List<Brewery>(20);
                try
                {
                    //Skapar Command-objekt för att exekvera Lagrade procedurer och ställa in parametrar till dessa
                    var cmd = new SqlCommand("Brewery.GetBreweries", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    //Skapar ett Reader-objekt som kan läsa posterna i svaret
                    using (var r = cmd.ExecuteReader())
                    {
                        //Tar fram index på fälten med hjälp av readern för att kunna hantera dem dynamiskt(associativt)
                        var iBreweryId = r.GetOrdinal("BreweryId");
                        var iName = r.GetOrdinal("Name");
                        var iAdress = r.GetOrdinal("Adress");
                        var iAdress2 = r.GetOrdinal("Adress2");
                        var iCity = r.GetOrdinal("City");
                        var iState = r.GetOrdinal("State");
                        var iZip = r.GetOrdinal("Zip");
                        var iEstablished = r.GetOrdinal("Established");
                        var iNationality = r.GetOrdinal("Nationality");
                        
                        //Läser en post i taget från resultatet så länge det finns och skapar där efter objekt med hjälp av dessa 
                        while (r.Read())
                        {
                            breweries.Add(new Brewery
                            {
                                BreweryId = r.GetInt32(iBreweryId),
                                Name = r.GetString(iName),
                                Adress = r.GetString(iAdress),
                                Adress2 = r.GetString(iAdress2),
                                City = r.GetString(iCity),
                                State = r.GetString(iState),
                                Zip = r.GetString(iZip),
                                Nationality = r.GetString(iNationality),
                                Established = r.GetString(iEstablished)
                            });
                        }
                    }
                    breweries.TrimExcess();
                    return breweries;
                }
                catch
                {
                    throw new ApplicationException("Fel vid läsning från databasen.");
                }
            }
        }

        /// <summary>
        /// Hämtar ut ett bryggeri ur databasen
        /// </summary>
        /// <param name="breweryId">Id på bryggeriet som ska hämtas</param>
        /// <returns>Ett Brewery-objekt</returns>
        public Brewery GetBreweryById(int breweryId)
        {
            //Skapar ett SQLConnection-objekt från Bas-klassen
            using (var con = CreateConnection())
            {
                //Skapar initial lista för att kunna lagra bryggerier i
                var breweries = new List<Brewery>(20);
                try
                {
                    //Skapar Command-objekt för att exekvera Lagrade procedurer och ställa in parametrar till dessa
                    var cmd = new SqlCommand("Brewery.GetBrewery", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BreweryId", SqlDbType.Int, 4).Value = breweryId;
                    con.Open();

                    //Skapar ett Reader-objekt som kan läsa posterna i svaret
                    using (var r = cmd.ExecuteReader())
                    {
                        if(r.Read())
                        {
                            //Tar fram index på fälten med hjälp av readern för att kunna hantera dem dynamiskt(associativt)
                            return new Brewery
                            {
                                BreweryId = r.GetInt32(r.GetOrdinal("BreweryId")),
                                Name = r.GetString(r.GetOrdinal("Name")),
                                Adress = r.GetString(r.GetOrdinal("Adress")),
                                Adress2 = r.GetString(r.GetOrdinal("Adress2")),
                                City = r.GetString(r.GetOrdinal("City")),
                                State = r.GetString(r.GetOrdinal("State")),
                                Zip = r.GetString(r.GetOrdinal("Zip")),
                                Nationality = r.GetString(r.GetOrdinal("Nationality")),
                                Established = r.GetString(r.GetOrdinal("Established"))
                            };
                        }
                    }
                    //Returnar null om det inte fanns någon post i databasen
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Fel vid läsning från databasen.");
                }
            }
        }

        /// <summary>
        /// Lägger in nytt bryggeri i databasen
        /// </summary>
        /// <param name="brewery">Bryggeri-objekt</param>
        public void InsertBrewery(Brewery brewery)
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Beer.InsertBrewery", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = brewery.Name;
                    cmd.Parameters.Add("@Adress", SqlDbType.VarChar, 30).Value = brewery.Adress;
                    cmd.Parameters.Add("@Adress2", SqlDbType.VarChar, 30).Value = brewery.Adress2;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = brewery.City;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar, 30).Value = brewery.State;
                    cmd.Parameters.Add("@Zip", SqlDbType.VarChar, 30).Value = brewery.Zip;
                    cmd.Parameters.Add("@Nationality", SqlDbType.VarChar, 30).Value = brewery.Nationality;
                    cmd.Parameters.Add("@Established", SqlDbType.VarChar, 4).Value = brewery.Established;
                   
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Fel vid skrivning till databasen.");
                }
            }
        }

        /// <summary>
        /// Uppdaterar befintligt bryggeri i databasen
        /// </summary>
        /// <param name="brewery">Brewery-objek</param>
        public void UpdateBrewery(Brewery brewery)
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Beer.UpdateBrewery", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BeweryId", SqlDbType.Int, 4).Value = brewery.BreweryId;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = brewery.Name;
                    cmd.Parameters.Add("@Adress", SqlDbType.VarChar, 30).Value = brewery.Adress;
                    cmd.Parameters.Add("@Adress2", SqlDbType.VarChar, 30).Value = brewery.Adress2;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = brewery.City;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar, 30).Value = brewery.State;
                    cmd.Parameters.Add("@Zip", SqlDbType.VarChar, 30).Value = brewery.Zip;
                    cmd.Parameters.Add("@Nationality", SqlDbType.VarChar, 30).Value = brewery.Nationality;
                    cmd.Parameters.Add("@Established", SqlDbType.VarChar, 4).Value = brewery.Established;
                    
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Fel vid skrivning till databasen.");
                }
            }
        }

        /// <summary>
        /// Ta bort ett bryggeri ur databasen
        /// </summary>
        /// <param name="breweryId">Id på bryggeriet som ska tas bort</param>
        public void DeleteBrewery(int breweryId)
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Beer.DeleteBrewery", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BreweryId", SqlDbType.Int, 4).Value = breweryId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Fel vid skrivning till databasen.");
                }
            }
        }
    }
}