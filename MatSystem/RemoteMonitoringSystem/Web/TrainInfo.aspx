<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="TrainInfo.aspx.cs" Inherits="web.TrainInfo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <script type="text/javascript">
//    var xmlHttpTrain;
//    function GetTrainStatusRequestUsingGet() {
//        if (window.ActiveXObject)
//            xmlHttpTrain = new ActiveXObject("Microsoft.XMLHTTP");
//        else if (window.XMLHttpRequest)
//            xmlHttpTrain = new XMLHttpRequest();
//        var queryString = "TrainStatus.ashx?";
//        xmlHttpTrain.open("GET", queryString, true);
//        xmlHttpTrain.onreadystatechange = handleStateChange2;
//        xmlHttpTrain.send(null);
//    }

//    function handleStateChange2() {
//        if (xmlHttpTrain.readyState == 4 && xmlHttpTrain.status == 200) {
////            if (decodeURI(xmlHttp.responseText) !== "") {
////                var str = decodeURI(xmlHttp.responseText);
////                var jsondata = eval("(" + str + ")");
////                for (var i = 0; i < jsondata.length; i++) {
////                    var trainId = document.getElementById(jsondata[i].serialNum);

////                    trainId.className = "menu2";
////                    trainId.setAttribute("onclick", "window.location = 'Moncenter.aspx';GetMonCenterRequestUsingGet(" + jsondata[i].serialNum + ")");
////                }

////            }
//        }

//    }
</script>
    <div id="trantitle">
<ul class="linename"><li >车号</li><li>车次</li><li>往返路线</li><li>3G通信</li><li>报警状态</li><li>发电机</li><span style=" clear:both;"></span></ul>
</div>
<div class="clear"></div>
<div id="tranmain">

</div>
<div id="testdiv"></div>
</asp:Content>
