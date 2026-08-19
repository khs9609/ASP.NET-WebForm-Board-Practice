using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbConnection;
using WebformPractice01.Context.Board;
using WebformPractice01.Entity;

namespace WebformPractice01.Pages.Board
{
    public partial class View : System.Web.UI.Page
    {
        public BoardDTO dto { get; set; }
        public int ItemID {get; set;}
        public String UserID {get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemID = Convert.ToInt32(Request.Params["ItemID"]);
                UserID = "S0001";

                dto = setField(ItemID);
            }
        }

        public BoardDTO setField(int id)
        {
            BoardContext ctx = new BoardContext();
            BoardDTO _dto = new BoardDTO();
            _dto = ctx.SelectBoardItem(id);

            return _dto;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx?ItemID=" +  Request.QueryString["ItemID"]);
        }
    }
}