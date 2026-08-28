using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using DbConnection;
using WebformPractice01.Entity;

namespace WebformPractice01.Context.Board
{
    public class BoardContext
    {
        public BoardDTO _dto { get; set; }


        public DataTable ListBoard(int CurrentPage, int PageSize, string type, string keyword)
        {
            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_List_BoardSelect");
                db.AddParameter("@PageIndex", CurrentPage);
                db.AddParameter("@PageSize", PageSize);
                db.AddParameter("@SearchType", type);
                db.AddParameter("@SearchKeyword", keyword);

                DataTable dt = db.ExecuteDataTable();

                return dt;
            }
        }

        public BoardDTO SelectBoardItem(int id)
        {
            using (DbCon db = new DbCon())
            {
                BoardDTO board = new BoardDTO();
                db.SetStoredProcedure("up_Select_BoardItem");
                db.AddParameter("@ItemID", id);

                DataTable dt = db.ExecuteDataTable();

                board.Title = dt.Rows[0]["Title"].ToString();
                board.Contents = dt.Rows[0]["Contents"].ToString();
                board.CreateUserName = dt.Rows[0]["CreateUserName"].ToString();
                board.CreateDT = Convert.ToDateTime(dt.Rows[0]["CreateDT"]);
                
                return board;
            }
        }

        public void InsertBoardItem(BoardDTO dto) {
            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_Insert_BoardItem");
                db.AddParameter("@Title", dto.Title);
                db.AddParameter("@Contents", dto.Contents);
                db.AddParameter("@UserID", dto.CreateUserID);

                db.ExecuteNonQuery();
            }
        }

        public void UpdateBoardItem(BoardDTO dto) {
            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_Update_BoardItem");
                db.AddParameter("@ItemID", dto.ItemID);
                db.AddParameter("@Title", dto.Title);
                db.AddParameter("@Contents", dto.Contents);

                db.ExecuteNonQuery();

            }
        }
        public int DeleteBoardItem(BoardDTO dto)
        {
            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_Delete_BoardItem");
                db.AddParameter("@ItemID", dto.ItemID);

                return db.ExecuteNonQuery();
            }
        }

        public int BoardViewCountAdd(int itemID)
        {
            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_Add_Board_ViewCount");
                db.AddParameter("@ItemID", itemID);

                return Convert.ToInt32(db.ExecuteScalar());
            }
        }


        public int Select_Board_LikeOrDislike(int ItemID, string Type)
        {
            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_Select_Board_LikeOrDislike");
                db.AddParameter("@ItemID", ItemID);
                db.AddParameter("@Type", Type);

                return Convert.ToInt32(db.ExecuteScalar());
            }
        }

        public void UpdateBoardLikeorDisLike(int ItemID, string UserID, string Type)
        {
            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_Update_Board_LikeOrDislike");
                db.AddParameter("@ItemID", ItemID);
                db.AddParameter("@UserID", UserID);
                db.AddParameter("@Type", Type);

                db.ExecuteNonQuery();
            }
        }

        public int InsertBoardReport(BoardReportDTO dto)
        {
            // up_Insert_BoardReport
            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_Insert_BoardReport");
                db.AddParameter("@ItemID", dto.ItemID);
                db.AddParameter("@UserID", dto.UserID);
                db.AddParameter("@ReportType", dto.ReportType);
                db.AddParameter("@Reason", dto.Reason);

                return Convert.ToInt32(db.ExecuteScalar());
            }
        }
    }
}