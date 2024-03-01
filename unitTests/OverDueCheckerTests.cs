using AgileWorksTauriS;
using AgileWorksTauriS.Pages.AgileWorks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace unitTests
{
    public class OverDueCheckerTests
    {
        private overDueChecker _overDueChecker;

        [SetUp]
        public void Setup()
        {
            _overDueChecker = new overDueChecker();
        }

        [TestCase("2024/02/29 19:15:20")]
        [TestCase("2023/02/21 19:15:20")]
        [TestCase("2024/03/29 19:15:20")]
        public void getTicketLineColor_EqualTest(String dateTimeStr)
        {
            //String dateTimeStr = "2024/02/29 19:15:20";

            String color = _overDueChecker.getTicketLineColor(dateTimeStr);


            Assert.AreEqual("red", color);
        }
    }
}