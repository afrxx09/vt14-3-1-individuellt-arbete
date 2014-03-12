using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GodOl.Model.DAL
{
    public class BeerTypeDAL : BaseDAL
    {

        /// <summary>
        /// Hämtar alla öltyper från databasen
        /// </summary>
        /// <returns>Lista med referenser till BeerType-objekt</returns>
        public IEnumerable<BeerType> GetBeerTypes()
        {
            //Skapar ett SQLConnection-objekt från Bas-klassen
            using (var con = CreateConnection())
            {
                try
                {
                    //Skapar Command-objekt för att exekvera Lagrade procedurer och ställa in parametrar till dessa
                    var cmd = new SqlCommand("Beer.GetBeerTypes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    //Lista med BeerTypes för att lagra resultaten från databasen.
                    var beertypes = new List<BeerType>(20);

                    //Skapar ett Reader-objekt som kan läsa posterna i svaret
                    using (var r = cmd.ExecuteReader())
                    {
                        //Tar fram index på fälten med hjälp av readern för att kunna hantera dem dynamiskt(associativt)
                        var iBeerTypeId = r.GetOrdinal("BeerTypeId");
                        var iBeerType= r.GetOrdinal("BeerType");

                        //Läser en post i taget från resultatet så länge det finns och skapar där efter objekt med hjälp av dessa
                        while (r.Read())
                        {
                            beertypes.Add(new BeerType
                            {
                                BeerTypeId = r.GetInt32(iBeerTypeId),
                                BType = r.GetString(iBeerType)
                            });
                        }
                    }
                    beertypes.TrimExcess();
                    return beertypes;
                }
                catch
                {
                    throw new ApplicationException("Fel vid läsning från databasen.");
                }
            }
        }

        /// <summary>
        /// Hämtar en öltyp från databasen
        /// </summary>
        /// <param name="beerTypeId">Id på den öltyp som ska hämtas</param>
        /// <returns>Ett BeerType-objekt</returns>
        public BeerType GetBeerTypeById(int beerTypeId)
        {
            //Skapar ett SQLConnection-objekt från Bas-klassen
            using (var con = CreateConnection())
            {
                try
                {
                    //Skapar Command-objekt för att exekvera Lagrade procedurer och ställa in parametrar till dessa
                    var cmd = new SqlCommand("Beer.GetBeerTypeById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BeerTypeId", SqlDbType.Int, 4).Value = beerTypeId;
                    con.Open();

                    //Skapar ett Reader-objekt som kan läsa posterna i svaret
                    using (var r = cmd.ExecuteReader())
                    {
                        //Om det finns resultat att läsa från så skapas och returnas ett BeerType-objekt
                        if (r.Read())
                        {
                            //Tar fram index på fälten med hjälp av readern för att kunna hantera dem dynamiskt(associativt)
                            var iBeerTypeId = r.GetOrdinal("BeerTypeId");
                            var iBeerType = r.GetOrdinal("BeerType");
                            return new BeerType
                            {
                                BeerTypeId = r.GetInt32(iBeerType),
                                BType = r.GetString(iBeerType)
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
    }
}