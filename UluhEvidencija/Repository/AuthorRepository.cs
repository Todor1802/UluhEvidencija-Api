using Microsoft.EntityFrameworkCore;
using UluhEvidencija.Contract.IRepository;
using UluhEvidencija.Contract.Models;
using UluhEvidencija.Contract.Models.Response;
using UluhEvidencija.Migration;

namespace UluhEvidencija.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Response<List<Author>>> GetAll()
        {
            try
            {
                return Response.Success(await _context.Authors.ToListAsync());
            }
            catch (Exception ex)
            {
                return Response.Error(ex.Message);
            }
        }
        public async Task<Response<Author?>> Get(int id)
        {
            try
            {
                return Response.Success(await _context.Authors.FindAsync(id));
            }
            catch (Exception ex)
            {
                return Response.Error(ex.Message);
            }
        }
        public async Task<Response<Author>> Add(Author author)
        {
            try
            {
                var res = await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();
                return Response.Success(author);
            }
            catch (Exception ex)
            {
                return Response.Error(ex.Message);
            }
        }
        public async Task<Response<Author?>> Update(Author author)
        {
            try
            {
                _context.Authors.Attach(author);
                _context.Entry(author).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Response.Success(author ?? null);
            }
            catch (Exception ex)
            {
                return Response.Error(ex.Message);
            }
        }
        public async Task<Response<bool>> Delete(int id)
        {
            try
            {
                var deletedPaintings = await _context.Authors
                    .Where(p => p.ID == id)
                    .ExecuteDeleteAsync();

                if (deletedPaintings != 0)
                {
                    return Response.Success(true);
                }
                return Response.Conflict("Nothing to delete");
            }
            catch (Exception ex)
            {
                return Response.Error(ex.Message);
            }
        }
    }
}
