using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BreweryPages
{
    public partial class BreweryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccess.Text = Page.GetTempData("SuccessMessage") as String;
            pnlSuccess.Visible = !String.IsNullOrWhiteSpace(lblSuccess.Text);
        }
        
        /// <summary>
        /// Hämtar bryggerier till listview-controlern
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Brewery> lwBreweries_GetData()
        {
            try
            {
                var s = new Service();
                return s.GetBreweries();
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade, kunde inte hämta bryggerier");
                return null;
            }
        }
    }
}