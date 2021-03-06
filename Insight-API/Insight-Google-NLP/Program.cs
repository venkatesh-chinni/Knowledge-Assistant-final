﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restful.Models;
using ContentData;
using Microsoft.Extensions.DependencyInjection;



namespace google_nlp
{
        
    public class Program
    {   
       
        public static void Main(string[] args)
        {
        var host = BuildWebHost(args);

        using (var scope = host.Services.CreateScope())
        {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ContentContext>();
            DataSeed objseed=new DataSeed();
            objseed.Initialize(context).Wait();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
        }   

        host.Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()
               .UseUrls("http://localhost:5006/")
               .Build();
    }
}
