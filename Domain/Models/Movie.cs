using TransManager.Domain.Models.Markers;

namespace TransManager.Domain.Models
{
	public class Movie : ITranslatable
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

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
