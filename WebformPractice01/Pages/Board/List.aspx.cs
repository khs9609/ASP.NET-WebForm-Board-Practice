using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Text;
using WebformPractice01.Entity;
using DbConnection;
using WebformPractice01.Common;
using System.Reflection;
using System.Security.Policy;

namespace WebformPractice01.Pages.Board
{
    public partial class List : System.Web.UI.Page
    {
        protected List<BoardDTO> BoardList = new List<BoardDTO>();

        protected DataTable BoardList2;

        protected int CurrentPage = 1;
        protected int PageSize = 10; // 출력 개수
        protected int PageBlock = 5; // 페이지 개수

        protected int TotalCount;
        protected int TotalPage;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["page"]))
                {
                    CurrentPage = Convert.ToInt32(Request["page"]);
                }
                string SearchType = dropSearchType.SelectedValue;
                string SearchKeyword = txtSearchKeyword.Text;

                Search(SearchType, SearchKeyword);

                // 페이징 Control 출력
                ltPaging.Text = PagingHelper.CreatePaging(CurrentPage, PageBlock, TotalPage, Request.Url.AbsolutePath);
            }
        }

        private void Search(string type = "", string keyword = "")
        {
            BoardList.Clear();

            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_List_BoardSelect");

                db.AddParameter("@PageIndex", CurrentPage);
                db.AddParameter("@PageSize", PageSize);

                DataTable dt = db.ExecuteDataTable();

                foreach (DataRow row in dt.Rows)
                {
                    BoardList.Add(new BoardDTO
                    {
                        ItemID = Convert.ToInt32(row["ItemID"]),
                        Title = row["Title"].ToString(),
                        CreateUserName = row["CreateUserName"].ToString(),
                        CreateDT = Convert.ToDateTime(row["CreateDT"]),
                        ViewCount = Convert.ToInt32(row["ViewCount"])
                    });
                }

                if (dt.Rows.Count > 0)
                {
                    TotalCount = Convert.ToInt32(dt.Rows[0]["TotalCount"]);

                    TotalPage = (int)Math.Ceiling((double)TotalCount / PageSize);
                }
            }
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.);
        }
    }
}