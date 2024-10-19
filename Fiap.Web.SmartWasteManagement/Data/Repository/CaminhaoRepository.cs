using Fiap.Web.SmartWasteManagement.Data.Contexts;
using Fiap.Web.SmartWasteManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public class CaminhaoRepository : ICaminhaoRepository
    {
        private readonly DatabaseContext _context;

        public CaminhaoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(CaminhaoModel caminhao)
        {
            _context.Caminhoes.Add(caminhao);
            _context.SaveChanges();
        }

        public void Delete(CaminhaoModel caminhao)
        {
            _context.Caminhoes.Remove(caminhao);
            _context.SaveChanges();
        }

        public IEnumerable<CaminhaoModel> GetAllWithoutPage()
        {
            return _context.Caminhoes.ToList();
        }

        public IEnumerable<CaminhaoModel> GetAll(int page, int size)
        {
            return _context.Caminhoes.Skip((page - 1) * page).Take(size).AsNoTracking().ToList();
        }

        public IEnumerable<CaminhaoModel> GetAllReference(int lastReference, int size)
        {
            return _context.Caminhoes.Where(c => c.Codigo > lastReference).OrderBy(c => c.Codigo).Take(size).AsNoTracking().ToList();
        }

        public CaminhaoModel GetById(int id) => _context.Caminhoes.Find(id)!;

        public void Update(CaminhaoModel caminhao)
        {
            _context.Caminhoes.Update(caminhao);
            _context.SaveChanges();
        }
    }
}
