# SabreSpringsBrewing
<p>
    This website is designed to help me automate and organize all my brewing activities, and to make naming variables easier I decided 
    to give my home brewery a name. 
</p>

<h3>Goals</h3>
<p>
    What I want to ultimately achieve with this project is to create a management interface for data (inventory, batches, recipes) and automation
    for fermenting (temperature, gravity). Long term I would love
    to tackle automating the brewing process itself.
</p>

<h3>Data and organization</h3>
<p>
    Most of this functionality will be simple CRUD for entering batches and recipes, but there are a few features that require a bit of logic to execute.
    <ul>
        <li>
            Recipe Workflow - Workflow that will create a new batch based on the recipe, but still allows me to make changes so I can catalog what 
            was <i>actually</i> put into the batch.
        </li>
        <li>
            Inventory Management - Full CRUD for managing inventory, will be integrated into the recipe interface (to show if I have current stock 
            of everything in the recipe) and the recipe workflow so that inventory is automatically deducted when a new batch is created.
        </li>
    </ul>
</p>

<h3>Automation</h3>
<p>
   Most of the automation efforts are on data collecting during the fermentation process. 
    <ul>
        <li>
            Tap line flowmeters - This idea was based on the <a href="https://learn.adafruit.com/adafruit-keg-bot/overview" >Adafruit Kegomatic</a>, but instead of using a python
            GUI I decided to have my script send an HTTP request to the Web Api portion of this application. Check out the <a href="/Taproom/OnTap">On Tap</a> page to see a how much
            beer is left in each keg!       
        </li>
        <li>
            Fermentation Monitoring - API endpoints for gathering temperature and gravity of a currently fermenting beer, including history and graphs. To gather this data I will be 
            following the hardware guide provided by <a href="https://www.opensourcedistilling.com/ispindel-assembly/">Open Source Distilling</a>
            along with the open source <a href="http://www.ispindel.de/">iSpindel</a> software.
        </li>
    </ul>
</p>
