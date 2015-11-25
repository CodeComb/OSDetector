using System;
#if DOTNET5_5
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
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
#if DOTNET5_5
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return OSType.Windows;
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
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
