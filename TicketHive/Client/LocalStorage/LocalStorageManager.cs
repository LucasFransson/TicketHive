using Blazored.LocalStorage;
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
    //private readonly string _username;

    public LocalStorageManager(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task InitializeUserAsync(string username)
    {
        //_username = username;

        bool IsUserInLocalStorage = await CheckIfUserExistsAsync(username);

        if (!IsUserInLocalStorage)
        {
            await AddUser(username);
        }
    }

    public async Task<bool> CheckIfUserExistsAsync(string username)
    {
        return await _localStorage.ContainKeyAsync(username);
    }

    public async Task AddUser(string username)
    {
        List<CartItemViewModel> cartItems = new();

        await _localStorage.SetItemAsync($"{username}", cartItems);
    }

    public async Task AddCartItemAsync(CartItemViewModel cartItem, string username)
    {
        List<CartItemViewModel>? cartItems = await GetCartItems(username);
        
        cartItems.Add(cartItem);

        await _localStorage.SetItemAsync($"{username}", cartItems);
    }

    //public async Task<IGrouping<int, CartItemViewModel>?> GetCartItemsGroupedById(string username)
    //{
    //    List<CartItemViewModel>? cartItems = await _localStorage.GetItemAsync<List<CartItemViewModel>>(username);

    //    IGrouping<int, CartItemViewModel>? test = (IGrouping<int, CartItemViewModel>?) cartItems.GroupBy(i => i.Id).ToList();
        
    //    return test;
    //}

    public async Task<List<CartItemViewModel>?> GetCartItems(string username)
    {
        return await _localStorage.GetItemAsync<List<CartItemViewModel>>(username);
    }

    public async Task RemoveCartItemAsync(List<CartItemViewModel> cartItems, CartItemViewModel cartItem, string username)
    {
        cartItems.Remove(cartItem);

        await _localStorage.SetItemAsync($"{username}", cartItems);
    }

    public async Task RemoveEventFromCartAsync

    public void AddExchangeRate()
    {

    }
}
