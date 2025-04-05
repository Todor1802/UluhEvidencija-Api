using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UluhEvidencija.Contract.IRepository;
using UluhEvidencija.Contract.IService;
using UluhEvidencija.Contract.Models;
using UluhEvidencija.Contract.Models.Response;

namespace UluhEvidencija.Service
{
    public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public Task<Response<Author>> AddAuthor(Author author) =>
            _authorRepository.Add(author);

        public Task<Response<bool>> DeleteAuthor(int id) =>
            _authorRepository.Delete(id);

        public Task<Response<List<Author>>> GetAllAuthors() =>
            _authorRepository.GetAll();

        public Task<Response<Author>> GetAuthor(int id) =>
            _authorRepository.Get(id);

        public Task<Response<Author>> UpdateAuthor(Author author) =>
            _authorRepository.Update(author);
    }
}
