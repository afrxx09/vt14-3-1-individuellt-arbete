using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BeerPages
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Beer FormView1_GetItem([RouteData]int id)
        {
            try
            {
                var s = new Service();
                return s.GetBeerById(id);
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Databasfel vid läsning av data.");
                return null;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormView1_UpdateItem(int beerId)
        {
            var s = new Service();
            Beer beer = s.GetBeerById(beerId);
            if (beer == null)
            {
                ModelState.AddModelError(String.Empty, String.Format("Öl med id{0} kunde inte hittas", beerId));
                return;
            }
            TryUpdateModel(beer);
            if (ModelState.IsValid)
            {
                s.SaveBeer(beer);  
            }
        }
    }
}