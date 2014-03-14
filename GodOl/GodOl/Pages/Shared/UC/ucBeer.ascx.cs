using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.Shared.UC
{
    public partial class ucBeer : System.Web.UI.UserControl{
        private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        // The id parameter name should match the DataKeyNames value set on the control
        public void lwBeerUserControl_DeleteItem(int beerId)
        {
            try
            {
                var beer = Service.GetBeerById(beerId);
                if (beer == null)
                {
                    Page.ModelState.AddModelError(String.Empty, String.Format("Kunde inte hitta ölen med id-nummer{0}.", beerId));
                    return;
                }

                if (TryUpdateModel(beer))
                {
                    Service.SaveBeer(beer);
                    Page.SetTempData("SuccessMessage", "Ölen sparad");
                    Response.RedirectToRoute("BeerDetails", new { id = beer.BeerId });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Databasfel vid sparning.");
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public GodOl.Model.Beer fwBeer_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetBeerById(id);
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Databasfel vid läsning av data.");
                return null;
            }
        }

        public Beer fwBeer_InsertItem([RouteData]int id)
        {
            try
            {
                return Service.GetBeerById(id);
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Databasfel vid läsning av data.");
                return null;
            }
        }

        public void fwBeer_UpdateItem(int beerId)
        {
            try
            {
                var beer = Service.GetBeerById(beerId);
                if (beer == null)
                {
                    Page.ModelState.AddModelError(String.Empty,
                        String.Format("Kunden med kundnummer {0} hittades inte.", beerId));
                    return;
                }

                if (TryUpdateModel(beer))
                {
                    Service.SaveBeer(beer);

                    Page.SetTempData("SuccessMessage", "Ölen sparades");
                    Response.RedirectToRoute("CustomerDetails", new { id = beer.BeerId });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle uppdateras.");
            }
        }
    }
}