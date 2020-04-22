FROM raspbian/stretch AS build-native-env


RUN apt update && apt install -y \
    apt-transport-https \
    software-properties-common \
    wget \
    unzip \
    curl \
    ca-certificates
    #bzip2 \
    #grep sed dpkg 

# Install opencv dependencies
RUN cd ~
RUN apt update && apt install -y \
    build-essential \
    cmake \
    git \
    gfortran \
    #libjpeg62-turbo-dev \
    libjpeg8-dev \
    libpng-dev \
    software-properties-common
# RUN add-apt-repository "deb http://security.ubuntu.com/ubuntu xenial-security main" && 
RUN apt update && apt install -y \
    libjasper1 \
    libtiff-dev \
    libavcodec-dev \
    libavformat-dev \
    libswscale-dev \
    libdc1394-22-dev \
    libxine2-dev \
    libv4l-dev

RUN cd /usr/include/linux
RUN ln -s -f ../libv4l1-videodev.h videodev.h
RUN cd ~
RUN apt install -y \
    libgstreamer1.0-dev \
    libgstreamer-plugins-base1.0-dev \
    libgtk2.0-dev libtbb-dev qt5-default \
    libatlas-base-dev \
    #libfaac-dev \
    libmp3lame-dev \
    libtheora-dev \
    libvorbis-dev \
    libxvidcore-dev \
    libopencore-amrnb-dev \
    libopencore-amrwb-dev \
    libavresample-dev \
    x264 \
    v4l-utils

ENV OPENCV_VERSION=4.3.0

# Setup OpenCV source
RUN wget https://github.com/opencv/opencv/archive/${OPENCV_VERSION}.zip && \
    unzip ${OPENCV_VERSION}.zip && \
    rm ${OPENCV_VERSION}.zip && \
    mv opencv-${OPENCV_VERSION} opencv

# Setup opencv-contrib Source
RUN wget https://github.com/opencv/opencv_contrib/archive/${OPENCV_VERSION}.zip && \
    unzip ${OPENCV_VERSION}.zip && \
    rm ${OPENCV_VERSION}.zip && \
    mv opencv_contrib-${OPENCV_VERSION} opencv_contrib

# Build OpenCV
RUN cd opencv && mkdir build && cd build && \
    cmake \
    -D OPENCV_EXTRA_MODULES_PATH=/opencv_contrib/modules \
    -D CMAKE_BUILD_TYPE=RELEASE \
    -D BUILD_EXAMPLES=OFF \
    -D BUILD_DOCS=OFF \
    -D BUILD_PERF_TESTS=OFF \
    -D BUILD_TESTS=OFF \
    -D BUILD_opencv_java=OFF \
    -D BUILD_opencv_python=OFF \
    .. && make -j4 && make install && ldconfig

WORKDIR /

# OPENCVSHARP version
ENV OPENCVSHARP_VERSION=4.3.0.20200405

# Download OpenCvSharp
RUN git clone https://github.com/shimat/opencvsharp.git
RUN cd opencvsharp && git fetch --all --tags --prune && git checkout ${OPENCVSHARP_VERSION}

# Install the Extern lib.
WORKDIR /opencvsharp/src
RUN mkdir /opencvsharp/make
RUN cd /opencvsharp/make && cmake -D CMAKE_INSTALL_PREFIX=/opencvsharp/make /opencvsharp/src && make -j4 && make install
RUN ls /opencvsharp/make

# /opencvsharp/make/OpenCvSharpExtern/libOpenCvSharpExtern.so 

RUN apt-get install -y software-properties-common

RUN apt-get install -y apt-transport-https

RUN apt-get update

RUN apt-get install -y libturbojpeg-dev



ADD https://download.visualstudio.microsoft.com/download/pr/ccbcbf70-9911-40b1-a8cf-e018a13e720e/03c0621c6510f9c6f4cca6951f2cc1a4/dotnet-sdk-3.1.201-linux-arm.tar.gz dotnet-sdk-3.1.201-linux-arm.tar.gz

RUN ls -la

ENV HOME=/tools
RUN mkdir -p $HOME/dotnet && tar zxf dotnet-sdk-3.1.201-linux-arm.tar.gz -C $HOME/dotnet
ENV DOTNET_ROOT=$HOME/dotnet
ENV PATH=$PATH:$HOME/dotnet

WORKDIR /

RUN ls 

RUN echo $PATH
RUN echo $DOTNET_ROOT

#RUN dotnet --help

RUN apt-get install -y libtesseract-dev
