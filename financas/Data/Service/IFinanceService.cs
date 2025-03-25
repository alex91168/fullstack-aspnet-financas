using financas.Models;

namespace financas.Data.Service{
    public interface IFinanceService
    {
        Task<IEnumerable<FinancasModel>> DataBaseGet();
        Task Add(FinancasModel financasModel);
        Task Update(int id, FinancasModel financasModel);
        Task Delete(int id);
    }
}
