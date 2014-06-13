using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.BLL;

namespace Controls
{
    public partial class left : System.Web.UI.UserControl
    {

        public System.Text.StringBuilder LcMenu = new System.Text.StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
                LcMenu.Append("<ul id='menu1'>");
                trainInfo tr = new trainInfo();

                List<Maticsoft.Model.trainInfo> list = new List<Maticsoft.Model.trainInfo>();

                list = tr.GetModelList("");
                //list.Add(new Maticsoft.Model.trainInfo { id = 1, seriaNum = "998318", train = "98", route = "西安--武汉" });

                foreach (var item in list)
                {
                    LcMenu.Append("<li class='menu3' id='" + item.seriaNum.Trim() + "'><img id='munuimg' src='Images\\lc.png'/>" + item.seriaNum.Trim() + "</li>");

                }
                LcMenu.Append("</ul>");
            

        }
    }
}