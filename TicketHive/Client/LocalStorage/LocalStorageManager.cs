using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Client.LocalStorage;
public class LocalStorageManager{

    private readonly ILocalStorageService _localStorage;

    public LocalStorageManager(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task InitializeUserAsync(string username)
    {
        bool IsUserInLocalStorage = await CheckIfUserExistsAsync(username);

        if (!IsUserInLocalStorage)
        {
            await AddUser(username);
        }
    }

    public async Task<bool> CheckIfUserExistsAsync(string username)
    {
        return await _localStorage.ContainKeyAsync($"{username}_cart");
    }

    private async Task AddUser(string username)
    {
        List<CartItemViewModel> cartItems = new();

        await _localStorage.SetItemAsync($"{username}_cart", cartItems);
    }

    public async Task AddCartItemAsync(CartItemViewModel cartItem, string username)
    {
        List<CartItemViewModel>? cartItems = await GetCartItems(username);
        
        cartItems.Add(cartItem);

        await _localStorage.SetItemAsync($"{username}_cart", cartItems);
    }

    public async Task<List<CartItemViewModel>?> GetCartItems(string username)
    {
        return await _localStorage.GetItemAsync<List<CartItemViewModel>>($"{username}_cart");
    }

    public async Task RemoveCartItemAsync(List<CartItemViewModel> cartItems, CartItemViewModel cartItem, string username)
    {
        cartItems.Remove(cartItem);

        await _localStorage.SetItemAsync($"{username}_cart", cartItems);
    }

    public async Task ClearCartAsync(string username)
    {
        List<CartItemViewModel> cartItems = new();

        await _localStorage.SetItemAsync($"{username}_cart", cartItems);
    }

    public async Task RemoveEventFromCartAsync(CartItemViewModel cartItem, string username)
    {
        List<CartItemViewModel>? cartItems = (await GetCartItems(username));

        cartItems.RemoveAll(e => e.Id.Equals(cartItem.Id));

        await _localStorage.SetItemAsync($"{username}_cart", cartItems);
    }

    public async Task AddExchangeRateAsync(double exchangeRate, string username)
    {
        if(exchangeRate == 0)
        {
            exchangeRate = 1;
        }

        await _localStorage.SetItemAsync($"{username}_exchangeRate", exchangeRate);
	}

	public async Task<double> GetExchangeRateAsync(string username)
	{
		return await _localStorage.GetItemAsync<double>($"{username}_exchangeRate");
	}

    public async Task AddCurrencyForDisplayAsync(string currency, string username)
    {
        double exchangeRate = await GetExchangeRateAsync(username);

        if (exchangeRate == 1)
        {
            currency = "USD";
        }

        await _localStorage.SetItemAsync($"{username}_currency", currency);
    }

    public async Task<string> GetCurrencyForDisplayAsync(string username)
    {
        return await _localStorage.GetItemAsync<string>($"{username}_currency");
    }
}
