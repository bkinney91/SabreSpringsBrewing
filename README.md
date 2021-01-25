# SabreSpringsBrewing
<p>
This application suite is for automating my home brewery. It includes a .NET 5.0 middle tier, SQLite backend, a Vue Typescript front end with SignalR, and python with Modbus RS485. The application is hosted using kestrel, Apache2, and systemd. The infrasturcture includes 2 Raspberry pi's, one for the TapController and one for the BrewController, as well as an Odroid N2 that hosts the main node.
</p>
<h3>Brew Controller</h3>
<p>    
    My brewing setup has 3 devices to control or monitor including a <a href="https://www.blichmannengineering.com/boilermaker-g2.html">Blichmann G2 electic kettle </a> with 5500W heating element, a <a href="https://www.chapmanequipment.com/products/10-gallon-thermobarrel">Chappmann thermobarrel</a> (mash tun), and 
    2 <a href="https://www.blichmannengineering.com/riptide-brewing-pump.html">Blichmann Riptide </a> pumps. In order to do a full re-circulation brew I would need my software to manage the heating element and 2 pumps along with monitoring my mash tun's temperature. The GUI for these features is built using SignalR so that the GUI can update in realtime.
    <ul>
        <li> 
            Kettle Control - A GUI to control an <a href="https://www.auberins.com/index.php?main_page=product_info&products_id=651">Auber SYL2831 PID</a> wired to an SSR, the interface allows for viewing current temperature of the kettle as well as setting the target temperature on the PID. The GUI will also update if the buttons on the PID itself are utilized. To communicate with the PID the raspberry pi is wired via a USB to Modbus RS485 adapter, with the actual controlling functions written using MinimalModbus and python.
        </li>
        <li>
            Mash Tun monitoring - A Pt100 RTD sensor has been installed into the mash tun in order to have the GUI display the temperature. This was wired up using a <a href="https://sequentmicrosystems.com/product/rtd-data-acquisition-card-for-rpi/" >SequentMicrosystems Mega-RTD Raspberry pi hat</a>.
        </li>
        <li>
            Pump Control - Using a <a href="https://www.electronics-salon.com/products/electronics-salon-rpi-power-relay-board-expansion-module-for-raspberry-pi-a-b-2b-3b">Rapsberry pi Relay hat</a> and some panel mounted NEMA connectors the application is able to control both pumps via toggle switches on the GUI.
        </li>
    </ul>
</p>
<img src="https://i.imgur.com/kw4wAD4.jpg" alt="Control box wiring"></img>
<img src="https://i.imgur.com/GmCVmwS.jpg" height="600px" alt="PID screen and a multimeter screen"></img>
<img src="https://i.imgur.com/jQalSbG.png" alt="Screenshot of the Vue Typescript/SignalR GUI to control the box"></img>
<img src="https://i.imgur.com/FnAiur6.jpg" alt="Mash tun on the left and the kettle on the right">

<h3>Fermenting</h3>
<p>
    <ul>    
        <li>
            Fermentation Monitoring - API endpoints for gathering temperature and gravity of a currently fermenting beer, including history and graphs. The data is collected by devices (I call them fermentabuoys) I soldered up using a video provided by <a href="https://www.opensourcedistilling.com/ispindel-assembly/">Open Source Distilling</a> with the software being provided by <a href="http://www.ispindel.de/">iSpindel</a>.
        </li>
    </ul>
<img src="https://i.imgur.com/cSpBOxY.jpg" alt="Fermentabuoys">
<h3>Serving</h3>
<p>
    <ul>
        <li>
            Tap line flowmeters - This idea was based on the <a href="https://learn.adafruit.com/adafruit-keg-bot/overview" >Adafruit Kegomatic</a>, but instead of using a python
            GUI I decided to have my script send an HTTP request to an API endpoint on my main node. From there the server would use SignalR to send a message to any client that had the "On Tap" page open with the amount that was poured from the tap.
        </li>
    </ul>
</p>
<img src="https://i.imgur.com/obdGXPV.png" alt="SignalR and Vue Typescript UI for what is on tap"></img>
<img src="https://i.imgur.com/PRLrg5j.jpeg" height="600px" alt="Flowmeter in the tapline"></img>
<h3>Planning</h3>
<p>
    <ul>
        <li>
            Beer and batch management - A GUI to add, edit and view beer batches for record keeping.     
        </li>
        <li>
            IN WORK - Recipe Management - GUI for managing recipes and materials
        </li>
        <li>
            PLANNED - Inventory Management - A way to track current inventory as well as relating it to a recipe.
        </li>
    </ul>
</p>
<img src="https://i.imgur.com/29hX7kT.png" alt="Interface for updating batches"></img>
