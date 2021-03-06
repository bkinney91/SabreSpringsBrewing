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
GPIO.setup(25,GPIO.IN, pull_up_down=GPIO.PUD_UP)
# set up the flow meters
tap1 = FlowMeter('pints', ["beer"])
tap2 = FlowMeter('pints', ["beer"])
tap3 = FlowMeter('pints', ["beer"])

# Tap draw on Pin 23.
def registerDrawTap1(channel):
  currentTime = int(time.time() * FlowMeter.MS_IN_A_SECOND)
  if tap1.enabled == True:
    tap1.update(currentTime)

# Tap draw on Pin 24.
def registerDrawTap2(channel):
  currentTime = int(time.time() * FlowMeter.MS_IN_A_SECOND)
  if tap2.enabled == True:
    tap2.update(currentTime)

# Tap draw on Pin 25
def registerDrawTap3(channel):
  currentTime = int(time.time() * FlowMeter.MS_IN_A_SECOND)
  if tap3.enabled == True:
    tap3.update(currentTime)

GPIO.add_event_detect(23, GPIO.RISING, callback=registerDrawTap1, bouncetime=20) 
GPIO.add_event_detect(24, GPIO.RISING, callback=registerDrawTap2, bouncetime=20) 
GPIO.add_event_detect(25, GPIO.RISING, callback=registerDrawTap3, bouncetime=20)
# main loop
while True:  
  currentTime = int(time.time() * FlowMeter.MS_IN_A_SECOND)
  if (tap1.thisPour > 0.125 and currentTime - tap1.lastClick > 3000): # 3 seconds of inactivity triggers http request
    print('Tap2:' + tap2.getThisPourInPints())
    postContent = {'TapNumber': 1, 'AmountPoured': tap1.getThisPourInPints()}
    request = requests.post('http://10.0.0.2:8080/api/Tap/ProcessPour', json = postContent)
    tap1.thisPour = 0.0
 
  if (tap2.thisPour > 0.125 and currentTime - tap2.lastClick > 3000): # 3 seconds of inactivity triggers http request    
    print('Tap2:' + tap2.getThisPourInPints())
    postContent = {'TapNumber': 2, 'AmountPoured': tap2.getThisPourInPints()}
    request = requests.post('http://10.0.0.2:8080/api/Tap/ProcessPour', json = postContent)
    tap2.thisPour = 0.0

  if (tap3.thisPour > 0.125 and currentTime - tap3.lastClick > 3000): # 3 seconds of inactivity triggers http request    
    print('Tap3:' + tap3.getThisPourInPints())
    postContent = {'TapNumber': 3, 'AmountPoured': tap3.getThisPourInPints()}
    request = requests.post('http://10.0.0.2:8080/api/Tap/ProcessPour', json = postContent)
    tap3.thisPour = 0.0

  

