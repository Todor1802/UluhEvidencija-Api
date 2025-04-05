using UluhEvidencija.Contract.Models;
using UluhEvidencija.Contract.Models.Response;

namespace UluhEvidencija.Contract.IRepository
{
    public interface IPaintingRepository
    {
        Task<Response<List<Painting>>> GetAll();
        Task<Response<Painting?>> Get(int id);
        Task<Response<Painting>> Add(Painting painting);
        Task<Response<Painting?>> Update(Painting painting);
        Task<Response<bool>> Delete(int id);
    }
}
