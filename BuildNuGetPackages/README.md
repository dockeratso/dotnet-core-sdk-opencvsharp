Nuget package to be uploaded to NuGet org. 


Creation of Raspberry package:

Open command prompt in folder .\BuildImageRaspbian  and build docker image:

- docker build --tag raspberry_build .

Create a container and copy the file libOpenCvSharpExtern.so to host the corresponding folder in NuGet package folder structure,
i.e.  to BuildNuGetPackages\BuildNuGetRaspbian\native\linux-arm\native

Go to BuildNuGetPackages\BuildNuGetRaspbian and create nuget package using
- nuget pack

Same procedure is used to create Debian NuGet package.