
using DctWebApp.Data;
using DctWebApp.Data.Account;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DctWebApp.Services
{
    public interface IAccountService
    {
        User user { get; }
        Shipper shipper { get; }
        Task Initialize();
        Task Login(User user, Shipper shipper);
        Task Logout();
        Task<User> CurrentUser();
        Task<Shipper> CurrentShipper();
        Task<bool> IsAuthorized();
    }

    public class AccountService : IAccountService
    {
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";
        private string _shipperKey = "shipper";

        public User user { get; private set; }
        public Shipper shipper { get; private set; }

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
            shipper = await _localStorageService.GetItem<Shipper>(_shipperKey);
        }

        public async Task Login(User user, Shipper shipper)
        {
            await _localStorageService.SetItem(_userKey, user);
            await _localStorageService.SetItem(_shipperKey, shipper);
        }

        public async Task Logout()
        {
            user = await _localStorageService.GetItem<User>(_userKey);
            shipper = await _localStorageService.GetItem<Shipper>(_shipperKey);
            if (user != null)
            {
                user = null;
                await _localStorageService.RemoveItem(_userKey);
            }
            if (shipper != null)
            {
                shipper = null;
                await _localStorageService.RemoveItem(_shipperKey);
            }
            _navigationManager.NavigateTo("/shipper/dang-nhap");
        }

        public async Task<User> CurrentUser()
        {
            var json = await _localStorageService.GetItemJSON(_userKey);
            user = new User(json);
            return user;
        }

        public async Task<Shipper> CurrentShipper()
        {
            var json = await _localStorageService.GetItemJSON(_shipperKey);
            shipper = new Shipper(json);
            return shipper;
        }

        public async Task<bool> IsAuthorized()
        {
            await Initialize();
            return user != null;
        }
    }
}
