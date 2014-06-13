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
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.trainInfo
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
	{
		Maticsoft.BLL.trainInfo bll=new Maticsoft.BLL.trainInfo();
		Maticsoft.Model.trainInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblseriaNum.Text=model.seriaNum;
		this.txttrain.Text=model.train;
		this.txtroute.Text=model.route;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttrain.Text.Trim().Length==0)
			{
				strErr+="train不能为空！\\n";	
			}
			if(this.txtroute.Text.Trim().Length==0)
			{
				strErr+="route不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string seriaNum=this.lblseriaNum.Text;
			string train=this.txttrain.Text;
			string route=this.txtroute.Text;


			Maticsoft.Model.trainInfo model=new Maticsoft.Model.trainInfo();
			model.id=id;
			model.seriaNum=seriaNum;
			model.train=train;
			model.route=route;

			Maticsoft.BLL.trainInfo bll=new Maticsoft.BLL.trainInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
