#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

# LAYER 1 - FROM gets an image form DockerHub to serve as the base image fo the final image.
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
# sets the woking directory for this layer. 
WORKDIR /app
# assign the port numebrs for the container.. conventionally 80 is for HTTP and 443 is for HTTPS.
EXPOSE 80
EXPOSE 443


#LAYER 2 - grab another image from DockerHub
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
# set the work directory for this layer
WORKDIR /src
# COPY will copy these files from the cwd to inside the container.
COPY ["06012021BatchDockerDemo.csproj", "."]
#RUN will input bash commands
RUN dotnet restore "./06012021BatchDockerDemo.csproj"
#COPY everything else from cwd into the containers working directory
COPY . .
# switch working directory to inside src.
WORKDIR "/src/."
# run the build command.
RUN dotnet build "06012021BatchDockerDemo.csproj" -c Release -o /app/build


#LAYER 3 
#use the previous layer and name this layer publish.
FROM build AS publish
# publish and save the .exe/.dll into publish dir.
RUN dotnet publish "06012021BatchDockerDemo.csproj" -c Release -o /app/publish


#LAYER 4
#use base layer as foundation
FROM base AS final
#move to a different working directory
WORKDIR /app
#copy layer from publish in to the working directory
COPY --from=publish /app/publish .
#exec form of setting the command and file to send as an arg when starting the app.
ENTRYPOINT ["dotnet", "06012021BatchDockerDemo.dll"]