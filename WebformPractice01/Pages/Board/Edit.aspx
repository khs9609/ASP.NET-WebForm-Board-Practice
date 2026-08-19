<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" ValidateRequest="false" Inherits="WebformPractice01.Pages.Board.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .board_edit > * {
            margin-bottom : 20px;
        }

        #tbBoardEdit { border-collapse : collapse;}
        #tbBoardEdit th, #tbBoardEdit td { border : 1px solid #ddd;}
        #tbBoardEdit th > *, #tbBoardEdit td > * {margin : 3px;}

        .btn_area button, .btn_area input[type=submit] {
            border : 1px solid #ddd;
            width : 70px; height : 38px;
            /*background-color : rgb(77 148 248);*/
            /*color : #fcfcfc;*/
            background-color : #ddd;
            color : #fafafa;
            
        }
    </style>
    <script>
        $(function () {
            $('#<%=FileUpload1.ClientID %>').on('change', function () {
                let fileName = $("#spFileName");

                fileName.empty;

                $.each(this.files, function (index, file) {
                    fileName.append('📃 ' + file.name + '<br>');
                });
            });
        });
    </script>

    <div class="board_edit">
        <div class="board_table_area" >
            <table id="tbBoardEdit" style="width : 100%;">
                <colgroup>
                    <col style="width: 15%;" />
                    <col />
                </colgroup>
                <tr>
                    <th>제목</th>
                    <td>
                        <asp:TextBox ID="txt_Title" Width="100%" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>작성자</th>
                    <td>
                        <asp:Literal ID="lbl_CreateUserName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th>내용</th>
                    <td>
                        <asp:TextBox ID="txt_Contents" Width="500" TextMode="MultiLine" runat="server" />
                    </td>
                </tr>
            </table>
        </div>

        <div class="attach_area">
            <div style="display : flex; background-color:rgb(248 248 248);min-height : 60px;">
                <div style="width : 15%;margin-right : 2px; border : 1px solid #ddd; text-align : center;">
                    <button type="button" id="btnAttachAdd"  style="width : 99%;height : 99%; border : 1px solid #ddd;" onclick="document.getElementById('<%=FileUpload1.ClientID %>').click()">추 가</button>
                </div>
                <div style="width : 100%; border : 1px solid #ddd; padding-left : 5px;">
                    <span id="spFileName"></span>
                </div>
            </div>
        </div>
        <asp:FileUpload ID="FileUpload1" AllowMultiple="true" Style="display:none" runat="server" />
    
        <div class="btn_area" style="text-align : right; margin-top : 30px;">
            <asp:Button ID="btnSave" Onclick="btnSave_Click" Text="저장" runat="server"/>
            <asp:Button ID="btnList" OnClick="btnList_Click" Text="목록" runat="server"/>
        </div>

    </div>
</asp:Content>
