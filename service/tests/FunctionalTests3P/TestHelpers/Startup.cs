﻿// Copyright (c) Microsoft. All rights reserved.

/* IMPORTANT: the Startup class must be at the root of the namespace and
 * the namespace must match exactly (required by Xunit.DependencyInjection) */

// ReSharper disable CheckNamespace

namespace FunctionalTests3P;

public class Startup
{
    public void ConfigureHost(IHostBuilder hostBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.development.json", optional: true)
            .AddUserSecrets<Startup>()
            .AddEnvironmentVariables()
            .Build();

        hostBuilder.ConfigureHostConfiguration(builder => builder.AddConfiguration(config));
    }
}
