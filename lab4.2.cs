using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Компонент
interface IOrderComponent
{
    double GetWeight();
    double GetTotalPrice();
}

// Інформація
class Item : IOrderComponent
{
    public string Name { get; }
    public double Weight { get; }
    public double Price { get; }

    public Item(string name, double weight, double price)
    {
        Name = name;
        Weight = weight;
        Price = price;
    }

    public double GetWeight()
    {
        return Weight;
    }

    public double GetTotalPrice()
    {
        return Price;
    }
}

// Умови
class Order : IOrderComponent
{
    private List<IOrderComponent> items;

    public Order()
    {
        items = new List<IOrderComponent>();
    }

    public void AddItem(IOrderComponent item)
    {
        if (GetWeight() + item.GetWeight() > 20 || GetTotalPrice() + item.GetTotalPrice() > 10000)
        {
            Console.WriteLine("Cannot add item. Weight or total price limit exceeded.");
            return;
        }

        items.Add(item);
    }

    public void RemoveItem(IOrderComponent item)
    {
        items.Remove(item);
    }

    public double GetWeight()
    {
        double totalWeight = 0;

        foreach (var item in items)
        {
            totalWeight += item.GetWeight();
        }

        return totalWeight;
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;

        foreach (var item in items)
        {
            totalPrice += item.GetTotalPrice();
        }

        return totalPrice;
    }
}

// Використання
class Program
{
    static void Main(string[] args)
    {
        Order order = new Order();
        order.AddItem(new Item("Product 1", 5, 1000));
        order.AddItem(new Item("Product 2", 7, 1500));

        Console.WriteLine("Order Weight: " + order.GetWeight() + " kg");
        Console.WriteLine("Order Total Price: " + order.GetTotalPrice() + " UAH");
    }
}
