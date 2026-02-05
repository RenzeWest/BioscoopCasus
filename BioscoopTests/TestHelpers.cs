using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopCasus.Domain;

namespace BioscoopTests
{
    public class TestHelpers
    {
        private static MovieScreening CreateDummyScreening(bool isWeekend)
        {
            var movie = CreateDummyMovie();
            DateTime date = isWeekend ? new DateTime(2026, 2, 7) : new DateTime(2026, 2, 3); 
            double price = 10; 
            return new MovieScreening(movie, date, price);
        }

        public static MovieTicket CreateTicket(bool isPremium, bool isWeekend, int rowNr = 1, int seatNr = 1)
        {
            var screening = CreateDummyScreening(isWeekend);
            return new MovieTicket(screening, rowNr, seatNr, isPremium);
        }

        public static Order CreateOrder(int orderNr, bool isStudent, int ticketCount, bool isPremium, bool isWeekend)
        {
            var order = new Order(orderNr, isStudent);
            for (int i = 0; i < ticketCount; i++)
                order.AddSeatReservation(CreateTicket(isPremium, isWeekend, 1, i + 1));
            return order;
        }

        private static Movie CreateDummyMovie()
        {
            return new Movie("Dummy Movie"); 
        }
    }
}
