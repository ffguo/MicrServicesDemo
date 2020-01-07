@echo off
start consul.exe agent -dev



cd Src\ServicesA\bin\Debug\netcoreapp3.1
start dotnet ServicesA.dll --urls=http://localhost:7000
start dotnet ServicesA.dll --urls=http://localhost:7001