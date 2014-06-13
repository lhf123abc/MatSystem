using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace web
{
	public partial class TeleVadio : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {


                Maticsoft.BLL.trainInfo bll = new Maticsoft.BLL.trainInfo();
                List<Maticsoft.Model.trainInfo> list = bll.GetModelList("");
                ListItem listitem = new ListItem();
                foreach (var item in list)
                {
                    listitem = new ListItem(item.seriaNum.Trim(), item.dhip.Trim());
                    lcNumlist.Items.Add(listitem);
                }
            }
            //this.lcNumlist.SelectedIndexChanged+=new EventHandler((o,j)=>{
            //    ListBox lb = o as ListBox;
            //   this.ipaddress.Value=  lb.SelectedItem.Value;
            
            //});
		}
        protected void lcNumlist_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string[] strarry=this.lcNumlist.SelectedItem.Value.Split(':');
            this.ipaddress.Value =strarry[0];
            this.port.Value = strarry[1].Trim();
        }
	}
}