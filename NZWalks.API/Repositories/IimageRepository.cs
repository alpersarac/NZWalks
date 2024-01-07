using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IimageRepository
    {
        Task<Image> Upload(Image image);
    }
}
