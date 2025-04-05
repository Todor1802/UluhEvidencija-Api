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
    public class PaintingService(IPaintingRepository paintingRepository) : IPaintingService
    {
        private readonly IPaintingRepository _paintingRepository = paintingRepository;

        public Task<Response<Painting>> AddPainting(Painting painting)
            => _paintingRepository.Add(painting);

        public Task<Response<bool>> DeletePainting(int id) =>
            _paintingRepository.Delete(id);

        public Task<Response<List<Painting>>> GetAllPaintings() =>
            _paintingRepository.GetAll();

        public Task<Response<Painting>> GetPainting(int id) =>
            _paintingRepository.Get(id);

        public Task<Response<Painting>> UpdatePainting(Painting painting) =>
            _paintingRepository.Update(painting);
    }
}
