@echo off
cd Src\IdentityServers\bin\Debug\netcoreapp3.1
start dotnet IdentityServers.dll --urls=http://localhost:6100
cd ../../../../../

cd Tools\HttpReports
start dotnet HttpReportsWeb.dll --urls=http://localhost:6200
cd ../../

cd Src\ServicesA\bin\Debug\netcoreapp3.1
start dotnet ServicesA.dll --urls=http://localhost:7000
start dotnet ServicesA.dll --urls=http://localhost:7001