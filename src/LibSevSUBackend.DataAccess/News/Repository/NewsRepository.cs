using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibSevSUBackend.AppServices.Contexts.News.Repositories;
using LibSevSUBackend.Contracts.Books;
using LibSevSUBackend.Contracts.Files.Images;
using LibSevSUBackend.Contracts.News;
using LibSevSUBackend.Infrastructure.Repository;
using LibSevSUBackend.Domain.News.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibSevSUBackend.DataAccess.News.Repository;

/// <summary>
/// <inheritdoc cref="INewsRepository"/>
/// </summary>
public class NewsRepository(IRepository<Domain.News.Entity.News> repository, IMapper mapper) : INewsRepository
{
    ///<inheritdoc/>
    public async Task<Guid> AddNewsAsync(NewsDto news, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Domain.News.Entity.News>(news);
        return await repository.AddAsync(entity, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task DeleteNewsAsync(Guid id, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(id, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ICollection<NewsDto>> GetNewsAsync(int take, int? skip, CancellationToken cancellationToken)
    {
        var query = repository
            .GetAll()
            .OrderByDescending(b => b.PublishDate);
        
        if (skip.HasValue) query = (IOrderedQueryable<Domain.News.Entity.News>)query.Skip(skip.Value);
        
        return await query
            .Take(take)
            .ProjectTo<NewsDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<NewsDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var news = await repository.GetByIdAsync(id, cancellationToken);
        return mapper.Map<NewsDto>(news);
    }

    ///<inheritdoc/>
    public async Task AddImageAsync(Guid newsId, Guid imageId, CancellationToken cancellationToken)
    {
        var news = await repository
            .GetByPredicate(u => u.Id == newsId)
            .FirstOrDefaultAsync(cancellationToken);
        news.ImageId = imageId;
        await repository.UpdateAsync(news, cancellationToken);
    }
}