using System;
#if DNXCORE50 || DNX451 || DOTNET5_4
using Microsoft.Extensions.DependencyInjection;
#endif
#if DNXCORE50 || DOTNET5_4
using System.Runtime.InteropServices;
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
#if DNXCORE50 || DOTNET5_4
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
