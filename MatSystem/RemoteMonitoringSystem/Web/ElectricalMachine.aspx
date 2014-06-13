<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="ElectricalMachine.aspx.cs" Inherits="web.ElectricalMachine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <script type="text/javascript">
        function homepage() {
            window.location = "TrainInfo.aspx";

        }
        function moncenterclick() {
            window.location = "Moncenter.aspx";

        }
        function databaseclick() {
            window.location = "DatabaseAcced.aspx";

        }
        
        
    </script>
    <div style="height: 30px; width: 760px; margin: 8px 0px; border: 1px solid #cccccc;">
        <div style="float: left; margin: 10px 0px 0px 10px;">
            车号:</div>
        <asp:Label ID="lcnum" runat="server" Style="float: left; margin: 10px 10px 0px 0px;"
            Text="Label"></asp:Label>
        <div style="float: left; margin: 10px 0px 0px 10px;">
            车次：</div>
        <asp:Label ID="checi" runat="server" Style="float: left; margin: 10px 0px 0px 0px;"
            Text="Label"></asp:Label>
        <input type="button" id="homebtn" onclick="homepage();" style="float: right; margin: 5px 15px;
            height: 26px; font-size: 20px;" value="首页" />
        <input type="button" id="Button1"  onclick="moncenterclick()" style="float: right; margin: 5px 0px;
            font-size: 20px; height: 26px; vertical-align: middle;" value="监控中心" />
        <input type="button" id="enginbtn" onclick="databaseclick()" style="float: right; margin: 5px 15px;
            font-size: 20px; height: 26px; vertical-align: middle;" value="数据库" />
        <div style="clear: both;">
        </div>
    </div>
    <div style="border: 1px solid #ccc; height: 480px; width:760px;">

        <div id="con">
            <ul id="tags">
                <li><a onclick="selectTag('tagContent0',this)" href="javascript:void(0)">电机一</a>
                </li>
                <li class="selectTag"><a onclick="selectTag('tagContent1',this)" href="javascript:void(0)">
                    电机二</a> </li>
                <li><a onclick="selectTag('tagContent2',this)" href="javascript:void(0)">电机三</a>
                </li>
            </ul>
            <div id="tagContent">
                <div class="tagContent" id="tagContent0">
                    第一个标签的内容</div>
                <div class="tagContent selectTag" id="tagContent1">
                    第二个标签的内容</div>
                <div class="tagContent" id="tagContent2">
                    第三个标签的内容</div>
            </div>
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
                    for (i = 0; j = document.getElementById("tagContent" + i); i++) {
                        j.style.display = "none";
                    }
                    document.getElementById(showContent).style.display = "block";


                }
            </script>
    </div>
</asp:Content>
