﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AKMDotNetCoreConsoleApp.Models;
using Microsoft.Data.SqlClient;

namespace AKMDotNetCoreConsoleApp.EFCoreExamples
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = ".", // server name
                    InitialCatalog = "AKMDotNetCore",
                    UserID = "sa",
                    Password = "sa@123",
                    TrustServerCertificate = true,
                };
                optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
            }
        }
        public DbSet<BlogDataModel> Blogs { get; set; }
    }
}
