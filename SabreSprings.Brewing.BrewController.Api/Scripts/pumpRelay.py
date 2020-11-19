import RPi.GPIO as GPIO
import time
import sys
import argparse
GPIO.setmode(GPIO.BCM)
GPIO.setup(20, GPIO.OUT)
GPIO.setup(26, GPIO.OUT)



def main(argv):
    #GPIO.output(20, False)
    #GPIO.output(26, False)
    pin = 0
    power = False
    parser = argparse.ArgumentParser()
    parser.add_argument("-1", "--pump1", action="store_true")
    parser.add_argument("-2", "--pump2", action="store_true")
    parser.add_argument("-o", "--on", action="store_true")
    parser.add_argument("-f","--off", action="store_true")
    args = parser.parse_args()
    if(args.pump1):
        pinNumber = 26
    elif(args.pump2):
        pinNumber = 20
    else:
        print "Could not determine pump #"
    power = args.on
    try:
        print 'Setting Pin #'+ str(pinNumber) + " to " + str(power)
        GPIO.output(pinNumber, power)
    finally:
        #GPIO.cleanup()
        sys.exit(0)

if __name__ == "__main__":
   main(sys.argv[1:])