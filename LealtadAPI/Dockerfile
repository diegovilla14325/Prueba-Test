# Base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set work directory
WORKDIR /app

# Copy project files
COPY . .

# Compile and publish the project
RUN dotnet publish -c Release -r linux-x64 --self-contained true -o /app/out

# Base image for application
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set work directory
WORKDIR /app

# Copy published files from previus image
COPY --from=build /app/out ./

## Expose ports
EXPOSE 80

# RUN PROJECT
CMD dotnet LealtadAPI.dll
