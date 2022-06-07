#!/bin/sh
# Install SSBE Client
#!/bin/sh
# Install SSBE Brew Controller Client
sudo rm /home/bryce/SabreSpringsBrewing/ClientStaging/ -r -f
cd /home/bryce/SabreSpringsBrewing/ClientStaging
echo "Clone source code"
git clone https://github.com/bkinney91/SabreSpringsBrewing.git 
cd SabreSpringsBrewing/SabreSprings.Brewing.Client
echo "NPM Install"
sudo npm install
echo "Building project"
sudo npm run build
sudo cp dist/* /var/www/ssbe -r 