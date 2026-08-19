using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Text;
using WebformPractice01.Entity;
using DbConnection;
using WebformPractice01.Common;

namespace WebformPractice01.Pages.Board
{
    public partial class List : System.Web.UI.Page
    {
        protected List<BoardDTO> BoardList = new List<BoardDTO>();

        protected DataTable BoardList2;

        protected int CurrentPage = 1;
        protected int PageSize = 10;
        protected int PageBlock = 10;

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

                Search();
                //BindPaging();

                ltPaging.Text = PagingHelper.CreatePaging(CurrentPage, PageSize, TotalPage, Request.Url.AbsolutePath);

                int startPage = ((CurrentPage - 1) / PageBlock) * PageBlock + 1;
                int endPage = Math.Min(startPage + PageBlock - 1, TotalPage);
            }
        }

        private void Search()
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
                        CreateDT = Convert.ToDateTime(row["CreateDT"])
                    });
                }

                if (dt.Rows.Count > 0)
                {
                    TotalCount = Convert.ToInt32(dt.Rows[0]["TotalCount"]);

                    TotalPage = (int)Math.Ceiling((double)TotalCount / PageSize);
                }
            }
        }

        private void BindPaging()
        {
            StringBuilder sb = new StringBuilder();

            int startPage = ((CurrentPage - 1) / PageBlock) * PageBlock + 1;
            int endPage = Math.Min(startPage + PageBlock - 1, TotalPage);


            // 첫 번째 블록이 아닐 때만
            if (startPage > 1)
            {
                sb.Append("<a href='?page=1'>[&lt;&lt;]</a>");
                sb.Append($"<a href='?page={startPage - 1}'>[&lt;]</a>");
            }

            // 페이지 번호
            for (int i = startPage; i <= endPage; i++)
            {
                if (i == CurrentPage)
                {
                    sb.Append($"<strong>[{i}]</strong>");
                }
                else
                {
                    sb.Append($"<a href='?page={i}'>{i}</a>");
                }
            }

            // 다음 블록
            if (endPage < TotalPage)
            {
                sb.Append($"<a href='?page={endPage + 1}'>[&gt;]</a>");
            }

            // 마지막
            if (CurrentPage < TotalPage)
            {
                sb.Append($"<a href='?page={TotalPage}'>[&gt;&gt;]</a>");
            }

            ltPaging.Text = sb.ToString();
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }
    }
}