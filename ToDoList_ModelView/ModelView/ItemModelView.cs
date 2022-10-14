
using System;

namespace ToDoList_GSG.ModelViews.ModelView
{
    public class ItemModelView
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
