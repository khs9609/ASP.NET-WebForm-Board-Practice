using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebformPractice01.Common
{
    public static class PagingHelper
    {

        // 
        public static String CreatePaging(int CurrentPage, int PageSize, int TotalPage, string PageUrl )
        {
            StringBuilder sb = new StringBuilder();

            int StartPage = ((CurrentPage - 1) / PageSize) * PageSize + 1 ;
            int EndPage = Math.Min(StartPage + PageSize - 1, TotalPage);


            // 이전 페이지 (첫 페이지가 아닐 경우)
            if (StartPage > 1)
            {
                sb.Append($"<a href='{PageUrl}?page=1'>&lt;&lt;</a>");
                sb.Append($"<a href='{PageUrl}?page={StartPage-1}'>&lt;</a>");
            }

            // 페이지 번호 생성
            for(int i = StartPage; i <= EndPage; i++)
            {
                if(i == CurrentPage)
                {
                    sb.Append($"<a style='pointer-events: none;cursor: default;'><b>{i}</b></a>");
                    continue;
                }
                sb.Append($"<a href='{PageUrl}?page={i}'>{i}</a>");
            }

            // 다음 페이지
            if(EndPage < TotalPage)
            {
                sb.Append($"<a href='{PageUrl}?page={EndPage+1}'>&gt;</a>");
            }

            // 마지막 페이지
            if (CurrentPage < TotalPage && PageSize < TotalPage)
            {
                sb.Append($"<a href='{PageUrl}?page={TotalPage}'>&gt;&gt;</a>");
            }


            return sb.ToString();
        }


    }
}