<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebformPractice01.Pages.Board.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .board_area {
            font-size : 14px;
            color : #303030;
        }

        .board_area a {
            text-decoration : none;
            font-weight : bold;
            color : #303030;
        }

        .board_area .board_title_area {
            margin-bottom : 30px;
        }

        .board_table_area .board_head_element{
            display : flex;
            justify-content : space-between;
            margin : 10px 0px;
        }

        .board_table_area .board_head_element .search_element * {
            height : 30px;
        }

        .board_table {
            width : 100%;
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
            padding : 13px 7px;
            color : #bbbbbb;
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
        <div class="board_title_area">
            <h2>Board</h2>
        </div>

        <div class="board_table_area">
            <div class="board_head_element">
                <div class="totalcount_element">
                    총 <span style="color:red"><%= TotalCount %></span>건
                </div>

                <div class="search_element">
                    <asp:DropDownList ID="dropSearchType" CssClass="dropdown_element" runat="server">
                        <asp:ListItem Value="Title" Selected="True">제목</asp:ListItem>
                        <asp:ListItem Value="Content">본문</asp:ListItem>
                        <asp:ListItem Value="Author">작성자</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtSearchKeyword" Width="250" runat="server" />
                    <asp:Button ID="btnSearch" Text="🔍" OnClick="btnSearch_Click" runat="server" />
                </div>
            </div>

            <div>
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
                        <td><%= item.CreateDT.ToString("yyyy-MM-dd hh:mm") %></td>
                        <td><%= item.ViewCount %></td>
                    </tr>
                    <% } %>
                    </tbody>
                </table>
            </div>
        </div>

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
