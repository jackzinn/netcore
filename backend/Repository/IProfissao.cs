using System.Collections.Generic;
using backend.Model;
using System.Linq;
using backend.Data;

namespace backend.Repository
{
    public class IProfissao : IDataRepository<Profissao>
    {
        readonly EfDbContext _profissaoContext;
        // METODO CONSTRUTOR
        public IProfissao(EfDbContext context)
        {
            _profissaoContext = context;
        }

        public IEnumerable<Profissao> Read()
        {
            return _profissaoContext.Profissoes.ToList();
        }
        // create profissao
        public void Create(Profissao entity)
        {
           _profissaoContext.Profissoes.Add(entity);
           _profissaoContext.SaveChanges();
        }

        // delegate profissao
        public void Delete(Profissao entity)
        {
            _profissaoContext.Profissoes.Remove(entity);
            _profissaoContext.SaveChanges();
        }

        // getbyid profissao
        public Profissao ReadId(int id)
        {
            return _profissaoContext.Profissoes
            .FirstOrDefault(e => e.IdProfissao == id);
        }

        // atualizar profissao
        public void Update(Profissao profissao, Profissao entity)
        {
            profissao.Nome = entity.Nome;
            profissao.Descricao = entity.Descricao;
            _profissaoContext.SaveChanges();
            
        }
    }
}