using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
	public partial class TrainInfo1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            Maticsoft.BLL.trainInfo bll = new Maticsoft.BLL.trainInfo();
            this.RepTrainInfo.DataSource= bll.GetAllList();
            
            this.RepTrainInfo.DataBind();
		}
	}
}