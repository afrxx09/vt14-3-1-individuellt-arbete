using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GodOl.Model.DAL
{
    public class BeerDAL : BaseDAL
    {
        /// <summary>
        /// Hämtar alla öl
        /// </summary>
        /// <returns>Lista med referenser till Beer-objekt</returns>
        public IEnumerable<Beer> GetBeers()
        {
            //Skapar ett SQLConnection-objekt från Bas-klassen
            using(var con = CreateConnection())
            {
                try
                {
                    //Skapar Command-objekt för att exekvera Lagrade procedurer och ställa in parametrar till dessa
                    var cmd = new SqlCommand("Beer.GetBeers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    //Lista att lagra Beer-ojekten som skapas från datan som kommer från databasen.
                    var beers = new List<Beer>(20);

                    //Skapar ett Reader-objekt som kan läsa posterna i svaret
                    using(var r = cmd.ExecuteReader())
                    {
                        //Tar fram index på fälten med hjälp av readern för att kunna hantera dem dynamiskt(associativt)
                        var iBeerId = r.GetOrdinal("BeerId");
                        var iBeerType = r.GetOrdinal("BeerTypeId");
                        var iBreweryId = r.GetOrdinal("BreweryId");
                        var iName = r.GetOrdinal("Name");
                        var iStartYear = r.GetOrdinal("StartYear");
                        var iABV = r.GetOrdinal("ABV");
                        var iIBU = r.GetOrdinal("IBU");
                        var iEBC = r.GetOrdinal("EBC");

                        //Läser en post i taget från resultatet så länge det finns och skapar där efter objekt med hjälp av dessa
                        while(r.Read()){
                            beers.Add(new Beer{
                                BeerId = r.GetInt32(iBeerId),
                                BeerTypeId = r.GetInt32(iBeerType),
                                BeweryId = r.GetInt32(iBreweryId),
                                Name = r.GetString(iName),
                                StartYear = r.GetString(iStartYear),
                                ABV = (double)r.GetDecimal(iABV),
                                IBU = (int)r.GetByte(iIBU),
                                EBC = (int)r.GetByte(iEBC)
                            });
                        }
                    }
                    beers.TrimExcess();
                    return beers;
                }
                catch{
                    throw new ApplicationException("Fel vid läsning från databasen.");
                }
            }
        }

        /// <summary>
        /// Hämtar en öl ur databasen
        /// </summary>
        /// <param name="beerId">Id på ölen som ska hämtas</param>
        /// <returns>Ett Beer-objekt</returns>
        public Beer GetBeerById(int beerId)
        {
            //Skapar ett SQLConnection-objekt från Bas-klassen
            using (var con = CreateConnection())
            {
                try
                {
                    //Skapar Command-objekt för att exekvera Lagrade procedurer och ställa in parametrar till dessa
                    var cmd = new SqlCommand("Beer.GetBeerById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BeerId", SqlDbType.Int, 4).Value = beerId;
                    con.Open();

                    //Skapar ett Reader-objekt som kan läsa posterna i svaret
                    using (var r = cmd.ExecuteReader())
                    {
                        //Om det finns rader att läsa i resultatet så skapas och returnas ett Beer-objekt.
                        if (r.Read())
                        {
                            //Tar fram index på fälten med hjälp av readern för att kunna hantera dem dynamiskt(associativt)
                            var iBeerId = r.GetOrdinal("BeerId");
                            var iBeerType = r.GetOrdinal("BeerTypeId");
                            var iBreweryId = r.GetOrdinal("BreweryId");
                            var iName = r.GetOrdinal("Name");
                            var iStartYear = r.GetOrdinal("StartYear");
                            var iABV = r.GetOrdinal("ABV");
                            var iIBU = r.GetOrdinal("IBU");
                            var iEBC = r.GetOrdinal("EBC");

                            return new Beer
                            {
                                BeerId = r.GetInt32(iBeerId),
                                BeerTypeId = r.GetInt32(iBeerType),
                                BeweryId = r.GetInt32(iBreweryId),
                                Name = r.GetString(iName),
                                StartYear = r.GetString(iStartYear),
                                ABV = (double)r.GetDecimal(iABV),
                                IBU = (int)r.GetByte(iIBU),
                                EBC = (int)r.GetByte(iEBC)
                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Fel vid läsning från databasen.");
                }
            }
        }
        
        /// <summary>
        /// Hämtar öl i databasen baserat på vilket bryggeri de kommer ifrån
        /// </summary>
        /// <param name="breweryId">Id på bryggeriet</param>
        /// <returns>Lista med referenser till Beer-objekt</returns>
        public IEnumerable<Beer> GetBeersByBreweryId(int breweryId)
        {
            //Skapar ett SQLConnection-objekt från Bas-klassen
            using (var con = CreateConnection())
            {
                try
                {
                    //Skapar Command-objekt för att exekvera Lagrade procedurer och ställa in parametrar till dessa
                    var cmd = new SqlCommand("Beer.GetBeersByBreweryId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BreweryId", SqlDbType.Int, 4).Value = breweryId;
                    con.Open();

                    //Lista att lagra Beer-ojekten som skapas från datan som kommer från databasen.
                    var beers = new List<Beer>(20);

                    //Skapar ett Reader-objekt som kan läsa posterna i svaret
                    using (var r = cmd.ExecuteReader())
                    {
                        //Tar fram index på fälten med hjälp av readern för att kunna hantera dem dynamiskt(associativt)
                        var iBeerId = r.GetOrdinal("BeerId");
                        var iBeerType = r.GetOrdinal("BeerTypeId");
                        var iBreweryId = r.GetOrdinal("BreweryId");
                        var iName = r.GetOrdinal("Name");
                        var iStartYear = r.GetOrdinal("StartYear");
                        var iABV = r.GetOrdinal("ABV");
                        var iIBU = r.GetOrdinal("IBU");
                        var iEBC = r.GetOrdinal("EBC");

                        //Läser en post i taget från resultatet så länge det finns och skapar där efter objekt med hjälp av dessa
                        while (r.Read())
                        {
                            beers.Add(new Beer
                            {
                                BeerId = r.GetInt32(iBeerId),
                                BeerTypeId = r.GetInt32(iBeerType),
                                BeweryId = r.GetInt32(iBreweryId),
                                Name = r.GetString(iName),
                                StartYear = r.GetString(iStartYear),
                                ABV = (double)r.GetDecimal(iABV),
                                IBU = (int)r.GetByte(iIBU),
                                EBC = (int)r.GetByte(iEBC)
                            });
                        }
                    }
                    beers.TrimExcess();
                    return beers;
                }
                catch
                {
                    throw new ApplicationException("Fel vid läsning från databasen.");
                }
            }
        }

        /// <summary>
        /// Lägger till ny öl i databasen från ett beer-objekt
        /// </summary>
        /// <param name="beer">Beer-objekt</param>
        public void InsertBeer(Beer beer)
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Beer.InsertBeer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BeweryId", SqlDbType.Int, 4).Value = beer.BeweryId;
                    cmd.Parameters.Add("@BeerTypeId", SqlDbType.Int, 4).Value = beer.BeerTypeId;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = beer.Name;
                    cmd.Parameters.Add("@StartYear", SqlDbType.VarChar, 4).Value = beer.StartYear;
                    cmd.Parameters.Add("@ABV", SqlDbType.Decimal, 5).Value = beer.ABV;
                    cmd.Parameters.Add("@IBU", SqlDbType.TinyInt, 1).Value = beer.IBU;
                    cmd.Parameters.Add("@EBC", SqlDbType.TinyInt, 1).Value = beer.EBC;
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
        /// Uppdaterar befintlig öl i databasen
        /// </summary>
        /// <param name="beer">Beer-objekt som ska uppdateras</param>
        public void UpdateBeer(Beer beer)
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Beer.UpdateBeer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BeerId", SqlDbType.Int, 4).Value = beer.BeerId;
                    cmd.Parameters.Add("@BeweryId", SqlDbType.Int, 4).Value = beer.BeweryId;
                    cmd.Parameters.Add("@BeerTypeId", SqlDbType.Int, 4).Value = beer.BeerTypeId;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = beer.Name;
                    cmd.Parameters.Add("@StartYear", SqlDbType.VarChar, 4).Value = beer.StartYear;
                    cmd.Parameters.Add("@ABV", SqlDbType.Decimal, 5).Value = beer.ABV;
                    cmd.Parameters.Add("@IBU", SqlDbType.TinyInt, 1).Value = beer.IBU;
                    cmd.Parameters.Add("@EBC", SqlDbType.TinyInt, 1).Value = beer.EBC;
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
        /// Tar bort en öl ur databasen
        /// </summary>
        /// <param name="beerId">Id på ölen som ska tas bort</param>
        public void DeleteBeer(int beerId)
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Beer.DeleteBeer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BeerId", SqlDbType.Int, 4).Value = beerId;
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