using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class EditeTrainInfo : System.Web.UI.Page
    {
        private static Maticsoft.BLL.trainInfo bll = new Maticsoft.BLL.trainInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            Bind();
            //}
        }

        private void Bind()
        {
            this.GvTrainInfo.DataSource = bll.GetAllList();
            this.GvTrainInfo.DataBind();
        }

        protected void GvTrainInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GvTrainInfo.PageIndex = e.NewPageIndex;
            Bind();
        }

        protected void GvTrainInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GvTrainInfo.EditIndex = -1;
            Bind();
        }

        protected void GvTrainInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //this.GvTrainInfo.DeleteRow(e.RowIndex);
            string idStr = e.Keys[0].ToString();
            int id = 0;
            int.TryParse(idStr, out id);
            bll.Delete(id);
            Bind();
        }

        protected void GvTrainInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GvTrainInfo.EditIndex = e.NewEditIndex;

            Bind();
        }

        protected void GvTrainInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string idStr = e.Keys[0].ToString();
            int id = 0;
            int.TryParse(idStr, out id);
            Maticsoft.Model.trainInfo newTrainInfo = new Maticsoft.Model.trainInfo();
            newTrainInfo.seriaNum = e.NewValues["seriaNum"] != null ? e.NewValues["seriaNum"].ToString() : null;
            newTrainInfo.train = e.NewValues["train"] != null ? e.NewValues["train"].ToString() : null;
            newTrainInfo.route = e.NewValues["route"] != null ? e.NewValues["route"].ToString() : null;
            newTrainInfo.dhip = e.NewValues["dhip"] != null ? e.NewValues["dhip"].ToString() : null;
            newTrainInfo.id = id;
            bll.Update(newTrainInfo);
            this.GvTrainInfo.EditIndex = -1;
            Bind();


            //foreach (var b in e.NewValues.Keys)
            //{
            //    this.Label1.Text += b+"_"+e.NewValues[b].ToString();
            //}
        }

        protected void BtnAdd_OnClick(object sender, EventArgs e)
        {
            Maticsoft.Model.trainInfo model = new Maticsoft.Model.trainInfo();
            Maticsoft.BLL.trainInfo bll = new Maticsoft.BLL.trainInfo();
            if (this.LCNUM.Text.Trim() != "" && this.CHECI.Text.Trim() != "" && this.ROUTE.Text.Trim() != "" && this.DHIP.Text.Trim() != "")
            {
                model.seriaNum = this.LCNUM.Text.Trim();
                model.train = this.CHECI.Text.Trim();
                model.route = this.ROUTE.Text.Trim();
                model.dhip = this.DHIP.Text.Trim();
                int b = bll.Add(model);
                if (b > 0)
                {
                    Response.Write("<script>alert('" + model.seriaNum + "添加成功！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('添加失败！不能为空')</script>");
            }

        }






    }
}