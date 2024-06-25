using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TransManager.Common;
using TransManager.Common.Adapter;
using TransManager.Common.Persistance;
using TransManager.Domain.Models;

namespace TransManager.Features.Movies
{
    public class GetMovieController : ApiControllerBase
    {
        public GetMovieController(IMediator mediator) : base(mediator)
        {
        }

        public async Task<ActionResult<Movie>> Get(GetWordQuery query)
        {
            return await _mediator.Send(query);
        }
    }

    public record GetWordQuery(CultureInfo cultureInfo, string name) : IRequest<Movie>;

	internal sealed class GetMovieHandler : IRequestHandler<GetWordQuery, Movie>
	{
		private readonly FakeSQLDb _db;
        private readonly ITranslationAdapter _translationAdapter;

		public GetMovieHandler(FakeSQLDb db, ITranslationAdapter translationAdapter)
		{
			_db = db;
			_translationAdapter = translationAdapter;
		}

		public Task<Movie> Handle(GetWordQuery request, CancellationToken cancellationToken)
		{
			var movie = _db.movies.FirstOrDefault(x => x.Name.Equals(request.name));
			_translationAdapter.Adapt(movie, movie.Name, request.cultureInfo);

			return Task.FromResult(movie);
		}
	}
}
