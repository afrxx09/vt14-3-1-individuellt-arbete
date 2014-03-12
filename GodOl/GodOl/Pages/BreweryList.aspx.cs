using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages
{
    public partial class BreweryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
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