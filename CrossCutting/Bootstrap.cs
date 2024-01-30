using System;

namespace CrossCutting
{
    public static class Bootstrap
    {
        public static IServiceProvider Services => ServiceCollectionExtensions.GetServiceProvider();
    }
}
