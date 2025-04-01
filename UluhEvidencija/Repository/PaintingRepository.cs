using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UluhEvidencija.Contract.IRepository;
using UluhEvidencija.Contract.Models;
using UluhEvidencija.Contract.Models.Response;
using UluhEvidencija.Migration;

namespace UluhEvidencija.Repository
{
    public class PaintingRepository(AppDbContext context) : IPaintingRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Response<Painting>> AddPainting(Painting painting)
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

        public Task<Response<bool>> DeletePainting(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Painting>>> GetAllPaintings()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Painting>> GetPainting(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Painting>> UpdatePainting(Painting painting)
        {
            throw new NotImplementedException();
        }
    }
}
