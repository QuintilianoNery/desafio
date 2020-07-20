using System.Linq;
using PooLojaVirtual.Core;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Infraestructure
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidade
    {
        private readonly LojaDbContext _dbContext;

        public Repositorio(LojaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Excluir(T entidade)
        {
            _dbContext.Remove(entidade);
            _dbContext.SaveChanges();
        }

        public IQueryable<T> GetAll() => _dbContext.Set<T>().AsQueryable();

        public void Inserir(T entidade)
        {
            _dbContext.Set<T>().Add(entidade);
            _dbContext.SaveChanges();
        }

        public T RecuperarPorId(int id) => _dbContext.Set<T>().Find(id);

        public void Salvar(T entidade)
        {
            _dbContext.Set<T>().Update(entidade);
            _dbContext.SaveChanges();
        }
    }
}