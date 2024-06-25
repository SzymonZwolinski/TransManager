using System.Globalization;
using TransManager.Common.Repositories;
using TransManager.Domain.Models.Markers;

namespace TransManager.Common.Adapter
{
	public class TranslationAdapter : ITranslationAdapter
	{
		private readonly ITranslationRepository _translationRepository;

		public TranslationAdapter(ITranslationRepository translationRepository)
		{
			_translationRepository = translationRepository;
		}

		public void Adapt<T>(T entity, string name, CultureInfo culture) where T : class, ITranslatable
		{
			var translation = _translationRepository.GetTranslation(entity.GetType().ToString(), name, culture.ToString());

			if(!string.IsNullOrWhiteSpace(translation))
			{
				var propertyInfo = entity.GetType().GetProperty("Name");

				if (propertyInfo != null && propertyInfo.CanWrite)
				{
					propertyInfo.SetValue(entity, translation);
				}
			}
		}
	}
}