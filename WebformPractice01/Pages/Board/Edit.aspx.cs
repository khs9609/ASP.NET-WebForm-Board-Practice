using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbConnection;
using WebformPractice01.Context.Board;
using WebformPractice01.Entity;

namespace WebformPractice01.Pages.Board
{
    public partial class Edit1 : System.Web.UI.Page
    {
        protected int ItemID { get; set; }
        protected bool IsNew { get; set; }

        protected String _UserID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbl_CreateUserName.Text)) lbl_CreateUserName.Text = "홍길동";
            if (string.IsNullOrEmpty(_UserID)) _UserID = "S0001";
            if (!string.IsNullOrEmpty(ItemID.ToString())) ItemID = Convert.ToInt32(Request.QueryString["ItemID"]);

            if (!IsPostBack)
            {
                
                IsNew = string.IsNullOrEmpty(ItemID.ToString());

                if (!IsNew)
                {
                    InitData(ItemID);
                }
            }
        }

        public void InitData(int id)
        {
            BoardDTO _dto = new BoardDTO();
            BoardContext ctx = new BoardContext();
            
            _dto = ctx.SelectBoardItem(id);
            txt_Title.Text = _dto.Title;
            txt_Contents.Text = _dto.Contents;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txt_Title.Text) || String.IsNullOrEmpty(txt_Contents.Text) )
            {
                throw new Exception("입력되지 않은 값이 있습니다.");
            }

            BoardContext ctx = new BoardContext();
            
            BoardDTO dto = new BoardDTO();
            dto.ItemID = ItemID;
            dto.Title = txt_Title.Text;
            dto.Contents = HttpUtility.HtmlEncode(txt_Contents.Text);
            dto.CreateUserID = _UserID;


            if (IsNew)
            {
                ctx.InsertBoardItem(dto);
            }
            else {
                ctx.UpdateBoardItem(dto);
            }


            Response.Redirect("List.aspx");
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}