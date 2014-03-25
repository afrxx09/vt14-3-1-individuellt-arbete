using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BreweryPages
{
    public partial class Details : System.Web.UI.Page
    {
        public int BreweryId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccess.Text = Page.GetTempData("SuccessMessage") as String;
            pnlSuccess.Visible = !String.IsNullOrWhiteSpace(lblSuccess.Text);
        }

        /// <summary>
        /// Hämtar Brewery-objektet till formview-controllen
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Brewery fwBreweryDetails_GetItem([RouteData]int id)
        {
            try
            {
                BreweryId = id;
                var s = new Service();
                return s.GetBreweryById(id);
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Databasfel vid läsning av data.");
                return null;
            }
        }

        /// <summary>
        /// Hämtar lista med referenser till öl från bryggeriet
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Beer> lwBreweryBerList_GetData()
        {
            try
            {
                var s = new Service();
                var breweryBeers = s.GetBeersByBreweryId(BreweryId);
                var beerCount = breweryBeers.Count<Beer>();
                if (beerCount > 0)
                {
                    var hlDeleteButton = fwBreweryDetails.FindControl("hlDeleteBrewery") as HyperLink;
                    hlDeleteButton.Visible = false;
                }
                return breweryBeers;
            }
            catch
            {
                Page.ModelState.AddModelError(String.Empty, "Databasfel vid läsning av data.");
                return null;
            }
        }
    }
}