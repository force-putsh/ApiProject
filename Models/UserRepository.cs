using Microsoft.EntityFrameworkCore;

namespace ApiProject.Models
{
    public class UserRepository:IUserRepository
    {
        readonly DemoDbContext _demoDbContext;

        public UserRepository(DemoDbContext dbContext)
        {
            _demoDbContext = dbContext;
        }

        public async Task<UserDemo> AddUser(UserDemo userDemo)
        {
            var result=await _demoDbContext.UserDemos.AddAsync(userDemo);
            await _demoDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteUser(int id)
        {
            var result=await _demoDbContext.UserDemos.FirstOrDefaultAsync(x => x.Id == id);
            if (result!=null)
            {
                _demoDbContext.UserDemos.Remove(result);
                await _demoDbContext.SaveChangesAsync();
            }
        }

        public async Task<UserDemo> GetUserById(int id)
        {
            return await _demoDbContext.UserDemos.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<UserDemo> UpdateUser(UserDemo userDemo)
        {
            var result=_demoDbContext.UserDemos.FirstOrDefault(e=>e.Id == userDemo.Id);
            if (result!=null)
            {
                result.Nom = userDemo.Nom;
                result.Prenom=userDemo.Prenom;

                await _demoDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<UserDemo>> GetAllUsers()
        {
            return await _demoDbContext.UserDemos.ToListAsync ();
        }
    }
}
