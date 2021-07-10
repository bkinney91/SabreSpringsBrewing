#!/bin/sh
# Install SSBE Brew Controller Api
echo "Cleaning API workspace"
cd BrewControllerApi
sudo rm * -r -f
echo "Clone source code"
git clone https://github.com/bkinney91/SabreSpringsBrewing.git 
cd SabreSpringsBrewing/SabreSprings.Brewing.BrewController.Api
echo "Building project"
sudo /usr/share/dotnetsdk/dotnet publish -c Production
sudo cp bin/Production/net5.0/publish/* /home/bryce/BrewControllerApi -r 
echo "Cleaning up"
cd /home/bryce
sudo rm BrewControllerApi/SabreSpringsBrewing -r -f