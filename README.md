# dotnet-core-sdk-dependencies
Dockerfiles used for creating latest stable dotnet core sdk images together with latest stable OpenCvSharp 
and its dependencies on several platforms. These images make it possible to compile and run OpenCvSharp dependent 
applications in the docker enviroment. Samples added.

Build locally images as follows
docker build -t opencv_dotnet .

Mount your OpenCvSharp dependent project and run commands using the interactive shell:

docker run -it -v %cd%:/test/ --workdir /test opencv_dotnet:latest






