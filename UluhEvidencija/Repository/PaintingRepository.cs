using Microsoft.EntityFrameworkCore;
using UluhEvidencija.Contract.IRepository;
using UluhEvidencija.Contract.Models;
using UluhEvidencija.Contract.Models.Response;
using UluhEvidencija.Migration;

namespace UluhEvidencija.Repository
{
    public class PaintingRepository(AppDbContext context) : IPaintingRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Response<Painting>> Add(Painting painting)
        {
            try
            {
                var res = await _context.Paintings.AddAsync(painting);
                await _context.SaveChangesAsync();
                return Response.Success(painting);
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
                var deletedPaintings = await _context.Paintings
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

        public async Task<Response<List<Painting>>> GetAll()
        {
            try
            {
                return Response.Success(await _context.Paintings.ToListAsync());
            }
            catch (Exception ex)
            {
                return Response.Error(ex.Message);
            }
        }

        public async Task<Response<Painting?>> Get(int id)
        {
            try
            {
                return Response.Success(await _context.Paintings.FindAsync(id));
            }
            catch (Exception ex)
            {
                return Response.Error(ex.Message);
            }
        }

        public async Task<Response<Painting?>> Update(Painting painting)
        {
            try
            {
                _context.Paintings.Attach(painting);
                _context.Entry(painting).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Response.Success(painting ?? null);
            }
            catch (Exception ex)
            {
                return Response.Error(ex.Message);
            }
        }
    }
}
