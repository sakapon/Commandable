# $msbuild = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
$msbuild = "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"

.\KTools.VersionIncrement.ps1

& $msbuild /p:Configuration=Release /t:Clean
& $msbuild /p:Configuration=Release /t:Rebuild

.\NuGetPackup.exe

ni nupkg -type directory -Force
move *.nupkg nupkg -Force
explorer nupkg
