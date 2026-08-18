using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebformPractice01.Context.Board;

namespace WebformPractice01.Service
{
    /// <summary>
    /// ResponseBoardService 요약 설명입니다.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // ASP.NET AJAX를 사용하여 스크립트에서 이 웹 서비스를 호출하려면 다음 줄의 주석 처리를 제거합니다. 
    [System.Web.Script.Services.ScriptService]
    public class ResponseBoardService : System.Web.Services.WebService
    {

        [WebMethod]
        public int AddViewCount(int ItemID)
        {
            BoardContext ctx = new BoardContext();

            return ctx.BoardViewCountAdd(ItemID);
        }

        [WebMethod]
        public int SelectLikeorDisLike(int ItemID, string Type)
        {
            BoardContext ctx = new BoardContext();
            return ctx.Select_Board_LikeOrDislike(ItemID, Type);
        }

        [WebMethod]
        public void UpdateLikeorDisLike(int ItemID, string UserID, string Type)
        {
            BoardContext ctx = new BoardContext();
            ctx.UpdateBoardLikeorDisLike(ItemID, UserID, Type);
        }



        
    }
}
