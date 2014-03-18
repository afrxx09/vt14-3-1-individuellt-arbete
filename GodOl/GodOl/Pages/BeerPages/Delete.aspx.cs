using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BeerPages
{
    public partial class Delete : System.Web.UI.Page
    {
        private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected int Id
        {
            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        /// <summary>
        /// Länkar avbryt-knappen til rätt öl och sätter in namnet på ölen i konfirmations-texten.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            hlCancelDelete.NavigateUrl = GetRouteUrl("BeerDetails", new { id = Id });
            if (!IsPostBack)
            {
                try
                {
                    var beer = Service.GetBeerById(Id);
                    if (beer != null)
                    {
                        lblBeerName.Text = beer.Name;
                        return;
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, String.Format("Ölet med id: {0} existerar inte.", Id));
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
        /// Borttagningen av ölen har konfirmerats, ölen tas bort.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbConfirmDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                Service.DeleteBeer(Id);

                Page.SetTempData("SuccessMessage", "Ölen togs bort.");
                Response.RedirectToRoute("BeerList", null);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett databasfel uppstod i samband med borttagningen.");
            }
        }
    }
}