$source = @"
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class BuildHelper
{
    public static string GetMSBuildPath()
    {
        var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        var msvs = Path.Combine(programFiles, "Microsoft Visual Studio");
        var msb = Path.Combine(programFiles, "MSBuild");
        var msbuilds = GetMSBuildPaths(msvs).Concat(GetMSBuildPaths(msb)).ToArray();

        var msbuildVersionPattern = new Regex(@"(?<=MSBuild\\).+?(?=\\)");
        var msbuild = msbuilds
            .Where(p => !p.Contains("amd64"))
            .OrderByDescending(p => double.Parse(msbuildVersionPattern.Match(p).Value))
            .FirstOrDefault();

        return msbuild ?? GetMSBuildPathFromNetFW();
    }

    internal static string GetMSBuildPathFromNetFW()
    {
        var windows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        var netfw = Path.Combine(windows, @"Microsoft.NET\Framework");
        var msbuilds = GetMSBuildPaths(netfw).ToArray();

        var netfwVersionPattern = new Regex(@"(?<=v)\d+(?=\.)");
        return msbuilds
            .OrderByDescending(p => int.Parse(netfwVersionPattern.Match(p).Value))
            .FirstOrDefault();
    }

    static IEnumerable<string> GetMSBuildPaths(string dirPath)
    {
        return Directory.Exists(dirPath) ? Directory.EnumerateFiles(dirPath, "MSBuild.exe", SearchOption.AllDirectories) : Enumerable.Empty<string>();
    }
}
"@
Add-Type -TypeDefinition $source -Language CSharp


.\KTools.VersionIncrement.ps1

$msbuildPath = [BuildHelper]::GetMSBuildPath()
if (-not ($msbuildPath)) { exit 100 }

# Sets the alias of MSBuild.exe.
echo $msbuildPath
sal msbuild $msbuildPath

msbuild /p:Configuration=Release /t:Clean
msbuild /p:Configuration=Release /t:Rebuild
if ($LASTEXITCODE -ne 0) { exit 101 }

.\NuGetPackup.exe

ni nupkg -type directory -Force
move *.nupkg nupkg -Force
explorer nupkg
