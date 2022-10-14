using System.ComponentModel.DataAnnotations;

namespace ToDoList_GSG.ModelView
{
    public class LoginModelView
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
