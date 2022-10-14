using AutoMapper;
using ToDoList_GSG.Core.Managers.Interfaces;
using ToDoList_GSG.Models;
using ToDoList_GSG.ModelView;
using System.Linq;
using Tazeez.Common.Extensions;

namespace ToDoList_GSG.Core.Managers
{
    public class CommonManager : ICommonManager
    {
        private todolistContext _dbContext;
        private IMapper _mapper;

        public CommonManager(todolistContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserModel GetUserRole(UserModel user)
        {
            var dbUser = _dbContext.Users
                                      .FirstOrDefault(a => a.Id == user.Id)
                                      ?? throw new ServiceValidationException("Invalid user id received");

            return _mapper.Map<UserModel>(dbUser);
        }
    }
}
