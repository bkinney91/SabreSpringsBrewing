import RPi.GPIO as GPIO
import time
import sys
import argparse
GPIO.setmode(GPIO.BCM)
GPIO.setup(20, GPIO.OUT)
GPIO.setup(26, GPIO.OUT)

def main(argv):
    pin = 0
    power = False
    parser = argparse.ArgumentParser()
    parser.add_argument("-1", "--pump1", action="store_true")
    parser.add_argument("-2", "--pump2", action="store_true")
    parser.add_argument("-f","--off", action="store_true")
    args = parser.parse_args()
    try:
        if(args.pump1):
            GPIO.output(26, True)
        elif(args.pump2):
            GPIO.output(20, True)
        elif(args.off):
            GPIO.output(20, False)
            GPIO.output(26, False)
        else:
            print "Could not read arguments"
    finally:
        #GPIO.cleanup()
        sys.exit(0)

if __name__ == "__main__":
   main(sys.argv[1:])