# How to configure Entity Framework Core with SQLite

- Add package for sqlite

  ```
  dotnet add package Microsoft.EntityFrameworkCore.Sqlite
  ```

- Add connection string to `appsettings.json`

  ```
  "ConnectionStrings": {
      "DefaultConnection": "Data Source=VocabularyBuilder.db"
  }
  ```

- Add database context class `VocabularyBuilder.cs`

  ```
  class VocabularyBuilderDbContext : DbContext
  {
      public VocabularyBuilderDbContext(DbContextOptions<VocabularyBuilderDbContext> options)
          : base(options)
      {
      }

      public DbSet<Item> Items { get; set; }
  }
  ```

- Add DbContext to Startup services `Startup.cs`

  ```
  services.AddDbContext<VocabularyBuilderDbContext>(options =>
      options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
  ```

- Create database
  ```
  dotnet tool install --global dotnet-ef
  dotnet add package Microsoft.EntityFrameworkCore.Design
  dotnet ef migrations add InitialModel
  dotnet ef database update
  ```
