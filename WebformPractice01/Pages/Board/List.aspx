<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebformPractice01.Pages.Board.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .board_area {
        }

        .board_table th, .board_table td {
            border-bottom : 1px solid #ddd;
        }
    </style>
    <script>

    </script>
    <div class="board_area">
        <table class="board_table" style="width:90%;border-collapse:collapse;">
            <thead>
                <tr>
                    <th>번호</th>
                    <th>제목</th>
                    <th>이름</th>
                </tr>
            </thead>
            <tbody>
                
            <% foreach (var item in BoardList) { %>
            <tr>
                <td><%= item.ItemID %></td>
                <td><a href="./View.aspx?ItemID=<%= item.ItemID %>"><%= item.Title %></a></td>
                <td><%= item.CreateUserName %></td>
            </tr>

            <% } %>
            </tbody>
        </table>
    </div>

    <div class="page">
        <div class="paging">
            <asp:Literal ID="ltPaging" runat="server" />
        </div>
    </div>

    <div class="btn_area">
        <asp:Button Text="작성" ID="btnWrite" OnClick="btnWrite_Click" runat="server" />
    </div>

</asp:Content>
