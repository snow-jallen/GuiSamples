﻿using FluentMigrator.Runner;
using GuiSamples.Data;
using GuiSamples.Data.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MigrationRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 2 && args[0] == "--secret" && args[1].StartsWith("server="))
            {
                SecretKeeper.SaveConnectionString(args[1]);
            }

            if (!SecretKeeper.SecretExists())
                throw new Exception("Unable to proceed without secret.txt");

            var serviceProvider = CreateServices();

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(SecretKeeper.GetConnectionString())
                    .ScanIn(typeof(Migration001_AddLogTable).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
