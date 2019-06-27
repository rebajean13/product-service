FROM microsoft/dotnet:2.2-sdk
COPY . /app
WORKDIR /app/ProductService
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp