namespace YogaStudio.App.Services.Implementations
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Models.ViewModels;
    using YogaStudio.App.Services.Interfaces;

    public class UserService : Service, IUserService
    {
        public UserService(IYogaStudioData data)
            : base(data)
        {
        }

        public UserService(IYogaStudioData data, User user)
            : base(data, user)
        {
        }

        public IEnumerable<UserViewModel> GetSearchedUsers(string userName)
        {
            IEnumerable<User> users = this.Data.Users.All().Where(p => p.UserName.Contains(userName)).OrderBy(p => p.Id);
            IEnumerable<UserViewModel> viewModels = Mapper.Instance.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
            return viewModels;
        }
    }
}