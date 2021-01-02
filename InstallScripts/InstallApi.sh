#!/bin/sh
# Install SSBE Api
#!/bin/sh
# Install SSBE Brew Controller Api
echo "Cleaning API workspace"
sudo rm SabreSpringsBrewing/Api/* -r -f
cd SabreSpringsBrewing/Api
echo "Clone source code"
git clone https://github.com/bkinney91/SabreSpringsBrewing.git 
cd SabreSpringsBrewing/SabreSprings.Brewing.Api
echo "Building project"
sudo /usr/share/dotnetsdk/dotnet publish -c Production
cp bin/Production/net5.0/publish/* /home/bryce/SabreSpringsBrewing/Api/ -r 
echo "Cleaning up"
cd /home/bryce
sudo rm SabreSpringsBrewing/Api/SabreSpringsBrewing -r -f