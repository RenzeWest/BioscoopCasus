using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BioscoopTests.TestHelpers;


namespace BioscoopTests
{
    public class StudentOrderTests
    {
        [Fact]
        public void OneTicket_Weekday_NoPremium_PriceIs10()
        {
            var order = CreateOrder(1, true, 1, false, false);
            Assert.Equal(10, order.CalculatePrice());
        }

        [Fact]
        public void TwoTickets_Weekday_NoPremium_SecondTicketFree()
        {
            var order = CreateOrder(2, true, 2, false, false);
            Assert.Equal(10, order.CalculatePrice());
        }

        [Fact]
        public void TwoTickets_Weekday_Premium_SecondTicketFree()
        {
            var order = CreateOrder(3, true, 2, true, false);
            Assert.Equal(12, order.CalculatePrice());
        }

        [Fact]
        public void SixTickets_Weekend_Premium_EverySecondFree()
        {
            var order = CreateOrder(8, true, 6, true, true);
            Assert.Equal(36, order.CalculatePrice());
        }

        [Fact]
        public void OneTicket_Weekend_NoPremium_PriceIs10()
        {
            var order = CreateOrder(10, true, 1, false, true);
            Assert.Equal(10, order.CalculatePrice());
        }
    }
}
