using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CartagenaZuyd5LayerDemo.CC;

namespace CartagenaZuyd5LayerDemo
{
    public partial class UISpelAanmaken : System.Web.UI.Page
    {
        private CCSpelAanmaken mijnCC;

        protected void Page_Load(object sender, EventArgs e)
        {
            mijnCC = new CCSpelAanmaken();
        }

        protected void btAanmaken_Click(object sender, EventArgs e)
        {
            Dictionary<String, Object> spel = new Dictionary<string, object>();

            spel["SpelNaam"] = tbSpelnaam.Text;
            spel["AantalSpelers"] = ddlAantalSpelers.SelectedValue;
            spel["Gestart"] = cbGestart.Checked;

            Dictionary<string, object> aangemaaktSpel = mijnCC.MaakSpel(spel);

            lblSpelnaam.Text = (string)aangemaaktSpel["SpelNaam"];
            lblAantalSpelers.Text = ((int)aangemaaktSpel["AantalSpelers"]).ToString();
            if ((bool) aangemaaktSpel["Gestart"])
            {
                lblGestart.Text = "Ja";
            }
            else
            {
                lblGestart.Text = "Nee";
            }

        }
    }
}