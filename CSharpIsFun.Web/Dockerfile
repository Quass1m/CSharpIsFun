FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 59229
EXPOSE 44330

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY CSharpIsFun.Web/CSharpIsFun.Web.csproj CSharpIsFun.Web/
RUN dotnet restore CSharpIsFun.Web/CSharpIsFun.Web.csproj
COPY . .
WORKDIR /src/CSharpIsFun.Web
RUN dotnet build CSharpIsFun.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CSharpIsFun.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CSharpIsFun.Web.dll"]
