#!/bin/sh
# Install SSBE Brew Controller Client

cd BrewControllerClient
sudo rm * -r -f
echo "Clone source code"
git clone https://github.com/bkinney91/SabreSpringsBrewing.git 
cd SabreSpringsBrewing/SabreSprings.Brewing.BrewController.Client
echo "NPM Install"
npm install
echo "Building project"
npm run build
sudo cp dist /var/www/html -r 
echo "Cleaning up"
cd /home/bryce
#sudo rm BrewControllerClient/SabreSpringsBrewing -r -f