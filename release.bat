@echo off
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\msbuild.exe" "src/Skybrud.Social.Google.Geocoding" /t:rebuild /t:pack /p:BuildTools=1 /p:Configuration=Release /p:PackageOutputPath=../../releases/nuget