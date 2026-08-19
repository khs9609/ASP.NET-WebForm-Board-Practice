<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" ValidateRequest="false" Inherits="WebformPractice01.Pages.Board.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .board_edit > * {margin-bottom : 20px;}

        .board_edit_area {
            width: 100%;
        }

        .board_edit_area .title {
            margin-bottom : 15px;
        }


        .board_edit_area input[type="text"],
        .board_edit_area textarea {
            width: 100%;
            padding : 5px 7px;
            border : 1px solid #bcbcbc;
            border-radius : 3px;
        }

        .board_edit_area textarea {
            resize : none;

        }

        #tbBoardEdit { border-collapse : collapse;}
        #tbBoardEdit th, #tbBoardEdit td { border : 1px solid #ddd;}
        #tbBoardEdit th > *, #tbBoardEdit td > * {margin : 3px;}


        .board_attach_area #btnAttachAdd {
            font-size : 12px;width : 4em;height : 2em; border : 1px solid #ddd;
        }


        .attach_area {
            display : flex; 
            min-height : 80px;
            background-color:rgb(248 248 248);
        }

        .attach_area .attach_add {
            width : 15%;
            text-align : center;
            
            margin-right : 2px;
            padding-top : 12px;
            
            border : 1px solid #bcbcbc;
            border-radius : 3px;
        }
        .attach_area .attach_list {
            width : 100%; 
            border : 1px solid #bcbcbc;
            border-radius : 3px; 
            padding-left : 5px;
        }


        .btn_area button, .btn_area input[type=submit] {
            border : 1px solid #ddd;
            width : 70px; height : 38px;
            background-color : #ddd;
            color : #262626;
            
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

        <div class="board_title_area">
            <h2>게시판</h2>
        </div>

        <div class="board_edit_area">
            <div class="title">
                <asp:TextBox ID="txt_Title" Width="100%" placeholder="제목" runat="server" />
            </div>
            <div class="content">
                <asp:TextBox ID="txt_Contents" TextMode="MultiLine" Rows="10" runat="server" />
            </div>
        </div>
        

        <div class="board_attach_area">
            <div class="attach_area">
                <div class="attach_add">
                    <p style="margin-bottom : 3px;">첨부파일</p>
                    <button type="button" id="btnAttachAdd" onclick="document.getElementById('<%=FileUpload1.ClientID %>').click()">추가</button>
                </div>
                <div class="attach_list">
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
