using AutoMapper;
using ToDoList_GSG.Core.Managers.Interfaces;

using ToDoList_GSG.ModelViews.ModelView;
using ToDoList_GSG.Common.Extensions;
using ToDoList_GSG.Models;
using ToDoList_GSG.ModelView;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tazeez.Common.Extensions;
using Tazeez.ModelViews.Request;

namespace ToDoList_GSG.Core.Managers
{
    public class ItemManager : IItemManager
    {
        private todolistContext _dbContext;
        private IMapper _mapper;

        public ItemManager(todolistContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void ArchiveBlog(UserModel currentUser, int id)
        {
            if (!currentUser.IsAdmin)
            {
                throw new ServiceValidationException("You don't have permission to archive blog");
            }

            var data = _dbContext.Items
                                    .FirstOrDefault(a => a.Id == id)
                                    ?? throw new ServiceValidationException("Invalid blog id received");
            data.Archived = true;
            _dbContext.SaveChanges();
        }

        public void ArchiveItem(UserModel currentUser, int id)
        {
            throw new NotImplementedException();
        }

        public ItemModelView GetBlog(int id)
        {
            var res = _dbContext.Items
                                   .Include("Creator")
                                   .FirstOrDefault(a => a.Id == id)
                                   ?? throw new ServiceValidationException("Invalid blog id received");

            return _mapper.Map<ItemModelView>(res);
        }

        public ItemResponse GetBlogs(int page = 1, int pageSize = 10, string sortColumn = "", string sortDirection = "ascending", string searchText = "")
        {
            var queryRes = _dbContext.Items
                                        .Where(a => string.IsNullOrWhiteSpace(searchText)
                                                    || (a.Title.Contains(searchText)
                                                        || a.Content.Contains(searchText)));

            if (!string.IsNullOrWhiteSpace(sortColumn) && sortDirection.Equals("ascending", StringComparison.InvariantCultureIgnoreCase))
            {
                queryRes = queryRes.OrderBy(sortColumn);
            }
            else if (!string.IsNullOrWhiteSpace(sortColumn) && sortDirection.Equals("descending", StringComparison.InvariantCultureIgnoreCase))
            {
                queryRes = queryRes.OrderByDescending(sortColumn);
            }

            var res = queryRes.GetPaged(page, pageSize);

            var userIds = res.Data
                             .Select(a => a.CreatorId)
                             .Distinct()
                             .ToList();

            var users = _dbContext.Users
                                     .Where(a => userIds.Contains(a.Id))
                                     .ToDictionary(a => a.Id, x => _mapper.Map<UserResult>(x));

            var data = new ItemResponse
            {
                Item = _mapper.Map<PagedResult<ItemModelView>>(res),
                User = users
            };

            data.Item.Sortable.Add("Title", "Title");
            data.Item.Sortable.Add("CreatedDate", "Created Date");

            return data;
        }

        public ItemModelView PutItem(UserModel currentUser, ItemRequest ItemRequest)
        {
            Item item = null;

            if (!currentUser.IsAdmin)
            {
                throw new ServiceValidationException("You don't have permission to add or update item");
            }

            if (ItemRequest.Id > 0)
            {
                item = _dbContext.Items
                                    .FirstOrDefault(a => a.Id == ItemRequest.Id)
                                    ?? throw new ServiceValidationException("Invalid blog id received");

                item.Title = ItemRequest.Title;
                item.Content = ItemRequest.Content;
            }
            else
            {
                item = _dbContext.Items.Add(new Item
                {
                    Title = ItemRequest.Title,
                    Content = ItemRequest.Content,
                    CreatorId = currentUser.Id
                }).Entity;
            }

            _dbContext.SaveChanges();
            return _mapper.Map<ItemModelView>(item);
        }

        public ItemModelView PutItems(UserModel currentUser, ItemRequest ItemRequest)
        {
            throw new NotImplementedException();
        }

        ItemModelView IItemManager.GetItem(int id)
        {
            throw new NotImplementedException();
        }

        ItemResponse IItemManager.GetItems(int page, int pageSize, string sortColumn, string sortDirection, string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
