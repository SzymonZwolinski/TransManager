namespace TransManager.Domain.Models
{
	public class Movie
	{
		public string Name { get; private set; }
		
		public Movie(string name) 
		{
			SetName(name);
		}

		private void SetName(string name) 
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("value could not be null");
			}

			Name = name;
		}
	}
}
