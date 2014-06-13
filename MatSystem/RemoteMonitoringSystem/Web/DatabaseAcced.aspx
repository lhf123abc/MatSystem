<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeBehind="DatabaseAcced.aspx.cs" Inherits="web.DatabaseAcced" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <script type="text/javascript">
        function homepage() {
            window.location = "TrainInfo.aspx";

        }
        function moncenterclick() {
            window.location = "Moncenter.aspx";

        }
        function enginclick() {
            window.location = "ElectricalMachine.aspx";

        }

        var xmlHttp;
        function createxmlHttpRequest() {
            if (window.ActiveXObject)
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            else if (window.XMLHttpRequest)
                xmlHttp = new XMLHttpRequest();
        }
        function createQueryString() {
            var droplcnumber = document.getElementById("<%=DropdownLcnumber.ClientID %>").value;
            var starttime = document.getElementById("<%=starttime.ClientID %>").value;
            var endtime = id("<%=endtime.ClientID %>").value;
            var queryString = "droplcnumber=" + droplcnumber + "&starttime=" + starttime + "&endtime=" + endtime + "&type=0";
            return encodeURI(encodeURI(queryString)); //防止乱码

        }
        function createQueryString2() {
            var currentpage = document.getElementById("currentpage").innerText;
            var droplcnumber = document.getElementById("<%=DropdownLcnumber.ClientID %>").value;
            var starttime = document.getElementById("<%=starttime.ClientID %>").value;
            var endtime = id("<%=endtime.ClientID %>").value;
            var queryString = "currentpage=" + currentpage + "&droplcnumber=" + droplcnumber + "&starttime=" + starttime + "&endtime=" + endtime + "&type=1";
            return encodeURI(encodeURI(queryString)); //防止乱码

        }
        function prepage() {
            var currentpage = document.getElementById("currentpage").innerText;
            if ( parseInt( currentpage) >= 2) {
                document.getElementById("currentpage").innerText = --currentpage;
                getpartpage();
            }
            else {
                document.getElementById("currentpage").disabled = false;
            }

        }
        function indexpage() {

            document.getElementById("currentpage").innerText = 1;
            getpartpage();
        }
        function nextpage() {
            var currentpage = document.getElementById("currentpage").innerText;
            var totalpage = document.getElementById("lbpagetotal").innerText;
            if (parseInt(currentpage) < parseInt(totalpage)) {
                document.getElementById("currentpage").innerText = ++currentpage;
                getpartpage();
            }

        }
        function jumpToPage() {
            //            var pageto = document.getElementById("jumpto").value;
            if (!isNaN(document.getElementById("jumpto").value)) {
                document.getElementById("currentpage").innerText = document.getElementById("jumpto").value;
                getpartpage();
            }
        }
        function doRequestUsingGet() {
            createxmlHttpRequest();
            document.getElementById("currentpage").innerText = "1";
            var queryString = "DataAccessAjaxHandler.ashx?";
            queryString += createQueryString();
            xmlHttp.open("GET", queryString, true);
            xmlHttp.onreadystatechange = handleStateChange;
            xmlHttp.send(null);
        }
        function getpartpage() {
            createxmlHttpRequest();
            var queryString = "DataAccessAjaxHandler.ashx?";
            queryString += createQueryString2();
            xmlHttp.open("GET", queryString, true);
            xmlHttp.onreadystatechange = handleStateChange;
            xmlHttp.send(null);
        }
        function doRequestUsingPost() {
            createxmlHttpRequest();
            var url = "DataAccessAjaxHandler.ashx?timestamp=" + new Date().getTime();
            var queryString = createQueryString();
            xmlHttp.open("POST", url);
            xmlHttp.onreadystatechange = handleStateChange;
            xmlHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xmlHttp.send(queryString);
        }
        function handleStateChange() {
            if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
                var responseDiv = document.getElementById("tagContentd0");
                if (decodeURI(xmlHttp.responseText) !== "") {
                    var str = decodeURI(xmlHttp.responseText).split('&&')[1];
                    responseDiv.innerHTML = decodeURI(xmlHttp.responseText).split('&&')[0];
                    document.getElementById("lbpagetotal").innerHTML = str;
                }

            }
        }

    </script>
    <form id="form1" runat="server">
    <div style="height: 30px; width: 760px; margin: 8px 10px; border: 1px solid #cccccc;">
        <div style="float: left; margin: 10px 0px 0px 10px;">
            车号:</div>
        <asp:Label ID="lcnum" runat="server" Style="float: left; margin: 10px 10px 0px 0px;"
            Text=""></asp:Label>
        <span style="float: right; margin: 10px 10px 0px 0px;">当前位置：关键数据</span>
        <%--<input type="button" id="homebtn" onclick="javascript:window.location='TrainInfo.aspx;'" style="float: right; margin: 5px 15px;
            height: 26px; font-size: 20px;" value="首页" />
        <input type="button" id="Button1" onclick="moncenterclick()" style="float: right;
            margin: 5px 0px; font-size: 20px; height: 26px; vertical-align: middle;" value="监控中心" />
        <input type="button" id="enginbtn" onclick="enginclick()" style="float: right; margin: 5px 15px;
            font-size: 20px; height: 26px; vertical-align: middle;" value="电机状态" />--%>
        <div style="clear: both;">
        </div>
    </div>
    <div style="border: 1px solid #ccc; height: 480px; width: 760px;">
        <span>车号:</span><asp:DropDownList ID="DropdownLcnumber" runat="server">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp; <span>日期:</span>
        <input type="text" id="starttime" runat="server" onclick="WdatePicker()" />&nbsp;——
        <input type="text" id="endtime" runat="server" onclick="WdatePicker()" />
        <input type="button" value="查询" onclick="doRequestUsingGet()" />
        <div id="con">
            <ul id="tags">
                <li class="selectTag"><a onclick="selectTag('tagContentd0',this)" href="javascript:void(0)">
                    关键数据</a> </li>
                <li><a onclick="selectTag('tagContentd1',this)" href="javascript:void(0)">导出</a>
                </li>
                <%--<li><a onclick="selectTag('tagContentd2',this)" href="javascript:void(0)">电机三</a>
                </li>
                <li><a onclick="selectTag('tagContentd3',this)" href="javascript:void(0)">导出</a>
                </li>--%>
            </ul>
            <div id="tagContentd">
                <div class="tagContentd selectTag" id="tagContentd0">
                </div>
               <div class="tagContentd " id="tagContentd1">
                    </div>
                <%--<div class="tagContentd" id="tagContentd2">
                    第三个标签的内容</div>
                <div class="tagContentd" id="tagContentd3">
                    第四个标签的内容</div>--%>
            </div>
            <label style="cursor: pointer;" id="uppage" onclick="prepage()">
                上一页</label>&nbsp;<label style="cursor: pointer;" id="homepage" onclick="indexpage()">首页</label>&nbsp;<label
                    style="cursor: pointer;" id="downpage" onclick="nextpage()">下一页</label>
            当前<label id="currentpage"></label>页&nbsp;&nbsp;&nbsp;&nbsp; 共<label id="lbpagetotal"
                style="width: 32px"></label>页
            <input type="text" id="jumpto" style="width: 30px" />&nbsp;<input type="button" onclick="jumpToPage()"
                value="跳转" />
        </div>
        <script type="text/javascript">
            function selectTag(showContent, selfObj) {
                // 操作标签
                var tag = document.getElementById("tags").getElementsByTagName("li");
                var taglength = tag.length;
                for (i = 0; i < taglength; i++) {
                    tag[i].className = "";
                }
                selfObj.parentNode.className = "selectTag";
                // 操作内容
                for (i = 0; j = document.getElementById("tagContentd" + i); i++) {
                    j.style.display = "none";
                }
                document.getElementById(showContent).style.display = "block";

            }
        </script>
    </div>
    </form>
</asp:Content>
