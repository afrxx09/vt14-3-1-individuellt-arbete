using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BeerPages
{
    public partial class BeerList : System.Web.UI.Page
    {
        /// <summary>
        /// Visar meddelande som sparats i en session om exempelvis borttagning har gått korrekt till
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccess.Text = Page.GetTempData("SuccessMessage") as String;
            pnlSuccess.Visible = !String.IsNullOrWhiteSpace(lblSuccess.Text);
        }

        /// <summary>
        /// Hämtar data till ListView:n som renderar ut ölen
        /// </summary>
        /// <returns>Lista med Referenser till beer-objekt</returns>
        public IEnumerable<Beer> ListView1_GetData()
        {
            try
            {
                var s = new Service();
                return s.GetBeers();
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Kunde inte hämta öl...");
                return null;
            }
        }

        /// <summary>
        /// Hämtar öltyp och bryggeri med hjälp av de id:n som finns i beer-objektet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var beer = (Beer)e.Item.DataItem;
            var s = new Service();

            var beerType = s.GetBeerTypeById(beer.BeerTypeId);
            var brewery = s.GetBreweryById(beer.BreweryId);

            var lblBeerType = e.Item.FindControl("lblBeerType") as Label;
            var hlBrewery = e.Item.FindControl("hlBrewery") as HyperLink;

            lblBeerType.Text = beerType.BType;
            hlBrewery.Text = brewery.Name;
            hlBrewery.NavigateUrl = GetRouteUrl("BreweryDetails", new { id = brewery.BreweryId });
        }


    }
}