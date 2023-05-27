run:
	dotnet run --project src/Conduit.Api.csproj
run-watch:
	dotnet watch --project src/Conduit.Api.csproj run
clean-build:
	dotnet clean && dotnet build