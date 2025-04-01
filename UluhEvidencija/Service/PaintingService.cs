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
    public class PaintingService : IPaintingService
    {
        private readonly IPaintingRepository _paintingRepository;

        public PaintingService(IPaintingRepository paintingRepository)
        {
            _paintingRepository = paintingRepository;
        }
        public Task<Response<Painting>> AddPainting(Painting painting)
            => _paintingRepository.AddPainting(painting);

        public Task<Response<bool>> DeletePainting(int id) =>
            _paintingRepository.DeletePainting(id);

        public Task<Response<List<Painting>>> GetAllPaintings() =>
            _paintingRepository.GetAllPaintings();

        public Task<Response<Painting>> GetPainting(int id) =>
            _paintingRepository.GetPainting(id);

        public Task<Response<Painting>> UpdatePainting(Painting painting) =>
            _paintingRepository.UpdatePainting(painting);
    }
}
