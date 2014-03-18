using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BreweryPages
{
    public partial class Delete : System.Web.UI.Page
    {
        protected int Id
        {
            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        /// <summary>
        /// Sätter avbryt-knappens url till rätt bryggeri och ändrar namnet i varningstexten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            hlCancelDelete.NavigateUrl = GetRouteUrl("BreweryDetails", new { id = Id });
            if (!IsPostBack)
            {
                try
                {
                    var s = new Service();
                    var brewery = s.GetBreweryById(Id);
                    if (brewery != null)
                    {
                        lblBreweryName.Text = brewery.Name;
                        return;
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, String.Format("Bryggeriet med id: {0} existerar inte.", Id));
                    }
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, "Fel vid läsning från databasen.");
                }
                lbConfirmDelete.Visible = false;
                phConfirmMessage.Visible = false;

            }
        }

        /// <summary>
        /// Borttagningen av bryggeriet har konfirmerats av användaren, service-klassen tar bort det.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbConfirmDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var s = new Service();
                s.DeleteBrewery(Id);

                Page.SetTempData("SuccessMessage", "Bryggeriet togs bort.");
                Response.RedirectToRoute("BreweryList", null);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett databasfel uppstod i samband med borttagningen.");
            }
        }
    }

}