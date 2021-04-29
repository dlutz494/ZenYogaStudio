namespace YogaStudio.App.Services.Interfaces
{
    using System.Collections.Generic;
    using YogaStudio.App.Models.ViewModels;

    public interface IUserService
    {
        IEnumerable<UserViewModel> GetSearchedUsers(string userName);
    }
}
