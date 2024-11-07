using AutoMapper;
using LibSevSUBackend.AppServices.Contexts.Files.Images.Repositories;
using LibSevSUBackend.Contracts.Files.Images;
using LibSevSUBackend.Domain.Files.Images.Entity.Base;
using LibSevSUBackend.Infrastructure.Repository;

namespace LibSevSUBackend.DataAccess.Files.Images.Repository;

///<inheritdoc cref="IImageRepository"/>
public class ImageRepository : IImageRepository
{
    private readonly IRepository<Image> _repository;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Создаёт экземпляр <see cref="ImageRepository"/>.
    /// </summary>
    /// <param name="repository">Репозиторий.</param>
    /// <param name="mapper">Маппер.</param>
    public ImageRepository(IRepository<Image> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(ImageDto image, CancellationToken cancellationToken)
    {
        var imageEntity = _mapper.Map<Image>(image);
        return await _repository.AddAsync(imageEntity, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(id, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ImageDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var image = await _repository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<ImageDto>(image);
    }
}