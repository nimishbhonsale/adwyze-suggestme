using Adwyze.SuggestMe.Entities.Artist;

namespace Adwyze.SuggestMe.Services
{
    public interface ILastFmService
    {
        Artist GetArtistByName(string name, int page = 1);
    }
}