using AgileWorksTauriS;
using AgileWorksTauriS.Pages.AgileWorks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

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
        //Run multiple testcases against full overDueCheck that compares the date against current local timestamp
        [TestCase("2024/02/29 19:17:20")]
        [TestCase("2023/02/21 11:15")]
        [TestCase("2024/01/29 13:14:15")]
        [TestCase("2024/01/29")]
        public void getTicketLineColor_OverDueEqualTest(String dateTimeStr)
        {
            
            String color = _overDueChecker.getTicketLineColor(dateTimeStr);

            Assert.AreEqual("red", color);
        }

        [TestCase("2025/02/28 19:15:20")]
        [TestCase("2024/09/05 12:30:45")]
        [TestCase("2024/05/17 10:15:20")]
        [TestCase("2026/06/20")]
        public void getTicketLineColor_OverDueNotEqualTest(String dateTimeStr)
        {

            String color = _overDueChecker.getTicketLineColor(dateTimeStr);

            Assert.AreNotEqual("red", color);
        }

        [TestCase("2025/02/28 19:15:20")]
        [TestCase("2024/09/05 12:30:45")]
        [TestCase("2024/05/17 10:15:20")]
        [TestCase("2026/06/20")]
        public void getTicketLineColor_notDueEqualTest(String dateTimeStr)
        {

            String color = _overDueChecker.getTicketLineColor(dateTimeStr);

            Assert.AreEqual("black", color);
        }

        [TestCase("2024/02/29 19:17:20")]
        [TestCase("2023/02/21 11:15")]
        [TestCase("2024/01/29 13:14:15")]
        [TestCase("2024/01/29")]
        public void getTicketLineColor_notDueNotEqualTest(String dateTimeStr)
        {

            String color = _overDueChecker.getTicketLineColor(dateTimeStr);

            Assert.AreNotEqual("black", color);
        }

        //Run a generic all compassing overDue check against current timestamp
        [Test]
        public void getTicketLineColor_genericTests()
        {
            String overDueTimeStr = "2024/01/29 19:17:20";
            String futureTimeStr = "2025/02/28";

            String colorOverDue = _overDueChecker.getTicketLineColor(overDueTimeStr);
            String colorFuture = _overDueChecker.getTicketLineColor(futureTimeStr);

            Assert.AreEqual("red",      colorOverDue);
            Assert.AreNotEqual("black", colorOverDue);

            Assert.AreEqual("black",  colorFuture);
            Assert.AreNotEqual("red", colorFuture);
        }

        //Run a test to verify if the overdue logic meets the requirements (less than 1h until deadline)
        [Test]
        public void isTicketOverdue_genericTests()
        { 
            DateTime curTime1 = DateTime.Parse("2024/03/01 10:00:00");
            DateTime dueDate1 = DateTime.Parse("2024/03/01 11:10:00");
            
            DateTime curTime2 = DateTime.Parse("2024/03/01 10:00:00");
            DateTime dueDate2 = DateTime.Parse("2024/03/01 11:00:00");
            
            DateTime curTime3 = DateTime.Parse("2024/03/01 10:00:00");
            DateTime dueDate3 = DateTime.Parse("2024/03/01 10:59:59");
            
            DateTime curTime4 = DateTime.Parse("2024/07/21 09:00:00");
            DateTime dueDate4 = DateTime.Parse("2024/02/08 10:59:59");
            
            DateTime curTime5 = DateTime.Parse("2020/02/02 10:00:00");
            DateTime dueDate5 = DateTime.Parse("2026/03/01 10:00:00");

            DateTime curTime6 = DateTime.Parse("2020/02/02");
            DateTime dueDate6 = DateTime.Parse("2026/03/01 10:00:00");

            DateTime curTime7 = DateTime.Parse("2024/07/21 09:00:00");
            DateTime dueDate7 = DateTime.Parse("2024/02/08");

            DateTime curTime8 = DateTime.Parse("2020/02/02");
            DateTime dueDate8 = DateTime.Parse("2024/02/08");

            bool overDue1 = _overDueChecker.isTicketOverDue(curTime1, dueDate1);
            bool overDue2 = _overDueChecker.isTicketOverDue(curTime2, dueDate2);
            bool overDue3 = _overDueChecker.isTicketOverDue(curTime3, dueDate3);
            bool overDue4 = _overDueChecker.isTicketOverDue(curTime4, dueDate4);
            bool overDue5 = _overDueChecker.isTicketOverDue(curTime5, dueDate5);
            bool overDue6 = _overDueChecker.isTicketOverDue(curTime6, dueDate6);
            bool overDue7 = _overDueChecker.isTicketOverDue(curTime7, dueDate7);
            bool overDue8 = _overDueChecker.isTicketOverDue(curTime8, dueDate8);

            Assert.IsFalse(overDue1);
            Assert.IsFalse(overDue2);
            Assert.IsTrue(overDue3);
            Assert.IsTrue(overDue4);
            Assert.IsFalse(overDue5);
            Assert.IsFalse(overDue6);
            Assert.IsTrue(overDue7);
            Assert.IsFalse(overDue8);

        }

    }
}