using AutoMapper;
using ToDoList_GSG.Core.Managers.Interfaces;
using ToDoList_GSG.ModelView;
using ToDoList_GSG.Models;
using System.Linq;

namespace ToDoList_GSG.Core.Managers
{
    public class RoleManager : IRoleManager
    {

        private todolistContext _dbContext;
        private IMapper _mapper;

        public RoleManager(todolistContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool CheckAccess(UserModel userModel)
        {
            var isAdmin = _dbContext.Users
                                    .Any(a => a.Id == userModel.Id
                                              && a.IsAdmin);
            return isAdmin;
        }
    }
}
