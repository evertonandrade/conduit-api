run:
	dotnet run --project src/Conduit.Api.csproj
watch-run:
	dotnet watch --project src/Conduit.Api.csproj run
clean-build:
	dotnet clean && dotnet build