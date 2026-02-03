namespace BioscoopCasus.Domain
{
    internal class MovieTicket
    {

        private MovieScreening _movieScreening { get; set; }
        private int _rowNr { get; }
        private int _seatNr { get; }
        private bool _isPremium { get; }

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium)
        {
            _movieScreening = movieScreening;
            _rowNr = rowNr;
            _seatNr = seatNr;
            _isPremium = isPremium;
        }

        public bool IsPremiumTicket() => _isPremium;

        // TODO: Change price based on date
        public double GetPrice() => _movieScreening.GetPricePerSeat(); // If we add _isStudentTicket to this object we could calculate the price of the ticket in here. Which feels like it would make more sense...

        public override string? ToString() => $"Price: {GetPrice()}\nRow: {_rowNr}, Seat: {_seatNr}, Premium Ticket: {_isPremium}";
    }
}
