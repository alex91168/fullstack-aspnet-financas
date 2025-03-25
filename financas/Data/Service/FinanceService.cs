using financas.Models;
using Microsoft.EntityFrameworkCore;

namespace financas.Data.Service{
    public class FinanceService : IFinanceService {
        private readonly FinanceContext _context;

        public FinanceService(FinanceContext context){
            _context = context;
        }
        public async Task<IEnumerable<FinancasModel>> DataBaseGet(){
            var data = await _context.FinancasModel.ToListAsync();
            return data;
        }
        public async Task Add(FinancasModel financasModel)
        {
            _context.FinancasModel.Add(financasModel);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, FinancasModel edit)
        {
            var item = await _context.FinancasModel.FindAsync(id);

            if (item != null)
            {
                item.Amount = edit.Amount;
                item.Description = edit.Description;
                item.Type = edit.Type;
                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new Exception("Item não encontrado");
            }
        }

        public async Task Delete(int id)
        {
            var item = await _context.FinancasModel.FindAsync(id);

            if (item != null)
            {
                _context.FinancasModel.Remove(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Item nao encontrado");
            }
        }
    }
}