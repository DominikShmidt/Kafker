# Stage 1: Build the Angular frontend
FROM node:lts-alpine AS angular-build
WORKDIR /app/kafker-client
COPY kafker-client/package.json kafker-client/package-lock.json ./
RUN npm install --ignore-scripts
COPY kafker-client/ .
RUN npm run build

# Stage 2: Build the .NET Core backend
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS dotnet-build
WORKDIR /app/api
COPY Kafker.API/*.csproj ./
RUN dotnet restore
COPY Kafker.API/ .
RUN dotnet build -c Release -o /app/build

# Stage 3: Publish the .NET Core application
FROM dotnet-build AS publish
WORKDIR /app/api
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Final image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app/api

# Copy published backend and built frontend
COPY --from=publish /app/publish .
COPY --from=angular-build /app/kafker-client/dist/kafker-client/browser ./wwwroot

# Create non-root user
RUN addgroup --system kafker && adduser --system --ingroup kafker kafker

# Give ownership of app files
RUN chown -R kafker:kafker /app/api

# Switch to non-root user
USER kafker

ENV USE_STATIC_FILES=true

EXPOSE 8080
ENTRYPOINT ["dotnet", "Kafker.API.dll"]