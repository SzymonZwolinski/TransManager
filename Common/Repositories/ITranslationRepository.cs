using TransManager.Domain.Models;

namespace TransManager.Common.Repositories
{
	public interface ITranslationRepository
	{
		string GetTranslation(string type, string name, string cultureCode);
		string GetTranslation(string type, Guid typeId, string cultureCode);
		void SeedData(Translation translation);
	}
}
