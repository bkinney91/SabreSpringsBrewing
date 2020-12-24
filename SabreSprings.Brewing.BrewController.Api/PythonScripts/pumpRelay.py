import RPi.GPIO as GPIO
import time
import sys
import argparse
GPIO.setmode(GPIO.BCM)
pump1 = 26
pump2 = 20
GPIO.setup(pump1, GPIO.OUT)
GPIO.setup(pump2, GPIO.OUT)

def main(argv):
    parser = argparse.ArgumentParser()
    parser.add_argument("-1", "--pump1", type=str, dest="pump1", help="Enables power on pump1")
    parser.add_argument("-2", "--pump2", type=str, dest="pump2", help="Enables power on pump2")
    parser.add_argument("-f","--off", action="store_true", help="Disables power on both pumps")
    args = parser.parse_args()
    try:
        if(args.pump1 == "on"):
            GPIO.output(pump1, True)
        elif(args.pump1 == "off"):
            GPIO.output(pump1, False)
        elif(args.pump2 == "on"):
            GPIO.output(pump2, True)
        elif(args.pump2 == "off"):
            GPIO.output(pump2, False)
        elif(args.off):
            GPIO.output(pump2, False)
            GPIO.output(pump1, False)
        else:
            print("Could not read arguments")
    finally:        
        sys.exit(0)

if __name__ == "__main__":
   main(sys.argv[1:])