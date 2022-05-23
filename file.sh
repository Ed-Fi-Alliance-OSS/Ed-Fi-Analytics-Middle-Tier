echo "CONNECTION:" "$@"
cd "/Ed-Fi/AMT/"
dotnet EdFi.AnalyticsMiddleTier.Console.dll "$@"