using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.BLL;

namespace web
{
    public partial class InspectionRecords : System.Web.UI.Page
    {
        private int currentPageNum = 1;
        private string serialNum;
        private int totalPage;

        public string Lcnumber;
        public string CheckAllTimes;
        public string CheckTimes;
        public string CheckLateTimes;
        public string CheckNoTimes;
        public string CheckFrequency;
        public string CeckLateFrequency;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                currentPageNum = int.Parse(this.labCurrentPageNum.Text);
                serialNum = dropSerialNum.SelectedValue;
                totalPage = int.Parse(this.labTotalPage.Text);
            }
            else
            {
                this.dropSerialNum.DataSource = GetLcNumberList();
                this.dropSerialNum.DataBind();
                DropDownListLcnumber.DataSource = GetLcNumberList();
                DropDownListLcnumber.DataBind();
                this.dropSerialNum.DataBind();
                this.endtime.Value = DateTime.Now.ToShortDateString();
                this.starttime.Value = DateTime.Now.AddMonths(-1).ToShortDateString();
                this.t2.Value = DateTime.Now.ToShortDateString();
                this.t1.Value = DateTime.Now.AddMonths(-1).ToShortDateString();
                BindData();
                UpdatePageNum();
            }

        }

        private void UpdatePageNum()
        {
            this.lbtnPrePage.Enabled = currentPageNum > 1;
            this.lbtnNextPage.Enabled = currentPageNum < totalPage;
            this.labCurrentPageNum.Text = currentPageNum.ToString();
            this.labTotalPage.Text = totalPage.ToString();
        }

        protected void lbtnPrePage_Click(object sender, EventArgs e)
        {
            currentPageNum--;
            if (currentPageNum < 1)
            {
                currentPageNum = 1;
            }
            BindData();
            UpdatePageNum();
        }

        private void BindData()
        {
            //List<InspectionRecords> records = null;
            //取值
            Maticsoft.BLL.InspectionRecords bll = new Maticsoft.BLL.InspectionRecords();
            DateTime timestart;
            DateTime timeend;
            if (DateTime.TryParse(starttime.Value.Trim(), out timestart) && DateTime.TryParse(endtime.Value.Trim(), out timeend))
            {
                //timestart = DateTime.Parse(starttime.Value.Trim());
                //timeend = DateTime.Parse(endtime.Value.Trim());
                //this.rptInspectionRecords.DataSource = bll.getXjDataTableBypage(dropSerialNum.Text.Trim(), this.starttime.Value.Trim(), this.endtime.Value.Trim(), currentPageNum, 20, out totalPage);
                this.rptInspectionRecords.DataSource = bll.GetPartPageByProcedure(dropSerialNum.Text.Trim(), this.starttime.Value.Trim(), this.endtime.Value.Trim(), currentPageNum, 20, out totalPage);

                this.rptInspectionRecords.DataBind();
            }


        }
        private List<string> GetLcNumberList()
        {
            Maticsoft.BLL.trainInfo bl = new Maticsoft.BLL.trainInfo();

            List<string> lclist = new List<string>();
            foreach (var item in bl.GetModelList(" "))
            {
                lclist.Add(item.seriaNum);
            }
            return lclist;
        }

        protected void lbtnNextPage_Click(object sender, EventArgs e)
        {
            currentPageNum++;
            if (currentPageNum > totalPage)
            {
                currentPageNum = totalPage;
            }
            BindData();
            UpdatePageNum();
        }

        protected void txtJumpNum_TextChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(txtJumpNum.Text, out currentPageNum);
            if (result)
            {
                BindData();
                UpdatePageNum();
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.InspectionRecords bll = new Maticsoft.BLL.InspectionRecords();
           Maticsoft.Model.XjAnalysisModel model= bll.GetXjAnalysisModel(DropDownListLcnumber.Text.Trim(), t1.Value.Trim(), t2.Value.Trim());
           Lcnumber=model.lcNumber;
           CheckAllTimes = model.AllCheckTime.ToString();
           CheckTimes = model.CheckTimes.ToString();
           CheckLateTimes = model.CheckLateTimes.ToString();
           CheckFrequency = (model.CheckFrequency*100).ToString("f2")+"%" ;
           CeckLateFrequency = (model.CheckLateFrequency*100).ToString("f2")+"%";
           CheckNoTimes = (model.AllCheckTime - model.CheckTimes - model.CheckLateTimes).ToString();
         //  Response.Write("<script type=\"text/javascript\"> window.onload=function () {id(\"tagContent1\").style.display = \"block\";id(\"tagContent0\").style.display = \"none\"; };</script>");
           ClientScriptManager csm = this.ClientScript;
           csm.RegisterStartupScript(this.GetType(), "assa", "<script type=\"text/javascript\"> window.onload=function () {id(\"tagContent1\").style.display = \"block\";id(\"selectTag1\").className=\"\";id(\"selectTag2\").className=\"selectTag\";id(\"tagContent0\").style.display = \"none\";};</script>");
           
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            totalPage = 1;//取值
            BindData();
            UpdatePageNum();
        }
        protected void JumpNumbtn_Click(object sender, EventArgs e)
        {
            if (this.txtJumpNum.Text.Trim() == "")
            {
                currentPageNum = 1;
            }
            else
            {
                int currentPageNum;
                if (int.TryParse(txtJumpNum.Text.Trim(), out currentPageNum))
                {
                    currentPageNum = int.Parse(txtJumpNum.Text.Trim());
                    BindData();
                    UpdatePageNum();
                }
                else
                {
                    Response.Write("<script>alert('请输入正确格式的页码！')</script>");
                }
            }

        }
        protected void btnStatisticsQuery_Click(object sender, EventArgs e)
        {
            //查询统计信息
            //绑定
        }
    }
}