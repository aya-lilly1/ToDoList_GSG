
using ToDoList_GSG.ModelView;

namespace ToDoList_GSG.Core.Managers.Interfaces
{
    public interface ICommonManager : IManager
    {
        UserModel GetUserRole(UserModel user);
    }
}
