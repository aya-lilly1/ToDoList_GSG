
using System.Collections.Generic;
using ToDoList_GSG.Common.Extensions;
using ToDoList_GSG.ModelView;

namespace ToDoList_GSG.ModelViews.ModelView
{
    public class ItemResponse
    {
        public PagedResult<ItemModelView> Blog { get; set; }

        public  Dictionary<int, UserResult> User { get; set; }
        public PagedResult<ItemModelView> Item { get; set; }
    }
}
