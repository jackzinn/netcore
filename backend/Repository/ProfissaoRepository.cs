using System.Collections.Generic;
using backend.Model;
using System.Linq;
using backend.Data;

namespace backend.Repository
{
    public class ProfissaoRepository : IDataRepository<Profissao>
    {
        readonly EfDbContext _profissaoContext;
        // METODO CONSTRUTOR
        public ProfissaoRepository(EfDbContext context) => _profissaoContext = context;

        // create profissao
        public void Create(Profissao entity)
        {
            System.Console.WriteLine("CADASTROU");

           _profissaoContext.Profissoes.Add(entity);
           _profissaoContext.SaveChanges();
        }

        public IEnumerable<Profissao> Read()
        {   
            System.Console.WriteLine("TROUXE TUDO");

            var result = _profissaoContext.Profissoes.ToList();
            return result;
        }
                // getbyid profissao
        public Profissao ReadId(int id)
        {
            System.Console.WriteLine("TROUXE O ID SETADO");

            return _profissaoContext.Profissoes
            .FirstOrDefault(e => e.IdProfissao == id);

            
        }

        // delegate profissao
        public void Delete(Profissao entity)
        {
            System.Console.WriteLine("REMOVEU");

            _profissaoContext.Profissoes.Remove(entity);
            _profissaoContext.SaveChanges();

            
        }

        // atualizar profissao
        public void Update(Profissao profissao)
        {
            System.Console.WriteLine("ATUALIZOU");

            _profissaoContext.Profissoes.Update(profissao);
            _profissaoContext.SaveChanges();

        }
    }
}