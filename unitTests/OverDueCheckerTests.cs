using System.Buffers;
using AgileWorksTauriS;
using AgileWorksTauriS.Pages.AgileWorks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using Moq;

namespace unitTests
{
        public class OverDueCheckerTests
        {
                private overDueChecker _overDueChecker;
                private Mock<systemTimeProvider> _systemTimeProviderMock;
                private Mock<overDueCheckerSettings> _overDueCheckerSettingsMock;

                [SetUp]
                public void Setup()
                {
                        _systemTimeProviderMock = new Mock<systemTimeProvider>();
                        _overDueCheckerSettingsMock = new Mock<overDueCheckerSettings>();
                        _overDueChecker = new overDueChecker(_systemTimeProviderMock.Object, _overDueCheckerSettingsMock.Object);
                        
                        _overDueCheckerSettingsMock.Setup(x => x.PassedCurrentDeadlineInHours()).Returns(-1);
                }
                
                [TestCase(0)]
                [TestCase(10)]
                [TestCase(-5)]
                [TestCase(-59)]
                [TestCase(-60)]
                public void getTicketLineColor_Return_Red_If_Overdue(int dueDateMinutesToAdd)
                {
                        DateTime mockTimestamp = DateTime.UtcNow;
                        _systemTimeProviderMock.Setup(x => x.UtcNow()).Returns(mockTimestamp);
                        //ACT 
                        var color = _overDueChecker.getTicketLineColor(mockTimestamp.AddMinutes(dueDateMinutesToAdd));
                        
                        //Assert
                        Assert.AreEqual("red", color);
                }
              
                
                [TestCase(-61)]
                [TestCase(-123)]
                public void getTicketLineColor_Return_Black_If_Not_Overdue(int dueDateMinutesToAdd)
                {
                        DateTime mockTimestamp = DateTime.UtcNow;
                        _systemTimeProviderMock.Setup(x => x.UtcNow()).Returns(mockTimestamp);
                        //ACT 
                        var color = _overDueChecker.getTicketLineColor(mockTimestamp.AddMinutes(dueDateMinutesToAdd));
                        
                        //Assert
                        Assert.AreEqual("black", color);
                }




        //Run multiple testcases against full overDueCheck that compares the date against current local timestamp
        //[TestCase("2024/02/29 19:17:20")]
        //[TestCase("2023/02/21 11:15")]
        //[TestCase("2024/01/29 13:14:15")]
        //[TestCase("2024/01/29")]
        //public void getTicketLineColor_OverDueEqualTest(String dateTimeStr)
        //{
        //    
        //    String color = _overDueChecker.getTicketLineColor(dateTimeStr);
//
        //    Assert.AreEqual("red", color);
        //}

        // [TestCase("2025/02/28 19:15:20")]
        //[TestCase("2024/09/05 12:30:45")]
        //[TestCase("2024/05/17 10:15:20")]
        //[TestCase("2026/06/20")]
        //public void getTicketLineColor_OverDueNotEqualTest(String dateTimeStr)
        //{
//
        //    String color = _overDueChecker.getTicketLineColor(dateTimeStr);
//
        //    Assert.AreNotEqual("red", color);
        //}
//
        //[TestCase("2025/02/28 19:15:20")]
        //[TestCase("2024/09/05 12:30:45")]
        //[TestCase("2024/05/17 10:15:20")]
        //[TestCase("2026/06/20")]
        //public void getTicketLineColor_notDueEqualTest(String dateTimeStr)
        //{
//
        //    String color = _overDueChecker.getTicketLineColor(dateTimeStr);
//
        //    Assert.AreEqual("black", color);
        //}
//
        //[TestCase("2024/02/29 19:17:20")]
        //[TestCase("2023/02/21 11:15")]
        //[TestCase("2024/01/29 13:14:15")]
        //[TestCase("2024/01/29")]
        //public void getTicketLineColor_notDueNotEqualTest(String dateTimeStr)
        //{
//
        //    String color = _overDueChecker.getTicketLineColor(dateTimeStr);
//
        //    Assert.AreNotEqual("black", color);
        //}
//
        ////Run a generic all compassing overDue check against current timestamp
        //[Test]
        //public void getTicketLineColor_genericTests()
        //{
        //    String overDueTimeStr = "2024/01/29 19:17:20";
        //    String futureTimeStr = "2025/02/28";
//
        //    String colorOverDue = _overDueChecker.getTicketLineColor(overDueTimeStr);
        //    String colorFuture = _overDueChecker.getTicketLineColor(futureTimeStr);
//
        //    Assert.AreEqual("red",      colorOverDue);
        //    Assert.AreNotEqual("black", colorOverDue);
//
        //    Assert.AreEqual("black",  colorFuture);
        //    Assert.AreNotEqual("red", colorFuture);
        //}

        //Run a test to verify if the overdue logic meets the requirements (less than 1h until deadline)
       

    }
}
