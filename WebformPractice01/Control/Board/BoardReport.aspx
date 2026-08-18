<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardReport.aspx.cs" Inherits="WebformPractice01.Control.Board.BoardReport" %>

<!DOCTYPE html>

<html>
<head runat="server">

    <title>게시글 신고</title>

    <style>

        body{
            font-family:맑은 고딕;
            padding:20px;
        }

        h2{
            margin-bottom:20px;
        }

        .row{
            margin-bottom:15px;
        }

        textarea{

            width:100%;
            height:120px;
            display:none;
        }

        .btnArea{

            margin-top:20px;
            text-align:center;
        }

        button{

            width:80px;
            height:40px;
        }

    </style>

    <script src="/Scripts/jquery-3.7.0.js"></script>
    <script src="/Scripts/jquery-3.7.1.min.js"></script>

    <script>
        $(function () {
            $("input[name=reason]").change(function () {
                if ($(this).val() == "기타") {
                    $("#txtEtc").show();
                }
                else {
                    $("#txtEtc").hide();
                }
            });
        });

        function Report() {

            var reason = $("input[name=reason]:checked").val();
            $("#<%= hidReportType.ClientID %>").val(reason);

            if (reason == undefined) {

                alert("신고 사유를 선택하세요.");
                return;
            }

            var etc = $("#txtEtc").val();
            if (reason == "기타" && $.trim(etc) == "") {

                alert("신고 내용을 입력하세요.");
                return;
            }
            $("#<%= hidReportReason.ClientID %>").val(etc);


            if (!confirm("해당 게시글을 신고하시겠습니까?")) {
                return;
            }



            $("#<%= btnReport.ClientID%>").click();
            /*
            $.ajax({
                url: "/Service/ResponseBoardService.asmx/InsertReport",
                type: "post",
                data: JSON.stringify({
                    ItemID: $("#hfItemID").val(),
                    Reason: reason,
                    Contents: etc
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    alert("신고가 접수되었습니다.");
                    window.close();
                },
                error: function () {
                    alert("오류가 발생했습니다.");
                }
            });
            */
        }

        function Cancel() {
            window.close();
        }
    </script>
</head>
<body>

        
<form id="form1" runat="server">
    <asp:HiddenField ID="hfItemID" runat="server"/>

    <h2>게시글 신고</h2>

    <div class="row">
        <label>
            <input type="radio" name="reason" value="욕설"/>욕설
        </label>
    </div>

    <div class="row">
        <label>
            <input type="radio" name="reason" value="음란물"/>음란물
        </label>
    </div>

    <div class="row">
        <label>
            <input type="radio" name="reason" value="광고"/>광고
        </label>
    </div>

    <div class="row">
        <label>
            <input type="radio" name="reason" value="도배"/>도배
        </label>
    </div>

    <div class="row">
        <label>
            <input type="radio" name="reason" value="기타"/>
            기타
        </label>
    </div>

    <div class="row">
        <textarea id="txtEtc" placeholder="신고 사유를 입력해주세요."></textarea>
    </div>

    <div class="btnArea">
        <button type="button" onclick="Report();">신고</button>
        <button type="button" onclick="Cancel();">취소</button>
    </div>

    <div style="display:none"></div>
    <asp:Button ID="btnReport" OnClick="btnReport_Click" style="display:none;" runat="server" />
    <asp:HiddenField ID="hidReportType" runat="server" />
    <asp:HiddenField ID="hidReportReason" runat="server" />

</form>

</body>

</html>