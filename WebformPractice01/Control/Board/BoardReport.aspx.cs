using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebformPractice01.Context.Board;
using WebformPractice01.Entity;

namespace WebformPractice01.Control.Board
{
    public partial class BoardReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            BoardContext ctx = new BoardContext();
            BoardReportDTO dto = new BoardReportDTO();

            dto.ItemID = Convert.ToInt32(Request.QueryString["ItemID"]);
            dto.UserID = "S0001";
            dto.ReportType = hidReportType.Value;
            dto.Reason = hidReportReason.Value;

            int result = ctx.InsertBoardReport(dto);

            if(result > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "script", "Cancel()", true);
            }else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('이미 신고한 게시물입니다.')", true);
            }
        }

      
    }
}