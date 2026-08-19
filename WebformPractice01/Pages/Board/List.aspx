<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebformPractice01.Pages.Board.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .board_area {
            font-size : 14px;
        }

        .board_area a {
            text-decoration : none;
            font-weight : bold;
            color : #303030;
        }

        .board_table {
            width : 98%;
            border-collapse : collapse;
            border : none;
        }
        
        .board_table th, .board_table td {
            text-align : center;
            border-bottom : 1px solid #bfbfbf;

        }


        .board_table th {
            padding : 16px 7px;
            background-color : #eaeaea;
            border-top : 3px solid #000;
        }

        .board_table td {
            padding : 12px 7px;
            color : #bbbbbb ;
            font-weight : bold;
            font-family: "Malgun Gothic", "맑은 고딕", sans-serif;

        }

        .paging_area {
            text-align : center;
            letter-spacing :5px;
            margin-top : 35px;
        }

        .paging_area a {
            display: inline-block;
            width : 40px;
            height : 40px;
            border : 1px solid #bbbbbb; 
            margin : 0px 3px;
            padding-right:4px;
            color : #aaaaaa;

            text-align:center;
            letter-spacing : -3px;
            line-height : 37px;
        }

        .btn_area {
            text-align : right;
        }

        .btn_area input[type=submit] {
            width : 70px; 
            height : 38px;
            color : #262626;
            background-color : #ddd;

            border : 1px solid #ddd;
            border-radius : 3px;
        }
    </style>
    <script>

    </script>

    <div class="board_area">
        <table class="board_table">
            <colgroup>
                <col width="12%"/>
                <col />
                <col width="12%"/>
                <col width="15%"/>
                <col width="12%"/>
            </colgroup>
            <thead>
                <tr>
                    <th>번호</th>
                    <th>제목</th>
                    <th>작성자</th>
                    <th>등록일</th>
                    <th>조회수</th>
                </tr>
            </thead>
            <tbody>
                
            <% foreach (var item in BoardList) { %>
            <tr>
                <td><%= item.ItemID %></td>
                <td style="text-align:left;"><a href="./View.aspx?ItemID=<%= item.ItemID %>"><%= item.Title %></a></td>
                <td><%= item.CreateUserName %></td>
                <td><%= item.CreateUserName %></td>
                <td><%= item.CreateUserName %></td>
            </tr>

            <% } %>
            </tbody>
        </table>

        <div class="paging_area">
            <div class="paging">
                <asp:Literal ID="ltPaging" runat="server" />
            </div>
        </div>

        <div class="btn_area">
            <asp:Button Text="작성" ID="btnWrite" OnClick="btnWrite_Click" runat="server" />
        </div>
    </div>

</asp:Content>
