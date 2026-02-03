namespace BioscoopCasus.Domain
{
    internal class Movie
    {
        private List<MovieScreening> _movieScreenings = [];
        private readonly string _title;

        public Movie(string title) => _title = title;

        public void AddScreening(MovieScreening screening) => _movieScreenings.Add(screening);
        
        public override string? ToString() => _title;
    }
}
