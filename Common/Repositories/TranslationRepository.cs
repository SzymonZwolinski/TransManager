
using System.Xml.Linq;
using TransManager.Common.Persistance;
using TransManager.Domain.Models;

namespace TransManager.Common.Repositories
{
	public class TranslationRepository : ITranslationRepository
	{
		private readonly SqlLiteDb _sqliteDb;

		public TranslationRepository(SqlLiteDb sqliteDb)
		{
			_sqliteDb = sqliteDb;
		}

		public string GetTranslation(string type, string name, string cultureCode)
			=> _sqliteDb.Translations.FirstOrDefault(x => x.Type.Equals(type) && x.Name.Equals(name) && x.CultureInfo.Equals(cultureCode)).Value;

		public string GetTranslation(string type, Guid typeId, string cultureCode)
			=> _sqliteDb.Translations.FirstOrDefault(x => x.Type.Equals(type) && x.TypeId == typeId && x.CultureInfo.Equals(cultureCode)).Value;

		public void SeedData(List<Translation> translation)
		{
			_sqliteDb.Translations.AddRange(translation);
			_sqliteDb.SaveChanges();
		}
	}
}
