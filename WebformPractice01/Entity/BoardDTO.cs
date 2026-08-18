using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebformPractice01.Entity
{
    public class BoardDTO
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public string CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDT { get; set; }
    }

    public class BoardReportDTO
    {
        public int ItemID { get; set; }
        public string UserID { get; set; }
        public string ReportType { get; set; }
        public string Reason { get; set; }
        public DateTime CreateDT { get; set; }

    }
}