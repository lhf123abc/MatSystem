<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Moncenter.aspx.cs" Inherits="Web.Moncenter" %>
<asp:Content ID="Content3" ContentPlaceHolderID="center" runat="server">
    <form id="form1" runat="server">
    <script type="text/javascript" src="js/alarmAnalysis.js"></script>
    <script type="text/javascript">

        domReady(function () {
            // document.write("domreay");
            setInterval(function () {
                //document.getElementById("test").innerHTML += "setInterval</br>"
                var httpRequest = createXMLHttpRequest();
                httpRequest.onreadystatechange = function () {
                    // document.getElementById("test").innerHTML += httpRequest.readyState + "</br>"
                    if (httpRequest.readyState == 4 && httpRequest.status == 200) {
                        // alert(httpRequest.responseText);
                        realDataCallBack(httpRequest.responseText);
                        delete httpRequest;
                    }
                }
                httpRequest.open("GET", "RealTimeDataHandler.ashx?opCode=0&sN=" + id("lcnum").innerText, true); //+ id("lcnum").innerText
               // document.getElementById("test").innerHTML += "OPenl</br>"
                httpRequest.send(null);


            }, 800);
        });


        function realDataCallBack(responseData) {
            // document.write(responseData);
           // document.getElementById("test").innerHTML += responseData + "</br>";
            if (!responseData) {
                return;
            }
            var responseArray = responseData.split("&&");
            //id("divChart1Bak").innerHTML = responseArray[0];
            id("divChart1").innerHTML = responseArray[0];
           
            
         //   id("divChart2Bak").innerHTML = responseArray[1];
            id("divChart2").innerHTML = responseArray[1];
           
            //id("divChart3Bak").innerHTML = responseArray[2];
            id("divChart3").innerHTML = responseArray[2];
            
            var data = eval('(' + responseArray[3] + ')');
            for (var i in data) {
                var idStr = "lab_g" + data[i].GeneratorId + "_";
                for (var d in data[i]) {
                    var idStr1 = idStr + d;
                    var obj = id(idStr1);
                    if (obj) {
                        obj.innerText = data[i][d];
                    }
                }

                var _alarmInfo = new alarmInfo(data[i].AlarmValue);
           
                switch (data[i].GeneratorId) {
                    case 1:
                        id("i_g1_OilPress").setAttribute("src", _alarmInfo.getAlarmOP1() ? "Images/red.png" : "Images/green1.png");
                        id("i_g1_WaterTemp").setAttribute("src", _alarmInfo.getAlarmWT1() ? "Images/red.png" : "Images/green1.png");
                        id("i_g1_MotorSpeed").setAttribute("src", _alarmInfo.getAlarmMS1() ? "Images/red.png" : "Images/green1.png");
                        id("i_g1_OilLeak").setAttribute("src", _alarmInfo.getOilLeak1() ? "Images/red.png" : "Images/green1.png");
                        id("lab_g1_OilLeak").innerHTML = "True";
                        break;
                    case 2:
                        id("i_g2_OilPress").setAttribute("src", _alarmInfo.getAlarmOP2() ? "Images/red.png" : "Images/green1.png");
                        id("i_g2_WaterTemp").setAttribute("src", _alarmInfo.getAlarmWT2() ? "Images/red.png" : "Images/green1.png");
                        id("i_g2_MotorSpeed").setAttribute("src", _alarmInfo.getAlarmMS2() ? "Images/red.png" : "Images/green1.png");
                        id("i_g2_OilLeak").setAttribute("src", _alarmInfo.getOilLeak2() ? "Images/red.png" : "Images/green1.png");
                        id("lab_g2_OilLeak").innerHTML = "True";
                        break;
                    case 3:
                        id("i_g3_OilPress").setAttribute("src", _alarmInfo.getAlarmOP3() ? "Images/red.png" : "Images/green1.png");
                        id("i_g3_WaterTemp").setAttribute("src", _alarmInfo.getAlarmWT3() ? "Images/red.png" : "Images/green1.png");
                        id("i_g3_MotorSpeed").setAttribute("src", _alarmInfo.getAlarmMS3() ? "Images/red.png" : "Images/green1.png");
                        id("i_g3_OilLeak").setAttribute("src", _alarmInfo.getOilLeak3() ? "Images/red.png" : "Images/green1.png");
                        id("lab_g3_OilLeak").innerHTML = "True";
                        break;
                }
            }
            if (data) {
                var alarmInfo1 = new alarmInfo(data[0].AlarmValue);
                id("i_upOilPlace").setAttribute("src", alarmInfo1.getUpOilPlace() ? "Images/red.png" : "Images/green1.png");
                id("i_upWaterPlace").setAttribute("src", alarmInfo1.getUpWaterPlace() ? "Images/red.png" : "Images/green1.png");
                id("i_bv").setAttribute("src", alarmInfo1.getBatteryVoltage() ? "Images/red.png" : "Images/green1.png");
                id("i_fireAlarm").setAttribute("src", alarmInfo1.getFireAlarm() ? "Images/red.png" : "Images/green1.png");
            }

        }     

         
            
     
    </script>
  
<div style=" height:30px; width:760px; margin:8px 10px;border: 1px solid #cccccc;">
     <div style="float:left; margin:10px 0px 0px 10px;">车号:</div>
     <asp:Label ID="lcnum" runat="server" style=" float:left; margin:10px 10px 0px 0px;" Text="" ClientIDMode="Static"></asp:Label>
      <span style="float: right; margin: 10px 10px 0px 0px;">当前位置：监控中心</span>
    <div style="clear:both;"></div>
</div>


<div style=" margin-top:0px; padding:0px; height:487px; background:#ccc; width:760px;">
<div class="monhead">
<div class="montitle" > 监控中心</div>
<div class="monbaojing">
<ul class="monul">
<li><img id="i_upOilPlace" src="Images/green1.png"/>&nbsp;上邮箱油位：<label id="lab_upOilPlace"></label></li>
<li><img id="i_upWaterPlace" src="Images/green1.png"/>&nbsp;上水箱水位：<label id="lab_upWaterPlace"></label></li>
<li><img id="i_bv" src="Images/green1.png"/>&nbsp;蓄电池电压：<label id="lab_bv" ></label></li>
<li><img id="i_fireAlarm" src="Images/green1.png"/>&nbsp;烟火：<label id="lab_fireAlarm" ></label></li>
</ul>
</div>
</div>
<div class="montable">
<div id="divChart1" class="monchart"></div>
<div id="divChart1Bak"></div>
<div id="divData1" class="mondata">
<ul>
<li><span>频率</span></li>
<li><label id="lab_g1_Frequency"></label></li>
<li><img src="Images/green1.png" id="i_g1_OilPress" alt="" /><span>机油压力</span></li>
<li><label id="lab_g1_OilPress"></label></li>
<li><span>功率因素</span></li>
<li><label id="lab_g1_PowerFactor"></label></li>
<li><img src="Images/green1.png" id="i_g1_WaterTemp" alt="" /><span>冷却水温</span></li>
<li><label id="lab_g1_WaterTemp"></label></li>
<li><img src="Images/green1.png" id="i_g1_MotorSpeed" alt="" /><span>采油机转速</span></li>
<li><label id="lab_g1_MotorSpeed"></label></li>
<li><span>发电机功率</span></li>
<li><label id="lab_g1_MotorPower"></label></li>
<li><span>发电机输出电压</span></li>
<li><label id="lab_g1_Voltage"></label></li>
<li><span>发电机输出电流</span></li>
<li><label id="lab_g1__Current"></label></li>
<li><img src="Images/green1.png" id="i_g1_OilLeak"/><span>油管泄漏</span></li>
<li><label id="lab_g1_OilLeak"></label></li>
</ul>
</div>
</div>
<div class="montable">
<div id="divChart2" class="monchart"></div>
<div id="divChart2Bak"></div>
<div id="divData2" class="mondata">
<ul>
<li><span>频率</span></li>
<li><label id="lab_g2_Frequency"></label></li>
<li><img src="Images/green1.png" id="i_g2_OilPress" /><span>机油压力</span></li>
<li><label id="lab_g2_OilPress"></label></li>
<li><span>功率因素</span></li>
<li><label id="lab_g2_PowerFactor"></label></li>
<li><img src="Images/green1.png" id="i_g2_WaterTemp" /><span>冷却水温</span></li>
<li><label id="lab_g2_WaterTemp"></label></li>
<li><img src="Images/green1.png" id="i_g2_MotorSpeed" /><span>采油机转速</span></li>
<li><label id="lab_g2_MotorSpeed"></label></li>
<li><span>发电机功率</span></li>
<li><label id="lab_g2_MotorPower"></label></li>
<li><span>发电机输出电压</span></li>
<li><label id="lab_g2_Voltage"></label></li>
<li><span>发电机输出电流</span></li>
<li><label id="lab_g2__Current"></label></li>
<li><img src="Images/green1.png" id="i_g2_OilLeak"/><span>油管泄漏</span></li>
<li><label id="lab_g2_OilLeak"></label></li>
</ul>
</div>
</div>
<div class="montable">
<div id="divChart3" class="monchart"></div>
<div id="divChart3Bak"></div>
<div id="divData3" class="mondata">
<ul>
<li><span>频率</span></li>
<li><label id="lab_g3_Frequency"></label></li>
<li><img src="Images/green1.png" id="i_g3_OilPress" /><span>机油压力</span></li>
<li><label id="lab_g3_OilPress"></label></li>
<li><span>功率因素</span></li>
<li><label id="lab_g3_PowerFactor"></label></li>
<li><img src="Images/green1.png" id="i_g3_WaterTemp" /><span>冷却水温</span></li>
<li><label id="lab_g3_WaterTemp"></label></li>
<li><img src="Images/green1.png" id="i_g3_MotorSpeed" /><span>采油机转速</span></li> 
<li><label id="lab_g3_MotorSpeed"></label></li>
<li><span>发电机功率</span></li>
<li><label id="lab_g3_MotorPower"></label></li>
<li><span>发电机输出电压</span></li>
<li><label id="lab_g3_Voltage"></label></li>
<li><span>发电机输出电流</span></li>
<li><label id="lab_g3__Current"></label></li>
<li><img src="Images/green1.png" id="i_g3_OilLeak"/><span>油管泄漏</span></li>
<li><label id="lab_g3_OilLeak"></label></li>
</ul>
</div>
</div>
</div>
    </form>
    
</asp:Content>
