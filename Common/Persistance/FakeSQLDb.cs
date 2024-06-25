using TransManager.Domain.Models;

namespace TransManager.Common.Persistance
{
	public class FakeSQLDb
	{
		public List<Movie> movies = new() {
			new Movie("The Lord Of The Rings: The Fellowship Of The Ring"),
			new Movie("Star Wars: The Empire Strikes Back"),
			new Movie("The Godfather"),
			new Movie("The Dark Knight"),
			new Movie("The Shawshank Redemption"),
			new Movie("Jaws"),
			new Movie("Raiders Of The Lost Ark") };
	}
}
