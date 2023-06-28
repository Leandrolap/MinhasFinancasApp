using MinhasFinancasApp.Models;

namespace MinhasFinancasApp.Repositories
{
    public interface ITransicaoRepositorio
    {
        void Add(Transacao transacao);
        void Delete(Transacao transacao);
        List<Transacao> GetAll();
        void Update(Transacao transacao);
    }
}