using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BioscoopTests.TestHelpers;

namespace BioscoopTests
{
    public class NonStudentOrderTests
    {
        [Fact]
        public void OneTicket_Weekend_NoPremium_PriceIs10()
        {
            var order = CreateOrder(4, false, 1, false, true);
            Assert.Equal(10, order.CalculatePrice());
        }

        [Fact]
        public void SixTickets_Weekend_NoPremium_GroupDiscountApplied()
        {
            var order = CreateOrder(5, false, 6, false, true);
            Assert.Equal(54, order.CalculatePrice());
        }

        [Fact]
        public void SixTickets_Weekend_Premium_GroupDiscountApplied()
        {
            var order = CreateOrder(6, false, 6, true, true);
            Assert.Equal(78, order.CalculatePrice());
        }

        [Fact]
        public void FiveTickets_Weekend_NoPremium_NoGroupDiscount()
        {
            var order = CreateOrder(7, false, 5, false, true);
            Assert.Equal(50, order.CalculatePrice());
        }

        [Fact]
        public void ZeroTickets_PriceIs0()
        {
            var order = CreateOrder(9, false, 0, false, true);
            Assert.Equal(0, order.CalculatePrice());
        }
    }
}
