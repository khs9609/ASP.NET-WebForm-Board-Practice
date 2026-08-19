using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbConnection;
using WebformPractice01.Context.Board;
using WebformPractice01.Entity;

namespace WebformPractice01.Pages.Board
{
    public partial class Edit : System.Web.UI.Page
    {
        protected String _UserID { get; set; }
        protected int ItemID { get; set; }

        protected bool IsNew = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_UserID)) _UserID = "S0001";
            if (string.IsNullOrEmpty(lbl_CreateUserName.Text)) lbl_CreateUserName.Text = "홍길동";
            if (string.IsNullOrEmpty(Request.QueryString["ItemID"]) || ItemID == 0) IsNew = true;
            if (!string.IsNullOrEmpty(Request.QueryString["ItemID"])) ItemID = ItemID = Convert.ToInt32(Request.QueryString["ItemID"]); ;

            if (!IsPostBack)
            {
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

            /* 단일 파일 저장
            if (FileUpload1.HasFile)
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, FileUpload1.FileName);
                FileUpload1.SaveAs(filePath);
            }
            */

            if (FileUpload1.HasFiles)
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                {
                    string filePath = Path.Combine(
                        desktopPath,
                        file.FileName
                    );

                    file.SaveAs(filePath);
                }
            }

            Response.Redirect("List.aspx");
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}