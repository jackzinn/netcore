using System.Collections.Generic;

namespace backend.Repository {
    public interface IDataRepository <TEntity> {

        // GETALL SIMPLES 
        IEnumerable <TEntity> Read();
        // GETBYID POR UM ID ESPECIFICO
        TEntity ReadId(int id);
        // CRIAR DADOS
        void Create(TEntity entity);
        // ATUALIZAR
        void Update(TEntity cliente);
        // APAGAR ITEM
        void Delete(TEntity entity);
    }
}