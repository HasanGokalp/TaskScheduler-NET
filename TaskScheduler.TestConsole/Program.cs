using TaskScheduler.Concretes.Concretes;

class Program
{
    public static void Main(string[] args)
    {
        var timeSheduler =  new TimeScheduler<dynamic>(TimeSpan.FromHours(2), () => { Console.WriteLine("Done!"); });
        timeSheduler.Start();

        Console.WriteLine("Do not press any key to exit...");
        Console.ReadKey();
    }
}