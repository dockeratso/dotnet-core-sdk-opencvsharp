FROM ubuntu:18.04

RUN apt-get update

# opencv deps

RUN apt-get install -y cmake git libgtk2.0-dev pkg-config libavcodec-dev libavformat-dev libswscale-dev

RUN apt-get install -y python-dev python-numpy libtbb2 libtbb-dev libjpeg-dev libpng-dev libtiff-dev libdc1394-22-dev

RUN apt-get install -y libtesseract-dev -y libopenexr-dev

# nice to have

RUN apt-get install -y nano wget unzip curl

# Add missing certificate
RUN wget -O /usr/local/share/ca-certificates/missing_certificate.crt https://censys.io/certificates/129fb5de501e24041cd14a81075fd1cde257408d4a353e636912e38bdda2d3fb/pem/raw

RUN update-ca-certificates

# dotnet core 5.0 sdk

RUN apt-get install -y software-properties-common

RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb

RUN dpkg -i packages-microsoft-prod.deb

RUN add-apt-repository universe

RUN apt-get install -y apt-transport-https

RUN apt-get update

RUN apt-get install -y dotnet-sdk-5.0

# turbojpeg deps

RUN apt-get install -y libturbojpeg-dev
