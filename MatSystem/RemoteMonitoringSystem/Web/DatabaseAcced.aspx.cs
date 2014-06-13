using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace web
{
	public partial class DatabaseAcced : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            
                Maticsoft.BLL.trainInfo bl = new Maticsoft.BLL.trainInfo();
                DropdownLcnumber.DataSource = bl.GetLcNumberList("seriaNum", "");
                DropdownLcnumber.DataBind();
                this.endtime.Value = DateTime.Now.ToShortDateString();
                this.starttime.Value = DateTime.Now.AddMonths(-1).ToShortDateString();
                if (Session["lcnum"]!=null)
                {
                    this.lcnum.Text = Session["lcnum"].ToString();
                }
                
		}
	}
}