namespace AtmOperationsWithDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            using (var context = new AtmDbContext())
            {
                context.SeedDatabase();
            }

            Menu menu = new Menu();
            Atm atm = new Atm(menu);
            atm.Run();
        }
    }
    
}
