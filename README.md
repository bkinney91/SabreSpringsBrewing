# SabreSpringsBrewing
<p>
This application suite is for automating my home brewery. It includes a .NET 5.0 middle tier, SQL Express backend, a Vue Typescript front end with SignalR, and python with Modbus RS485. The application is hosted using kestrel, Apache2, and systemd. The infrasturcture includes 2 Raspberry pi's, one for the TapController and one for the BrewController, as well as an Odroid N2 that hosts the main node.
</p>
<h3>Brew Controller</h3>
<p>    
    My brewing setup has 3 devices to control or monitor including a <a href="https://www.blichmannengineering.com/boilermaker-g2.html">Blichmann G2 electic kettle </a> with 5500W heating element, a <a href="https://www.chapmanequipment.com/products/10-gallon-thermobarrel">Chappmann thermobarrel</a> (mash tun), and 
    2 <a href="https://www.blichmannengineering.com/riptide-brewing-pump.html">Blichmann Riptide </a> pumps. In order to do a full re-circulation brew I would need my software to manage the heating element and 2 pumps along with monitoring my mash tun's temperature. The GUI for these features is built using SignalR so that the GUI can update in realtime.
    <ul>
        <li> 
            Kettle Control - A GUI to control an <a href="https://www.auberins.com/index.php?main_page=product_info&products_id=651">Auber SYL2831 PID</a> wired to an SSR, the interface allows for viewing current temperature of the kettle as well setting the target temperature on the PID. The GUI will also update if the buttons on the PID itself are utilized. To communicate with the PID the raspberry pi is has been wired to it via a USB to Modbus RS485 adapter, with the actual controlling functions written in using MinimalModbus and python.
        </li>
        <li>
            Mash Tun monitoring - A Pt100 RTD sensor has been installed into the mash tun in order to have the GUI display the temperature. This was wired up using a <a href="https://sequentmicrosystems.com/product/rtd-data-acquisition-card-for-rpi/" >SequentMicrosystems Mega-RTD Raspberry pi hat</a>.
        </li>
        <li>
            Pump Control - Using a <a href="https://www.electronics-salon.com/products/electronics-salon-rpi-power-relay-board-expansion-module-for-raspberry-pi-a-b-2b-3b">Rapsberry pi Relay hat</a> and some panel mounted NEMA connectors the application is able to control both pumps via toggle switches on the GUI.
        </li>
    </ul>
</p>
![Control Box wiring]
(https://i.imgur.com/kw4wAD4.jpg)
![PID screen and a display screen for measuring amps]
(https://i.imgur.com/GmCVmwS.jpg)
![Screenshot of the GUI to control the box]
(https://i.imgur.com/jQalSbG.png)
![GUI and the box](https://i.imgur.com/0XiLflq.jpg)

<h3>Fermenting</h3>
<p>
    <ul>
    <li>
        Tap line flowmeters - This idea was based on the <a href="https://learn.adafruit.com/adafruit-keg-bot/overview" >Adafruit Kegomatic</a>, but instead of using a python
        GUI I decided to have my script send an HTTP request to the Web Api portion of this application. Check out the <a href="/Taproom/OnTap">On Tap</a> page to see a how much
        beer is left in each keg.       
    </li>
    <li>
        Fermentation Monitoring - API endpoints for gathering temperature and gravity of a currently fermenting beer, including history and graphs. To gather this data I used
        following the hardware guide provided by <a href="https://www.opensourcedistilling.com/ispindel-assembly/">Open Source Distilling</a>
        along with the open source <a href="http://www.ispindel.de/">iSpindel</a> software.
    </li>
</ul>

<h3>Serving</h3>
<p>
    <ul>
        <li>
            Tap line flowmeters - This idea was based on the <a href="https://learn.adafruit.com/adafruit-keg-bot/overview" >Adafruit Kegomatic</a>, but instead of using a python
            GUI I decided to have my script send an HTTP request to the Web Api portion of this application. Check out the <a href="/Taproom/OnTap">On Tap</a> page to see a how much
            beer is left in each keg.       
        </li>
    </ul>
</p>
<h3>Planning</h3>
<p>
    <ul>
        <li>
            Beer and batch management - A GUI to add, edit and view beer batches for record keeping.     
        </li>
        <li>
            PLANNED - Inventory Management - A way to track current inventory as well as relating it to a recipe.
        </li>
    </ul>
</p>
