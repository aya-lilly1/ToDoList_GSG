using System.ComponentModel;

namespace ToDoList_GSG.ModelView
{
    public class UserResult
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DefaultValue("")]
        public string Image { get; set; }

        public string Email { get; set; }
    }
}
