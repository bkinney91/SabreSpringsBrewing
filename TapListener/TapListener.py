#!/usr/bin/python
import os
import time
import math
import logging
import requests
import RPi.GPIO as GPIO
from flowmeter import *

boardRevision = GPIO.RPI_REVISION
GPIO.setmode(GPIO.BCM) # use real GPIO numbering
GPIO.setup(23,GPIO.IN, pull_up_down=GPIO.PUD_UP)
GPIO.setup(24,GPIO.IN, pull_up_down=GPIO.PUD_UP)

# set up the flow meters
tap1 = FlowMeter('pints', ["beer"])
tap2 = FlowMeter('pints', ["beer"])


# Beer, on Pin 23.
def doAClick(channel):
  currentTime = int(time.time() * FlowMeter.MS_IN_A_SECOND)
  if tap1.enabled == True:
    tap1.update(currentTime)

# Beer, on Pin 24.
def doAClick2(channel):
  currentTime = int(time.time() * FlowMeter.MS_IN_A_SECOND)
  if tap2.enabled == True:
    tap2.update(currentTime)



GPIO.add_event_detect(23, GPIO.RISING, callback=doAClick, bouncetime=20) # Beer, on Pin 23
GPIO.add_event_detect(24, GPIO.RISING, callback=doAClick2, bouncetime=20) # Beer, on Pin 24

# main loop
while True:  
  currentTime = int(time.time() * FlowMeter.MS_IN_A_SECOND)
  if (tap1.thisPour > 0.125 and currentTime - tap1.lastClick > 3000): # 3 seconds of inactivity triggers http request
    print('Tap2:' + tap2.getThisPourInPints())
    postContent = {'TapNumber': 1, 'AmountPoured': tap1.getThisPourInPints()}
    request = requests.post('http://192.168.1.2/api/Tap/ProcessPour', json = postContent)
    tap1.thisPour = 0.0
 
  if (tap2.thisPour > 0.125 and currentTime - tap2.lastClick > 3000): # 3 seconds of inactivity triggers http request    
    print('Tap2:' + tap2.getThisPourInPints())
    postContent = {'TapNumber': 2, 'AmountPoured': tap2.getThisPourInPints()}
    request = requests.post('http://192.168.1.2/api/Tap/ProcessPour', json = postContent)
    tap2.thisPour = 0.0

  # the following block was in the original code but I do not feel like it is necessary
  # reset flow meter after each pour (2 secs of inactivity)
  #if (tap1.thisPour <= 0.23 and currentTime - tap1.lastClick > 2000):
  #  tap1.thisPour = 0.0
  #  
  #if (tap2.thisPour <= 0.23 and currentTime - tap2.lastClick > 2000):
  #  tap2.thisPour = 0.0
  

