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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtseriaNum.Text.Trim().Length==0)
			{
				strErr+="seriaNum不能为空！\\n";	
			}
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
			string seriaNum=this.txtseriaNum.Text;
			string train=this.txttrain.Text;
			string route=this.txtroute.Text;

			Maticsoft.Model.trainInfo model=new Maticsoft.Model.trainInfo();
			model.seriaNum=seriaNum;
			model.train=train;
			model.route=route;

			Maticsoft.BLL.trainInfo bll=new Maticsoft.BLL.trainInfo();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
