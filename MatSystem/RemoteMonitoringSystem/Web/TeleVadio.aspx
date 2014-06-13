<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeleVadio.aspx.cs" Inherits="web.TeleVadio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        *
        {
            margin: 0px auto;
        }
        #menubtn
        {
            list-style-type: none;
        }
        # menubtn li a
        {
            font-size: 38px;
            line-height: 40px;
        }
        #menubtn li
        {
            margin: 10px 0px;
        }
    </style>
    <script type="text/javascript">
        function myfunction() {
            var ocx = document.getElementById("DHDeviceConfig");
            ocx
        }
        function StartPreview(id) {
            var SSOcx = document.getElementById("playOcx");
            var ipaddr = document.getElementById("ipaddress");
            var port = document.getElementById("port");
            if (ipaddr.value == "") {
                alert('请输入ip地址！');
            }
            else {
                if (check(ipaddr.value)) {
                    try {
                        SSOcx.SetDeviceInfo(ipaddr.value,port.value, id, "admin", "admin");
                        SSOcx.StartPlay();
                    } catch (e) {
                        alert("缺少RealPlayX插件");
                    }

                }
                else {
                    alert("请输入正确格式的ip地址！");
                }
            }

        }


        function StoptPreview() {
            try {
                var SSOcx = document.getElementById("playOcx");
                SSOcx.StopPlay();
            } catch (e) {
                alert("缺少RealPlayX插件");
            }


        }

        function Capture() {

            var SSOcx = document.getElementById("playOcx");
            try {
                var dd = SSOcx.GetCapturePicture("d:\\1.bmp");
            } catch (e) {
                alert("缺少RealPlayX插件");
            }

            var sp = document.getElementById("showpath");

        }

        var intervalid;
        var inta = 0;
        var pathprompt
        function StartRecord() {
            inta++;
            var SSOcx = document.getElementById("playOcx");
            try {
                SSOcx.SaveRealData("d:\\1.avi");


                if (inta == 1) {
                    intervalid = setInterval(imgflicker, 500);
                }
                pathprompt = document.getElementById("showpath");
                pathprompt.innerHTML = "录制路径为d:\\1.avi";
                showpath.style.color = col[15];
            } catch (e) {
                alert("缺少RealPlayX插件");
            }
        }

        function StopRecord() {
            var aa = document.getElementById("startrecordimg");
            try {
                var SSOcx = document.getElementById("playOcx");
                SSOcx.StopSaveRealDate();
            } catch (e) {
                alert("缺少RealPlayX插件");
            }

            clearInterval(intervalid);
            aa.style.visibility = "hidden";
            inta = 0;
            i = col.length;
            Over();
        }

        function check(ip) {
            var pattern = /^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$/;
            flag_ip = pattern.test(ip);
            return flag_ip;
        }


        function imgflicker() {
            var aa = document.getElementById("startrecordimg");
            if (aa.style.visibility == "visible") {

                aa.style.visibility = "hidden"
            }
            else {
                aa.style.visibility = "visible"
            }
        }

        var col = new Array();
        col[15] = '#000000';
        col[14] = '#111111';
        col[13] = '#222222';
        col[12] = '#333333';
        col[11] = '#444444';
        col[10] = '#555555';
        col[9] = '#666666';
        col[8] = '#777777';
        col[7] = '#888888';
        col[6] = '#999999';
        col[5] = '#AAAAAA';
        col[4] = '#BBBBBB';
        col[3] = '#CCCCCC';
        col[2] = '#DDDDDD';
        col[1] = '#EEEEEE';
        col[0] = '#FFFFFF';
        var i = col.length;

        //        var isOut = true;
        function Over() {

            //            if (i >= 0 && isOut) { i--; showpath.style.color = col[i]; }
            //            else if (i <= col.length && !isOut) { i++; showpath.style.color = col[i]; }
            //            else { isOut = !isOut; }
            if (i > 0) {
                i--; showpath.style.color = col[i];
            }
            var intval = setTimeout('Over()', 100);
        } 



    </script>
</head>
<body>
    <div style="width: 1024px; height: 80px; margin: 0px auto;">
    </div>
    <div style="width: 980px; margin: 0px auto; height: 450px; border: 1px solid red;">
        <div style="float: left; height: 450px;">
            <div>
                <form id="formvadio" runat="server">
                <asp:ListBox ID="lcNumlist" runat="server" OnSelectedIndexChanged="lcNumlist_OnSelectedIndexChanged"
                    Width="130px" Font-Size="Medium" AutoPostBack="true"></asp:ListBox>
                <br />
                <br />
                <span style="font: 28px; color: blue;">ip:地址</span><br />
                <input type="text" id="ipaddress" runat="server" /><br />
                <input type="text" id="port" runat="server" />
                </form>
            </div>
            <ul id="menubtn">
                <li><a href="javascript:StartPreview(0)">通道一</a></li>
                <li><a href="javascript:StartPreview(1)">通道二</a></li>
                <li><a href="javascript:StartPreview(2)">通道三</a></li>
                <li><a href="javascript:StartPreview(3)">通道四</a></li>
                <li><a href="javascript:StartPreview(4)">通道五</a></li>
                <li style="border-bottom: 2px dashed #ccc; width: 180px; height: 20px; margin-left: -40px;">
                </li>
                <li><a href="javascript:StartPreview()">播放</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:StoptPreview()">暂停</a></li>
                <li><a href="javascript:StartRecord()">录制</a><img id="startrecordimg" style="visibility: hidden;"
                    src="Images/red.png" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:StopRecord()">停止录制</a></li>
                <li><a href="javascript:Capture()">拍照</a></li>
                <li></li>
                <li><span id="showpath"></span></li>
                <li ><a href="http://10.107.241.158/Realp_ayX.ocx.rar">Realp_ayX.ocx.rar</a> </li>
            </ul>
            
        </div>
        <div style="width: 760px; float: right; background: #999999; height: 450px;">
            <object classid="clsid:30209FBC-57EB-4F87-BF3E-740E3D8019D2" codebase="RealPlayX.ocx＃version=1,0,0,1"
                standby="Waiting..." id="playOcx" width="760" height="450" name="playOcx" align="center">
                <embed width="618" height="360" align="center"></embed>
            </object>
            <%-- <object classid="clsid:108D3206-846A-4A93-BACB-F0572D043ED7" codebase="webrec.ocx＃version=2,1,7,12"
                standby="Waiting..." id="Object1" width="760" height="450" name="playOcx1" align="center">
                <embed width="618" height="360" align="center"></embed>--%>
            </object>
        </div>
    </div>
</body>
</html>
