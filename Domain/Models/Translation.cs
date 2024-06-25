using System.Globalization;

namespace TransManager.Domain.Models
{
	public class Translation
	{
		public Guid Id { get; set; }
		public string Type { get; set; }
		public Guid TypeId { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public string CultureInfo { get; set; }

		public Translation(string type, Guid typeId, string name, string value, CultureInfo cultureInfo)
		{
			Type = type;
			TypeId = typeId;
			Name = name;
			Value = value;	
			CultureInfo = cultureInfo.ToString();
		}

        public Translation()
        {
            
        }
    }
}
