<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="WebformPractice01.Pages.Board.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .display_flex {
            display : flex;
            justify-content : space-between;
        }

        .board_title_area {
            padding : 10px 0px;
        }

        .board_content_area, .board_content_area, .board_content_button_area {
            padding : 10px 0px;
        }
        
        .board_content_area .board_data {
            padding : 5px 0px;
            border-bottom : 1px solid #ddd;
            font-size : 16px;

        }

        .board_content_area .board_data .function_btn_area button {
            width : 80px;
            height : 40px;
            background : 1px;
            border : 1px solid #ddd;
        }

        .board_content_area .board_contents_data {
            height : 300px;
        }

        .board_button_area {
            text-align : right;
        }

        .board_button_area button, .board_button_area input[type=submit]  {
            width : 60px;
        }

    </style>

    <script>
        $(function () {
            var itemID = <%= ItemID %>;
            var userID = "<%= UserID %>";

            $.ajax({
                url: "/Service/ResponseBoardService.asmx/AddViewCount",
                type: "post",
                data: JSON.stringify({
                    ItemID: itemID
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    $("#sp_viewCount").text(res.d)
                },
                error: function () {

                }
            });

            GetLikeCount(itemID);

            $("#btnLike").on("click", function () {
                SetLikeCount(itemID, userID);
            });

            $("#btnReport").on("click", function () {

                window.open(
                    "../../Control/Board/BoardReport.aspx?ItemID=" + itemID,
                    "ReportPopup",
                    "width=500,height=550,toolbar=no,menubar=no,scrollbars=no,resizable=no"
                );

            });
        });

        function ToList() {
            location.href = "./List.aspx";
            return false;
        }

        function GetLikeCount(boardID, likeType ='L') {
            $.ajax({
                url: "/Service/ResponseBoardService.asmx/SelectLikeorDisLike",
                type: "post",
                data: JSON.stringify({
                    ItemID: boardID,
                    Type: likeType
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    $("#sp_likeCount").text(res.d);
                },
                error: function () {

                }
            });
        }

        function SetLikeCount(boardID, userID, likeType = 'L') {
            $.ajax({
                url: "/Service/ResponseBoardService.asmx/UpdateLikeorDisLike",
                type: "post",
                data: JSON.stringify({
                    ItemID: boardID,
                    UserID: userID,
                    Type: likeType
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    GetLikeCount(boardID);
                },
                error: function () {

                }
            });
        }
    </script>
   
    <div class="board_title_area">
        <h2>게시판</h2>
    </div>

    <div class="board_content_area">
        <!-- 제목 -->
        <div class="board_data">
            제목 | <%: dto.Title %>
        </div>

        <!-- 정보 -->
        <div class="display_flex board_data">
            <div>
                <span>🙂 <%: dto.CreateUserName %> </span>
                <span style="font-size:12px;color:#ddd;"><%: dto.CreateDT.ToString("yyyy-MM-dd HH:mm") %></span>
                <span style="font-size:12px;padding-left : 5px;">조회수 <span id="sp_viewCount" style="color:red">0</span></span>
                <span style="font-size:12px;padding-left : 5px;">추천수 <span id="sp_likeCount" style="color:red">0</span></span>
            </div>
            <div>
                <div class="function_btn_area">
                    <button type="button" id="btnLike">👍추천</button>
                    <button type="button" id="btnReport">🚨신고</button>
                </div>
            </div>

        </div>

         <!-- 본문 -->
         <div class="board_data board_contents_data">
             <%: HttpUtility.HtmlDecode(dto.Contents) %>
         </div>
         <div>
         </div>

    </div>

    <div class="board_button_area">
        <div>
           <button id="btnList" type="button" onclick="ToList();" style="border:none;background:#7e7e7e;color:#fff;">목록</button>
            <asp:Button ID="btnEdit" Text="수정" OnClick="btnEdit_Click"  style="border:none;background:#7e7e7e;color:#fff;" runat="server" />
        </div>
    </div>
    <asp:Button Visible="false" runat="server"/>
</asp:Content>
