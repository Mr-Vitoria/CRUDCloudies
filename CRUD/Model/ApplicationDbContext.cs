﻿using CRUD.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Model
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<MoneyOperation> MoneyOperations { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Company> Companies { get; set; }

        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            // инициализируем саму строку подключения
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
