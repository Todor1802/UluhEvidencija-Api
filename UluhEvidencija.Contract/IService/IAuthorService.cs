using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UluhEvidencija.Contract.Models;
using UluhEvidencija.Contract.Models.Response;

namespace UluhEvidencija.Contract.IService
{
    public interface IAuthorService
    {
        Task<Response<List<Author>>> GetAllAuthors();
        Task<Response<Author>> GetAuthor(int id);
        Task<Response<Author>> AddAuthor(Author author);
        Task<Response<Author>> UpdateAuthor(Author author);
        Task<Response<bool>> DeleteAuthor(int id);
    }
}
