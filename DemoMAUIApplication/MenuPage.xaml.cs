using DemoMAUIApplication.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DemoMAUIApplication;

public partial class MenuPage : ContentPage
{
    public ObservableCollection<FoodItem> FoodItems { get; set; }
    public ICommand AddToCartCommand { get; set; }
    public MenuPage()
    {
        InitializeComponent();
        FoodItems = new ObservableCollection<FoodItem>
            {
                new FoodItem { Image = "pancake.png", Name = "Food 1", Price = 10.99m },
                new FoodItem { Image = "pancake.png", Name = "Food 2", Price = 12.99m },
                new FoodItem { Image = "pancake.png", Name = "Food 3", Price = 8.99m },
                new FoodItem { Image = "pancake.png", Name = "Food 4", Price = 15.99m },
                new FoodItem { Image = "pancake.png", Name = "Food 5", Price = 9.99m }
            };
        AddToCartCommand = new Command<FoodItem>(AddToCart);
        BindingContext = this;
    }
    private void AddToCart(FoodItem item)
    {
        // Handle adding the item to the cart
        DisplayAlert("Added to Cart", $"{item.Name} has been added to your cart.", "OK");
    }
}