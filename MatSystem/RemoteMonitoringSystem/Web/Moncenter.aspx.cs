using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Web
{
    public partial class Moncenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lcnum.Text = Request.QueryString["lcnum"];
            //if (Session["lcnum"]!=null)
            //{
            //    this.lcnum.Text = Session["lcnum"].ToString() ;
            //}
            
        }
    }
}
