using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.Beer
{
    public partial class Beer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Model.Beer> lwBeer_GetData()
        {
            try
            {
                Service s = new Service();
                return s.GetBeers();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade när öl skulle hämtas.");
                return null;
            }
        }
    }
}