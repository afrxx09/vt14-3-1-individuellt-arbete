using GodOl.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GodOl.Model
{
    public class Service
    {
        private BeerDAL _beerDAL;
        private BeerTypeDAL _beerTypeDAL;
        private BreweryDAL _breweryDAL;

        #region properties
        private BeerDAL BeerDAL {
            get {
                return _beerDAL ?? (_beerDAL = new BeerDAL());
            }
        }

        private BeerTypeDAL BeerTypeDAL {
            get {
                return _beerTypeDAL ?? (_beerTypeDAL = new BeerTypeDAL());
            }
        }
         
        private BreweryDAL BreweryDAL {
            get {
                return _breweryDAL ?? (_breweryDAL = new BreweryDAL());
            }
        }
        #endregion

        #region Beer-CRUD
        /// <summary>
        /// Skapa en ny öl i databasen eller uppdatera en befintlig.
        /// Om objektet har ett Id så antas det finnas i databasen och därmed bara sparas, annars skapas en ny post.
        /// </summary>
        /// <param name="beer">Beer-objektet som ska sparas alternativt skapas</param>
        public void SaveBeer(Beer beer)
        {
            ICollection<ValidationResult> validationResults;
            if (!beer.Validate(out validationResults))
            {
                var ve = new ValidationException("Objektet klarade inte valideringen.");
                ve.Data.Add("ValidationResults", validationResults);
                throw ve;
            }
            if (beer.BeerId == 0)
            {
                BeerDAL.InsertBeer(beer);
            }
            else
            {
                BeerDAL.UpdateBeer(beer);
            }
        }

        /// <summary>
        /// Ta bort en öl ur databsen med hjälp av id
        /// </summary>
        /// <param name="beerId">Id på ölen som ska hanteras</param>
        public void DeleteBeer(int beerId)
        {
            BeerDAL.DeleteBeer(beerId);
        }

        /// <summary>
        /// Hämta en öl ur databasen med hjälp av dess Id
        /// </summary>
        /// <param name="beerId">Id på ölen som ska hämtas</param>
        /// <returns>Ett Beer-objekt</returns>
        public Beer GetBeerById(int beerId)
        {
            return BeerDAL.GetBeerById(beerId);
        }

        /// <summary>
        /// Hämtar alla öl som finns i databasen.
        /// </summary>
        /// <returns>Lista med referenser till Beer-objekt</returns>
        public IEnumerable<Beer> GetBeers()
        {
            return BeerDAL.GetBeers();
        }

        /// <summary>
        /// Hämtar öl från databasen baserat på vilket bryggeri de kommer från
        /// </summary>
        /// <param name="breweryId">Bryggeriets Id</param>
        /// <returns>Lista med referenser till Beer-objekt</returns>
        public IEnumerable<Beer> GetBeersByBreweryId(int breweryId)
        {
            return BeerDAL.GetBeersByBreweryId(breweryId);
        }
        #endregion

        #region BeerType-CRUD
        /// <summary>
        /// Hämtar BeerType från databasen med hjälp av dess Id
        /// </summary>
        /// <param name="beerTypeId">Id på BeerType som ska hämtas</param>
        /// <returns>Ett BeerType-objekt</returns>
        public BeerType GetBeerTypeById(int beerTypeId)
        {
            return BeerTypeDAL.GetBeerTypeById(beerTypeId);
        }

        /// <summary>
        /// Hämtar alla BeerTypes från databasen
        /// </summary>
        /// <returns>En lista med referenser till BeerType-objekt</returns>
        public IEnumerable<BeerType> GetBeerTypes()
        {
            return BeerTypeDAL.GetBeerTypes();
        }
        #endregion

        #region Brewery-CRUD
        /// <summary>
        /// Hämta ett bryggeri ur databasen med hjälp av dess Id
        /// </summary>
        /// <param name="breweryId">Id till det brewery som ska hämtas</param>
        /// <returns>Ett brewery-objekt</returns>
        public Brewery GetBreweryById(int breweryId)
        {
            return BreweryDAL.GetBreweryById(breweryId);
        }

        /// <summary>
        /// Hämtar alla bryggerier ur databasen
        /// </summary>
        /// <returns>Lista med referenser till Brewery-objekt</returns>
        public IEnumerable<Brewery> GetBreweries()
        {
            return BreweryDAL.GetBreweries();
        }

        /// <summary>
        /// Spara nytt alternativt uppdatera ett bryggeri i databasen.
        /// </summary>
        /// <param name="brewery">Brewery-objekt som ska sparas i databasen</param>
        public void SaveBrewery(Brewery brewery)
        {
            ICollection<ValidationResult> validationResults;
            if (!brewery.Validate(out validationResults))
            {
                var ve = new ValidationException("Objektet klarade inte valideringen.");
                ve.Data.Add("ValidationResults", validationResults);
                throw ve;
            }
            if (brewery.BreweryId == 0)
            {
                BreweryDAL.InsertBrewery(brewery);
            }
            else
            {
                BreweryDAL.UpdateBrewery(brewery);
            }
        }

        /// <summary>
        /// Ta bort ett bryggeri ur databasen med hjälp av dess id
        /// </summary>
        /// <param name="breweryId">Id på det bryggeri som ska tas bort</param>
        public void DeleteBrewery(int breweryId)
        {
            BreweryDAL.DeleteBrewery(breweryId);
        }
        #endregion
    }
}