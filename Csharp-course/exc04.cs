using System;

// Base class Vehicle
class Vehicle
{
    protected string name;
    protected int gasLevel;
    
    public Vehicle(string name, int initialGas = 100)
    {
        this.name = name;
        this.gasLevel = initialGas;
    }
    
    public virtual void Drive()
    {
        if (gasLevel > 0)
        {
            Console.WriteLine($"{name} goes VROOOOM!");
            gasLevel -= 10;
            Console.WriteLine($"Gas level: {gasLevel}%");
        }
        else
        {
            Console.WriteLine($"{name} is out of gas!");
        }
    }
    
    public void Refuel()
    {
        gasLevel = 100;
        Console.WriteLine($"{name} refueled to 100%");
    }
}

// Car class
class Car : Vehicle
{
    public Car(string name) : base(name)
    {
    }
    
    public void OpenWindow()
    {
        Console.WriteLine($"{name} window is now open!");
    }
    
    public void OpenRadio()
    {
        Console.WriteLine($"{name} radio is playing music 🎵");
    }
}

// eCar class - electric car
class ECar : Vehicle
{
    public ECar(string name) : base(name, 100)
    {
    }
    
    public override void Drive()
    {
        if (gasLevel > 0)
        {
            Console.WriteLine($"{name} goes ssshhhhhh!");
            gasLevel -= 10;
            Console.WriteLine($"Battery level: {gasLevel}%");
        }
        else
        {
            Console.WriteLine($"{name} battery is empty!");
        }
    }
}

// Motorcycle class
class Motorcycle : Vehicle
{
    public Motorcycle(string name) : base(name)
    {
    }
    
    public void PutHelmetOn()
    {
        Console.WriteLine($"Helmet is on! Ready to ride {name}");
    }
}

// Main program
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Vehicle Demonstration Program ===\n");
        
        // Create instances
        Car myCar = new Car("Toyota Camry");
        ECar myECar = new ECar("Tesla Model 3");
        Motorcycle myMotorcycle = new Motorcycle("Harley Davidson");
        
        // Demonstrate Car
        Console.WriteLine("--- Car Actions ---");
        myCar.Drive();
        myCar.OpenWindow();
        myCar.OpenRadio();
        Console.WriteLine();
        
        // Demonstrate eCar
        Console.WriteLine("--- Electric Car Actions ---");
        myECar.Drive();
        myECar.Drive();
        Console.WriteLine();
        
        // Demonstrate Motorcycle
        Console.WriteLine("--- Motorcycle Actions ---");
        myMotorcycle.PutHelmetOn();
        myMotorcycle.Drive();
        Console.WriteLine();
        
        // Show gas depletion
        Console.WriteLine("--- Driving until empty ---");
        for (int i = 0; i < 10; i++)
        {
            myCar.Drive();
        }
        Console.WriteLine();
        
        // Refuel
        Console.WriteLine("--- Refueling ---");
        myCar.Refuel();
        myCar.Drive();
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}