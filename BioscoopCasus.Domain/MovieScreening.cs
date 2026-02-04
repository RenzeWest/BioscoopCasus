namespace BioscoopCasus.Domain
{
    internal class MovieScreening
    {
        private List<MovieTicket> _movieTickets = [];
        private readonly Movie _movie;
        private readonly DateTime _dateTime;
        private double _pricePerSeat;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            _movie = movie;
            _dateTime = dateAndTime;
            _pricePerSeat = pricePerSeat;
        }

        public double GetPricePerSeat() => _pricePerSeat; 

        public override string ToString() => _pricePerSeat.ToString();

        internal DateTime GetScreeningDate() => _dateTime;
    }
}
