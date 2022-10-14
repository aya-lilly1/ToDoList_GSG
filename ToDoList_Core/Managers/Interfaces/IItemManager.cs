using ToDoList_GSG.ModelViews.ModelView;
using ToDoList_GSG.ModelView;
using Tazeez.ModelViews.Request;

namespace ToDoList_GSG.Core.Managers.Interfaces
{
    public interface IItemManager
    {
        ItemResponse GetItems(int page = 1, int pageSize = 10, string sortColumn = "", string sortDirection = "ascending", string searchText = "");

        ItemModelView GetItem(int id);

        ItemModelView PutItems(UserModel currentUser, ItemRequest ItemRequest);

        void ArchiveItem(UserModel currentUser, int id);
    }
}
