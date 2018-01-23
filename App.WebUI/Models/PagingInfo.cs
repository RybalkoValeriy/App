using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItem { get; set; }
        public int ItemsPrePage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPage
        {
            get { return (int)Math.Ceiling((double)TotalItem / ItemsPrePage); }
        }
    }
}