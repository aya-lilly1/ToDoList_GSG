using ToDoList_GSG.ModelView;

namespace ToDoList_GSG.Core.Managers.Interfaces
{
    public interface IRoleManager : IManager
    {
        bool CheckAccess(UserModel userModel);
    }
}
