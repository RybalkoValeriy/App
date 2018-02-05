using System;
using System.Web.Mvc;
using App.WebUI.HtmlHelpers;
using App.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void Can_Generate_page_Links()
        {
            // Arrage
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                TotalItem = 38,
                CurrentPage = 2,
                ItemsPrePage = 10
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = myHelper.PageLink(pagingInfo, pageUrlDelegate);
            // Accept
            Assert.AreEqual(result.ToString(),
                @"<li><a href=""Page1"">1</a></li>"+
                @"<li class=""active""><a href=""Page2"">2</a></li>"+
                @"<li><a href=""Page3"">3</a></li>"+
                @"<li><a href=""Page4"">4</a></li>"
                );
        }
    }
}
