using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestInference.Utils;

namespace TestInference.Services
{
    public static class Services
    {
        private static IServiceProvider _serviceProvider;

        public static void Setup()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<ICodesConverter, CodesConverter>()
                .AddSingleton<IDesignationsProvider, DesignationsFromGoogleProvider>()
                .BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
