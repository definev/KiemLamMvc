docker pull mcr.microsoft.com/azure-sql-edge
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<YourStrong!Passw0rd>' -p 1433:1433 -d mcr.microsoft.com/azure-sql-edge
