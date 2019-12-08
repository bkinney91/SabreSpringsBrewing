#!/usr/bin/python
import os
import time
import math
import logging
import RPi.GPIO as GPIO
from flowmeter import *

boardRevision = GPIO.RPI_REVISION
GPIO.setmode(GPIO.BCM) # use real GPIO numbering
GPIO.setup(23,GPIO.IN, pull_up_down=GPIO.PUD_UP)
GPIO.setup(24,GPIO.IN, pull_up_down=GPIO.PUD_UP)

# set up the flow meters
tap1 = FlowMeter('pints', ["beer"])
tap2 = FlowMeter('pints', ["beer"])

# set up the colors
BLACK = (0,0,0)
WHITE = (255,255,255)

# Beer, on Pin 23.
def doAClick(channel):
  currentTime = int(time.time() * FlowMeter.MS_IN_A_SECOND)
  if tap1.enabled == True:
    tap1.update(currentTime)

# Root Beer, on Pin 24.
def doAClick2(channel):
  currentTime = int(time.time() * FlowMeter.MS_IN_A_SECOND)
  if tap2.enabled == True:
    tap2.update(currentTime)



GPIO.add_event_detect(23, GPIO.RISING, callback=doAClick, bouncetime=20) # Beer, on Pin 23
GPIO.add_event_detect(24, GPIO.RISING, callback=doAClick2, bouncetime=20) # Root Beer, on Pin 24

# main loop
while True:  
  currentTime = int(time.time() * FlowMeter.MS_IN_A_SECOND)
  if (tap1.thisPour > 0.23 and currentTime - tap1.lastClick > 10000): # 10 seconds of inactivity triggers http request
    print("Someone just poured " + tap1.getFormattedThisPour() + " from Tap #1" )
    lastTweet = int(time.time() * FlowMeter.MS_IN_A_SECOND)
    tap1.thisPour = 0.0
 
  if (tap2.thisPour > 0.23 and currentTime - tap2.lastClick > 10000): # 10 seconds of inactivity triggers http request
    print("Someone just poured " + tap2.getFormattedThisPour() + " from Tap #2")
    lastTweet = int(time.time() * FlowMeter.MS_IN_A_SECOND)
    tap2.thisPour = 0.0

  # the following block was in the original code but I do not feel like it is necessary
  # reset flow meter after each pour (2 secs of inactivity)
  #if (tap1.thisPour <= 0.23 and currentTime - tap1.lastClick > 2000):
  #  tap1.thisPour = 0.0
  #  
  #if (tap2.thisPour <= 0.23 and currentTime - tap2.lastClick > 2000):
  #  tap2.thisPour = 0.0
  

