#!/bin/bash

#-----------------------Install .NET Core 2.2-----------------------
echo Updating system first...
sudo apt-get update
echo Installing libunwind8
echo y | sudo apt-get install curl libunwind8 gettext apt-transport-https
echo Downloading dotnet runtime 2.2.1
wget https://download.visualstudio.microsoft.com/download/pr/e9d4b012-a877-443c-8344-72ef910c86dd/b5e729b532d7b3b5488c97764bd0fb8e/aspnetcore-runtime-3.0.0-linux-arm.tar.gz
echo Creating directory and extracting to /usr/local/dotnet
sudo mkdir -p /usr/local/dotnet && tar zxf aspnetcore-runtime-3.0.0-linux-arm.tar.gz -C /usr/local/dotnet
echo Adding /usr/local/dotnet to PATH
export DOTNET_ROOT=$/usr/local/dotnet 
export PATH=$PATH:/usr/local/dotnet
echo Adding symbolic link at /usr/local/bin
sudo ln -s /usr/local/dotnet/dotnet /usr/local/bin