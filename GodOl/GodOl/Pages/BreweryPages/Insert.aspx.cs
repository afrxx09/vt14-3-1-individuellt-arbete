using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BreweryPages
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void fwInsertBrewery_InsertItem(Brewery brewery)
        {

            if (Page.ModelState.IsValid)
            {
                try
                {
                    var s = new Service();
                    s.SaveBrewery(brewery);

                    Page.SetTempData("SuccessMessage", "Bryggeri har skapats.");
                    Response.RedirectToRoute("BreweryDetails", new { id = brewery.BreweryId });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    Page.ModelState.AddModelError(String.Empty, "Gick inte skriva till databasen.");
                }
            }
        }
    }
}