<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" ValidateRequest="false" Inherits="WebformPractice01.Pages.Board.Edit1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        board_edit_area .btn_area {
            display : flex;
        }
    </style>

    <div class="board_edit_area">
        <div class=""></div>

        <div class="input_area">
            <table>
                <tr>
                    <th>제목</th>
                    <td>
                        <asp:TextBox ID="txt_Title" Width="500" runat="server" />
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

        <div class="btn_area">
            <asp:Button ID="btnSave" Onclick="btnSave_Click" Text="저장" runat="server"/>
            <asp:Button ID="btnList" OnClick="btnList_Click" Text="목록" runat="server"/>
        </div>

    </div>
</asp:Content>
