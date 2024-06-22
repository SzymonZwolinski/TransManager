using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransManager.Common;
using TransManager.Common.Persistance;
using TransManager.Domain.Enums;
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

    public record GetWordQuery(Languages language, string name) : IRequest<Movie>;

	internal sealed class GetMovieHandler : IRequestHandler<GetWordQuery, Movie>
	{
		private readonly FakeSQLDb _db;

        public Task<Movie> Handle(GetWordQuery request, CancellationToken cancellationToken)
		{
			var movie = _db.movies.FirstOrDefault(x => x.Name.Equals(request.name));

			return Task.FromResult(movie);
		}
	}
}
