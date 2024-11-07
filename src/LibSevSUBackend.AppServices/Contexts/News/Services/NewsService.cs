using AutoMapper;
using LibSevSUBackend.AppServices.Contexts.News.Repositories;
using LibSevSUBackend.Contracts.News;

namespace LibSevSUBackend.AppServices.Contexts.News.Services;

///<inheritdoc cref="INewsService"/>
public class NewsService(INewsRepository repository, IMapper mapper) : INewsService
{
    ///<inheritdoc/>
    public async Task<Guid> AddNewsAsync(AddNewsRequest news, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<NewsDto>(news);
        entity.Id = Guid.NewGuid();
        return await repository.AddNewsAsync(entity, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task DeleteNewsAsync(Guid id, CancellationToken cancellationToken)
    {
        await repository.DeleteNewsAsync(id, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ICollection<NewsDto>> GetNewsAsync(int take, int? skip, CancellationToken cancellationToken)
    {
        return await repository.GetNewsAsync(take, skip, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<NewsDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(id, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task AddImageAsync(Guid newsId, Guid imageId, CancellationToken cancellationToken)
    {
        await repository.AddImageAsync(newsId, imageId, cancellationToken);
    }
}