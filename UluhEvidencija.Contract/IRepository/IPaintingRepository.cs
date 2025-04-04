using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UluhEvidencija.Contract.Models;
using UluhEvidencija.Contract.Models.Response;

namespace UluhEvidencija.Contract.IRepository
{
    public interface IPaintingRepository
    {
        Task<Response<List<Painting>>> GetAllPaintings();
        Task<Response<Painting?>> GetPainting(int id);
        Task<Response<Painting>> AddPainting(Painting painting);
        Task<Response<Painting?>> UpdatePainting(Painting painting);
        Task<Response<bool>> DeletePainting(int id);
    }
}
