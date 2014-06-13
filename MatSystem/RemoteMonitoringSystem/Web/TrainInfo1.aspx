<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="TrainInfo1.aspx.cs" Inherits="web.TrainInfo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <div id="trantitle">
    </div>
    <div class="clear">
    </div>
    <div  id="traininfo1" >
       
            <asp:Repeater runat="server" ID="RepTrainInfo">
                <HeaderTemplate> 
                <table id="traininfo2">
                  <tr id="traininfo2tr">
                        <td>
                            车号
                        </td>
                        <td>
                            车次
                        </td>
                        <td>
                            往返路线
                        </td>
                        <td>
                            3G通信
                        </td>
                        <td>
                            报警状态
                        </td>
                        <td>
                            发电机
                        </td>
                   </tr>
                    <%--    <ul class="linename"><li >车号</li><li>车次</li><li>往返路线</li><li>3G通信</li><li>报警状态</li><li>发电机</li><span style=" clear:both;"></span></ul>
                    --%>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("seriaNum") %>
                        </td>
                        <td>
                            <%#Eval("train") %>
                        </td>
                        <td>
                            <%#Eval("route") %>
                        </td>
                        <td>
                            <img src="Images/red27.png" id='3g_<%#Eval("seriaNum").ToString().Trim()  %>' alt="" />
                        </td>
                        <td>
                            <img src="Images/green.png" id='bj_<%#Eval("seriaNum").ToString().Trim() %>' alt="" />
                        </td>
                        <td>
                        <img src="Images/r1.png" id='r1_<%#Eval("seriaNum").ToString().Trim() %>' alt="" />
                        <img src="Images/r2.png" id='r2_<%#Eval("seriaNum").ToString().Trim() %>' alt="" />
                        <img src="Images/r3.png" id='r3_<%#Eval("seriaNum").ToString().Trim() %>' alt="" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
        
    </div>
</asp:Content>
