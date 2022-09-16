namespace CanWeFixItService
{
    public static class MyDbContextSeeder
    {

        public static void Seed(MyDbContext context)
        {
            SeedingData(context);
        }

        public static void SeedingData(MyDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.MarketData.Add(new MarketData
            {
                Id = 1,
                Sedol = "Sedol1",
                DataValue = 1111,
                Active = false
            });

            context.MarketData.Add(new MarketData
            {
                Id = 2,
                Sedol = "Sedol2",
                DataValue = 2222,
                Active = true
            });

            context.MarketData.Add(new MarketData
            {
                Id = 3,
                Sedol = "Sedol3",
                DataValue = 3333,
                Active = false
            });

            context.MarketData.Add(new MarketData
            {
                Id = 4,
                Sedol = "Sedol4",
                DataValue = 4444,
                Active = true
            });

            context.MarketData.Add(new MarketData
            {
                Id = 5,
                Sedol = "Sedol5",
                DataValue = 5555,
                Active = false
            });

            context.MarketData.Add(new MarketData
            {
                Id = 6,
                Sedol = "Sedol6",
                DataValue = 6666,
                Active = true
            });

            context.Instrument.Add(new Instrument()
            {
                Id = 1,
                Sedol = "Sedol1",
                Name = "Name1",
                Active = false
            });

            context.Instrument.Add(new Instrument()
            {
                Id = 2,
                Sedol = "Sedol2",
                Name = "Name2",
                Active = true
            });

            context.Instrument.Add(new Instrument()
            {
                Id = 3,
                Sedol = "Sedol3",
                Name = "Name3",
                Active = false
            });

            context.Instrument.Add(new Instrument()
            {
                Id = 4,
                Sedol = "Sedol4",
                Name = "Name4",
                Active = true
            });

            context.Instrument.Add(new Instrument()
            {
                Id = 5,
                Sedol = "Sedol5",
                Name = "Name5",
                Active = false
            });

            context.Instrument.Add(new Instrument()
            {
                Id = 6,
                Sedol = "",
                Name = "Name6",
                Active = true
            });

            context.Instrument.Add(new Instrument()
            {
                Id = 7,
                Sedol = "Sedol7",
                Name = "Name7",
                Active = false
            });

            context.Instrument.Add(new Instrument()
            {
                Id = 8,
                Sedol = "Sedol8",
                Name = "Name8",
                Active = true
            });

            context.Instrument.Add(new Instrument()
            {
                Id = 9,
                Sedol = "Sedol9",
                Name = "Name9",
                Active = false
            });

            context.SaveChanges();
        }
    }
}
