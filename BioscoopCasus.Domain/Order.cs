using System.ComponentModel.Design;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace BioscoopCasus.Domain
{
    internal class Order
    {
        private const int MINIMUM_TICKETS_FOR_GROUP_DISCOUNT = 6;
        private const double PRICE_PREMIUM_TICKET_STUDENT = 2;
        private const double PRICE_PREMIUM_TICKET = 3;
        private const double WEEKEND_GROUP_DISCOUNT_MODIFIER = 0.9;

        private List<MovieTicket> _movieTickets = [];
        private int _orderNr;
        private bool _isStudentOrder;

        public Order(int orderNr, bool isStudentOrder)
        {
            _orderNr = orderNr;
            _isStudentOrder = isStudentOrder;
        }

        public int GetOrderNr() => _orderNr;

        public void AddSeatReservation(MovieTicket ticket) => _movieTickets.Add(ticket);

        public double CalculatePrice() 
        {
            double totalPrice = 0;

            // Because of the structure we have to do some of the ticket price calculation here. Feels like this breaks seperation of concerns.
            // ELSE THIS COULD BE FIXED BY HAVING ACCESS TO THE SCREENING.
            if (_isStudentOrder) 
            {
                for (int i = 0; i < _movieTickets.Count; i++)
                {
                    // Second ticket is free
                    if (i % 2 == 0) continue;

                    var ticket = _movieTickets[i];
                    totalPrice += ticket.GetPrice();

                    // Check to add premium
                    if (ticket.IsPremiumTicket()) totalPrice += PRICE_PREMIUM_TICKET_STUDENT;
                }
            } else
            {
                for (int i = 0; i < _movieTickets.Count; i++)
                {
                    // TODO: Second ticket is free on weekdays
                    // if (true) continue;

                    var ticket = _movieTickets[i];
                    totalPrice += ticket.GetPrice();

                    // Check to add premium
                    if (ticket.IsPremiumTicket()) totalPrice += PRICE_PREMIUM_TICKET;
                }

                // If weekend, give a 10% discount for non students
                // FOR NOW I WILL ASSUME THAT IT IS THE WEEKEND
                if (_movieTickets.Count >= MINIMUM_TICKETS_FOR_GROUP_DISCOUNT) totalPrice *= WEEKEND_GROUP_DISCOUNT_MODIFIER;
            }

            return totalPrice;
        }

        public void Export(TicketExportFormat format)
        {
            string identifier = $"movieTickets-{DateTime.Now:yyyyMMdd-HHmmss}";
            switch (format)
            {
                case TicketExportFormat.PLAINTEXT:
                    StringBuilder sb = new("");
                    foreach(MovieTicket ticket in _movieTickets) sb.AppendLine(ticket.ToString());
                    File.WriteAllText($"C:/Downloads/{identifier}.txt", sb.ToString());
                    break;
                case TicketExportFormat.JSON:
                    string json = JsonSerializer.Serialize(_movieTickets);
                    File.WriteAllText($"C:/Downloads/{identifier}.json", json);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
