using server.Database;
using server.Model;

namespace server.Services
{
    public class AnimalService
    {
        private readonly FarmContext _context;

        public AnimalService(FarmContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AnimalModel>> CreateAsync(AnimalModel model)
        {
            if (_context.Animals.Any(x => x.Name == model.Name))
            {
                // I prefer exception flow with handling middleware but decided to use a monad here instead for convenience
                return new ResponseModel<AnimalModel>()
                {
                    Success = false,
                    ErrorMessage = "already-exists"
                };
            }
            // TODO: Use a mapper
            var entity = new AnimalEntity
            {
                Name = model.Name
            };
            _context.Add(entity);
            await _context.SaveChangesAsync();
            model.Id = entity.Id;
            return new ResponseModel<AnimalModel>
            {
                Success = true,
                Data = model
            };
        }

        internal async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Animals.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            _context.Animals.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        internal IEnumerable<AnimalModel> List()
        {
            return _context.Animals.ToList().Select(x => new AnimalModel
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}