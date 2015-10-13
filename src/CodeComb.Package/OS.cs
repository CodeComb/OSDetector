using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
#if DNXCORE50 || DNX451
using Microsoft.Framework.DependencyInjection;
using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
#endif

namespace CodeComb.Package
{
    public enum OSType
    {
        Windows,
        OSX,
        Linux
    }

    public static class OS
    {
        public static OSType Current
        {
            get
            {
#if DNXCORE50
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return OSType.Windows;
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return OSType.OSX;
                else
                    return OSType.Linux;
#elif DNX451
                var services = CallContextServiceLocator.Locator.ServiceProvider;
                var env = services.GetService<IRuntimeEnvironment>();
                if (env.OperatingSystem == "Windows")
                    return OSType.Windows;
                else if (env.OperatingSystem == "Darwin")
                    return OSType.OSX;
                else
                    return OSType.Linux;
#else
                if (Environment.OSVersion.Platform == PlatformID.Win32NT || Environment.OSVersion.Platform == PlatformID.Win32S || Environment.OSVersion.Platform == PlatformID.Win32Windows || Environment.OSVersion.Platform == PlatformID.WinCE)
                    return OSType.Windows;
                else if (Environment.OSVersion.Platform == PlatformID.MacOSX)
                    return OSType.OSX;
                else
                    return OSType.Linux;
#endif
            }
        }
    }
}
