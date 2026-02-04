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

        private List<MovieTicket> _movieTickets = []; // This releation is 1..*, so the constructor should contain an MovieTicket
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
            bool isWeekendScreening = _movieTickets[0].IsScreeningInWeekend();

            if (_isStudentOrder) 
            {
                for (int i = 0; i < _movieTickets.Count; i++)
                {
                    // Second ticket is free
                    if (!isWeekendScreening && i % 2 == 0) continue;

                    var ticket = _movieTickets[i];
                    totalPrice += ticket.GetPrice();

                    // Check to add premium
                    if (ticket.IsPremiumTicket()) totalPrice += PRICE_PREMIUM_TICKET_STUDENT;
                }
            } else
            {
                for (int i = 0; i < _movieTickets.Count; i++)
                {
                    var ticket = _movieTickets[i];
                    totalPrice += ticket.GetPrice();

                    // Check to add premium
                    if (ticket.IsPremiumTicket()) totalPrice += PRICE_PREMIUM_TICKET;
                }

                // If weekend, give a 10% discount for non students
                if (isWeekendScreening && _movieTickets.Count >= MINIMUM_TICKETS_FOR_GROUP_DISCOUNT) totalPrice *= WEEKEND_GROUP_DISCOUNT_MODIFIER;
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
                    sb.AppendLine($"Total price: {CalculatePrice()}");
                    foreach(MovieTicket ticket in _movieTickets) sb.AppendLine(ticket.ToString());
                    File.WriteAllText($"C:\\dev\\{identifier}.txt", sb.ToString());
                    break;
                case TicketExportFormat.JSON:
                    string json = JsonSerializer.Serialize(_movieTickets);
                    File.WriteAllText($"C:\\dev\\{identifier}.json", json);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
