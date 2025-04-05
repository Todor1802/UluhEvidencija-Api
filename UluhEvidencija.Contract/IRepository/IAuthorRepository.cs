using UluhEvidencija.Contract.Models;
using UluhEvidencija.Contract.Models.Response;

namespace UluhEvidencija.Contract.IRepository
{
    public interface IAuthorRepository
    {
        Task<Response<List<Author>>> GetAll();
        Task<Response<Author?>> Get(int id);
        Task<Response<Author>> Add(Author author);
        Task<Response<Author?>> Update(Author author);
        Task<Response<bool>> Delete(int id);
    }
}
