using Blazored.LocalStorage;
using Intersoft.Crosslight;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Client.LocalStorage;
public class LocalStorageManager{

    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _provider;
    private string _username;

    public LocalStorageManager(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task InitializeUserAsync(string username)
    {
        _username = username;

        bool IsUserInLocalStorage = await CheckIfUserExistsAsync(_username);

        if (!IsUserInLocalStorage)
        {
            await AddUser();
        }
    }

    public async Task<bool> CheckIfUserExistsAsync(string username)
    {
        return await _localStorage.ContainKeyAsync(_username);
    }

    public async Task AddUser()
    {
        List<CartItemViewModel> cartItems = new();

        await _localStorage.SetItemAsync($"{_username}", cartItems);
    }

    public async Task AddCartItemAsync(CartItemViewModel cartItem)
    {
        List<CartItemViewModel>? cartItems = await GetCartItems();
        
        cartItems.Add(cartItem);

        await _localStorage.SetItemAsync($"{_username}", cartItems);
    }

    public async Task<List<CartItemViewModel>?> GetCartItems()
    {
        return await _localStorage.GetItemAsync<List<CartItemViewModel>>(_username);
    }

    public void AddExchangeRate()
    {

    }
}
