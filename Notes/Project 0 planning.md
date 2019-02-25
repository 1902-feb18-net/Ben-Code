## Library Project
```csharp


public abstract class Games
{
    Games()
    {

    }

    protected virtual string Name {get; set;} //Name of game
    protected virtual double Cost {get; set;} //Base cost of game
    protected virtual double AdvancedCost {get; set;} //Advanced cost of game
    protected virtual double DeluxeCost {get; set;} //Delux cost of game

}

public class IsekaiQuest : Games
{
    //Contains fields declared in Games
}

public class ShonenAdventure : Games
{
    //Contains fields declared in Games
}

public class Store
{
    private string Location {get; set;} //the location of store???
    public double Distance {get; set;} //player enters distance in miles to help calc shipping costs
    private double ShippingCosts {get; set;} //distance is multiplied by some num for costs
    private int IDNumber {get; set;} //ID numbers start at 1 and increment for every order
    public Date OrderDate {get; set;} //Player inputs date, can be used to help find Orders
    public string Customer {get; set;} //Player inputs customers name, can be used to find Orders

    public bool LastBoughtGame {get; set;} //true indicates last bought game was Isekai, false indicates Shonen

    public double TotalCost {get;} //the total cost of all items bought by customer

    public double GetGameCost(Game game, string edition)
    {
        //depending on game edition, return the correct price
    }

    public Order OrderItem(string item, GetGameCost(gameToBuy, ed), int quantity, double shippingCost)
    {
        //reference to Order class
        //add Order to OrderRepository

        //return new Order(item, IDNumber, OrderDate, Customer, GetGameCost, quantity, shippingCost)

        //While multiple of the same game can be ordered, they must be theh same game and the same types, no "1 standard and 1 advanced" or "1 shonen standard and 1 isekai standard"
    }

    public bool RecommendedGame()
    {
        //if the last bought game was Isekai, return false (Shonen)
        //if the last bought game was Shonen, return true (Isekai)
        //will bring up advanced edition as default
    }

}

public class Inventory
{
    private int IsekaiInStock {get; set;} //A hidden number that limits Isekai orders
    private int ShonenAdventureInStock {get; set;} //A hidden number that limits Shonen orders

    private int DeluxeInStock {get; set;} //A hidden number that limits Delux orders

    public void RemoveFromStock(int number, string item, bool delux)
    {
        //Runs when order is formed, includes item and possible delux objects
        //Checks if delux is true, if so, remove from DeluxInStock as well
        //If anything being removed doesn't have any more stock available, throw error message
    }

    public void AddToStock(int number, string item, bool delux)
    {
        //Runs when order is cancelled or stock is refilled
    }

    public void RestockAll()
    {
        //Sets all stocks back to full
    }
}

public class Order
{
    Orders(string item, int ID, Date Dt, string Customer, double GameCost, int Quantity, double ShipCosts)
    {
        OrderGame = item;
        OrderID = ID;
        OrderDate = Dt;
        OrderCustomer = Customer;
        OrderCost = GameCost;
        OrderQuantity = Quantity;
        ShippingCost = ShipCosts;
        Valid = true;
    }

    private string OrderGame {get;} //Game name
    private int OrderID {get;} //Item ID
    private string OrderDate {get;} //Date ordered
    private string OrderCustomer {get;} //Customer name
    private double OrderCost {get; set;} //How expensive the game was, excluding shipping
    private int OrderQuantity {get;} //How many items were ordered
    private double ShippingCost {get; set;} //How much shipping cost total

    public bool Valid;

    private double TotalOrderCost()
    {
        //OrderCost = OrderQuantity * OrderCost + ShippingCost
    }

    public void DisplayData()
    {
        //displays order ID, Date, Game Name, Customer, cost, and whether its still active
    }

}

public class OrdersRepository
{

    private readonly ICollection<Order> _Data;

    public Order GetOrderByID(int ID)
    {
        //goes through _Data to find order with specified ID
        //returns null if ID doesn't exist
    }

    public List<Order> GetOrderByDate(string Date)
    {
        //goes through _Data to find order(s) at specified Date
        //returns all Orders at that date, organized by ID
        //returns null if Date doesn't exist
    }

    public List<Order> GetOrderByCustomer(string Customer)
    {
        //goes through _Data to find order(s) by specified Customer
        //returns all Orders by that Customer, organized by ID
        //returns null if customer doesn't exist
    }

    public List<Order> RemoveOrder(Order order)
    {
        //Removes the relevant order from the order list
        //Order toDeactivate = order;
        //toDeactive.Valid = false;
    }

    public List<Order> AddOrder(Order order)
    {
        //_Data.Add(order);
    }
}

public class StoreRepository
{
    private readonly ICollection<Store> _Data;

    public Store GetStoreByLocation(string location)
    {
        //goes through _Data looking for the specified location
        //returns the store at the specified location
    }
}

public class Date
{
    public int Day{get; set;}
    public int Month{get; set;}

    //overload the "==" operator so first month is compared, then day
}

```
## Console Project

```csharp

//Customer starts at basic menu
//They pick a store out of a small list
//They can check try to view and/or edit an existing order, or they can make a new order, or view all previous orders (at that store)
//When they make a new order, they need to input their name and the date
//Then they need to pick which game to buy, then which edition to buy
//Then they need to pick how many copies they plan on buying
//Then the total cost is revealed and they can confirm the purchase
//Players who choose to view and/or edit an existing order can search for it by ID, Date, or their name
//If found by ID, the exact right Order is there and they can choose to cancel it
//If found by another method, more than one right Order may appear, in which case they must choose which Order is correct by ID, then they may cancel it
//If they view all previous orders, they can choose for them to be sorted by most recent (which defaults to ID) or by cost (starting at most expensive)
//Possibly use a separate Date class that overloads the "==" operator

```
## Testing project