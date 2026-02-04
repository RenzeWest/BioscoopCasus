namespace BioscoopCasus.Domain
{
    public class MovieTicket
    {
        private static readonly DayOfWeek[] WEEK_DAYS = { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday };
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

        public double GetPrice() => _movieScreening.GetPricePerSeat();

        public bool IsScreeningInWeekend() => WEEK_DAYS.Contains(_movieScreening.GetScreeningDate().DayOfWeek);

        public override string? ToString() => $"Row: {_rowNr}, Seat: {_seatNr}, Premium Ticket: {_isPremium}";
    }
}
