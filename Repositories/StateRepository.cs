using Microsoft.EntityFrameworkCore;

namespace Repositories
{

    public class StateRepository(PGContext dbContext) : IStateRepository
    {
        private readonly PGContext _dbContext = dbContext;

        public async Task<List<State>> FindAll() => await _dbContext.States.ToListAsync();

        public async Task<State> FindOne(string name)
        {
            State? state = await _dbContext.States.FirstOrDefaultAsync(state => state.name.Contains(name));

            return state ?? throw new Exception("Estado não encontrado na base de dados.");
        }
           
    }
    #region INTERFACE
    public interface IStateRepository
    {
        public Task<List<State>> FindAll();
        public Task<State> FindOne(string name);
    }
    #endregion
}

