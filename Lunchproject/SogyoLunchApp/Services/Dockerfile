FROM microsoft/dotnet:2.2-sdk

WORKDIR /app/src

# Cache the dependencies
COPY Domain/Domain.csproj Domain/
COPY Repository/Repository.csproj Repository/
COPY Services/Services.csproj Services/
RUN dotnet restore Services/Services.csproj

# Then copy the rest of the sources
COPY . .
WORKDIR /app/src

# Build the project
RUN dotnet publish Services/Services.csproj -c Release -o /app/build

FROM microsoft/dotnet:2.2-aspnetcore-runtime
# Add a user to the container
RUN groupadd lanthir && useradd -d /app -g lanthir lanthir
USER lanthir
# Copy the artifacts from the build container
WORKDIR /app
COPY --from=0 --chown=lanthir:lanthir /app/build/ .
EXPOSE 80 443
ENTRYPOINT ["dotnet", "Services.dll"]