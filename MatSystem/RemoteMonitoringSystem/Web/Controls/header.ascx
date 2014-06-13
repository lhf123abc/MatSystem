<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="Controls.header" %>
<div style="margin-top: 30px;">
    <span style="font-size: xx-large; background-color: inherit; border: 0px; margin-left: 25px;">
        发电车远程监控系统</span>
    <input class="btn" type="button" onclick="homepage()" value="首页" />
    <input class="btn" type="button" onclick="editTrainInfo()" value="列车信息" />
    <input class="btn" type="button" onclick="dataacced()" value="关键数据" />
    <input class="btn" type="button" onclick="monceterbtn()" value="监控中心" />
    <input class="btn" type="button" onclick="xjformbtn()" value="巡检作业" />
    <input class="btn" type="button" onclick="vadioform()" value="视频监控" />
    <br />
    <%--<span style=" float:right;" >设置列车信息</span>--%>
</div>
