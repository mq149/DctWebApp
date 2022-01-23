
using DctWebApp.Data;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DctWebApp.Services
{
    public interface IAccountService
    {
        User user { get; }
        Task Initialize();
        Task Login(User user);
        Task Logout();
        Task<User> CurrentUser();
        Task<bool> IsAuthorized();
    }

    public class AccountService : IAccountService
    {
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";

        public User user { get; private set; }

        public AccountService(
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            user = await _localStorageService.GetItem<User>(_userKey);
        }

        public async Task Login(User user)
        {
            await _localStorageService.SetItem(_userKey, user);
        }

        public async Task Logout()
        {
            user = await _localStorageService.GetItem<User>(_userKey);
            if (user != null)
            {
                user = null;
                await _localStorageService.RemoveItem(_userKey);
            }
            _navigationManager.NavigateTo("/shipper/dang-nhap");
        }

        public async Task<User> CurrentUser()
        {
            var json = await _localStorageService.GetItemJSON(_userKey);
            user = new User(json);
            return user;
        }

        public async Task<bool> IsAuthorized()
        {
            await Initialize();
            return user != null;
        }
    }
}
