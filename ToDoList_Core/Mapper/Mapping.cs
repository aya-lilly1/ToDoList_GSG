using AutoMapper;
using ToDoList_GSG.ModelView;
using ToDoList_GSG.Models;
using ToDoList_GSG.ModelViews.ModelView;
using ToDoList_GSG.Common.Extensions;

namespace ToDoList_GSG.Mapper
{
    public class Mapping : Profile 
    {
        public Mapping()
        {
           
            CreateMap<User, LoginUserResponse>().ReverseMap();
            CreateMap<UserResult, User>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<ItemModelView, Item>().ReverseMap();
            CreateMap<PagedResult<ItemModelView>, PagedResult<Item>>().ReverseMap();
        }
    }
}
