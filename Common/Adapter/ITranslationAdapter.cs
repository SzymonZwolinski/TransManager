using System.Globalization;
using TransManager.Domain.Models.Markers;

namespace TransManager.Common.Adapter
{
	public interface ITranslationAdapter
	{
		void Adapt<T>(T entity, string name, CultureInfo culutre) where T : class, ITranslatable;
	}
}
