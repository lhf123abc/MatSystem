<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="InspectionRecords.aspx.cs" Inherits="web.InspectionRecords" %>


<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    
    <form id="form1" runat="server" style="height: 522px">
    <div>
        <div id="con">
            <ul id="tags">
                <li id="selectTag1" class="selectTag"><a onclick="selectTag('tagContent0',this)" href="javascript:void(0)">巡检记录</a>
                </li >
                <li  id="selectTag2"><a onclick="selectTag('tagContent1',this)" href="javascript:void(0)">
                    巡检记录分析</a> </li>
            </ul>
            <div id="tagContent">
                <div class="tagContent selectTag" id="tagContent0">
                    <div id="divConditions">
                        <label>
                            车号</label>
                        <asp:DropDownList ID="dropSerialNum" runat="server" ClientIDMode="Static">
                        </asp:DropDownList>
                        <label>
                            日期</label>
                        <input type="text" id="starttime" runat="server" onclick="WdatePicker()"/>——
                        <input type="text" id="endtime" runat="server" onclick="WdatePicker()"/>
                        <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
                    </div>
                    <table id="xjtable">
                        <asp:Repeater runat="server" ID="rptInspectionRecords">
                            <HeaderTemplate>
                                <thead class="xjthead">
                                    <tr>
                                        <td>
                                            车号
                                        </td>
                                        <td>
                                            应检时间
                                        </td>
                                        <td>
                                            实检时间
                                        </td>
                                        <td>
                                            巡检状态
                                        </td>
                                        <td>
                                            巡检人
                                        </td>
                                        <td>
                                            备注
                                        </td>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("lcNum") %>
                                    </td>
                                    <td>
                                        <%#Eval("planTime") %>
                                    </td>
                                    <td>
                                        <%#Eval("recordTime") %>
                                    </td>
                                    <td>
                                        <%#Eval("status") %>
                                    </td>
                                    <td>
                                        <%#Eval("worker") %>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr style=" background-color:#e2dcdc;">
                                    <td>
                                        <%#Eval("lcNum") %>
                                    </td>
                                    <td>
                                        <%#Eval("planTime") %>
                                    </td>
                                    <td>
                                        <%#Eval("recordTime") %>
                                    </td>
                                    <td>
                                        <%#Eval("status") %>
                                    </td>
                                    <td>
                                        <%#Eval("worker") %>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </table>

                    <div id="divPagination">
                        <asp:LinkButton ID="lbtnPrePage" runat="server" ClientIDMode="Static" OnClick="lbtnPrePage_Click">上一页&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        <label for="txtJumpNum">
                            跳转到</label>
                        <asp:TextBox ID="txtJumpNum" Width="30" runat="server" OnTextChanged="txtJumpNum_TextChanged"></asp:TextBox>页
                        <input type="button" value="跳转" runat="server" id="JumpNumbtn" onserverclick="JumpNumbtn_Click" />&nbsp;&nbsp;&nbsp;
                        当前第
                        <asp:Label ID="labCurrentPageNum" runat="server" Text="1" ClientIDMode="Static"></asp:Label>页 共<asp:Label
                            runat="server" ID="labTotalPage" />页
                        <asp:LinkButton ID="lbtnNextPage" runat="server" ClientIDMode="Static" OnClick="lbtnNextPage_Click">&nbsp;&nbsp;&nbsp;下一页</asp:LinkButton>
                    </div>
                </div>
                <div class="tagContent" id="tagContent1">
                     <label>
                            车号</label>
                        <asp:DropDownList ID="DropDownListLcnumber" runat="server">
                        </asp:DropDownList>
                        <label>
                     日期</label>
                        <input type="text" id="t1" runat="server"  onclick="WdatePicker()"/>&nbsp;——
                        <input type="text" id="t2" runat="server" onclick="WdatePicker()"/>
                    <asp:Button Text="查询" runat="server" OnClick="btn_Click" ID="XjAnalysisSearch" />
                    <table id="xjAnalysis" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>车号</td><td>应检次数</td><td>已检次数</td><td>晚检</td><td>未检</td><td>已检率</td><td>晚检率</td>
                        </tr>
                        <tr>
                        <td><%=Lcnumber %></td><td><%=CheckAllTimes %></td><td><%=CheckTimes %></td><td><%=CheckLateTimes %></td><td><%=CheckNoTimes %></td><td><%=CheckFrequency %></td><td><%=CeckLateFrequency%></td>
                        </tr>
                    </table>
                    </div>
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

//            window.location = function () {
//                var a = document.getElementById("XjAnalysisSearch");
//                a.attributes("onclick",function () {
//    
//}
//            }
        </script>
        <div class="suspension1">
        
        <input type="button" value="导出为Excel" id="btnExportExcel" />
        <input type="button" value="导出为PDF" id="btnExportPDF" />
        
        
        <div id="downloadDiv" class="suspension">
        正在生成下载链接。。。。
        </div>
        </div>
        <script type="text/javascript">
            var exportHttpRequest = createXMLHttpRequest();
            exportHttpRequest.onreadystatechange = function () {
                if (exportHttpRequest.readyState == 4 && exportHttpRequest.status == 200) {
                    var htmlStr = "<a href=\"" + exportHttpRequest.responseText + "\">下载</a>"
                    id("downloadDiv").innerHTML = htmlStr;
                }
            }
            id("btnExportExcel").onclick = function () {
                exportHttpRequest.open("GET", "ExportHandler.ashx?opCode=1&sD=" + id("<%=starttime.ClientID %>").value + "&eD=" + id("<%=endtime.ClientID %>").value + "&sN=" + id("dropSerialNum").value + "&pN=" + id("labCurrentPageNum").innerText)
                exportHttpRequest.send(null);
            }
            id("btnExportPDF").onclick = function () {
                exportHttpRequest.open("GET", "ExportHandler.ashx?opCode=3&sD=" + id("<%=starttime.ClientID %>").value + "&eD=" + id("<%=endtime.ClientID %>").value + "&sN=" + id("dropSerialNum").value + "&pN=" + id("labCurrentPageNum").innerText)
                exportHttpRequest.send(null);
            }
        </script>
    </div>
    </form>
</asp:Content>
