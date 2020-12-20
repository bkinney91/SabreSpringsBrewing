#!/usr/bin/env python3

import sys
import argparse



def getCurrentTemperature():
    return 187

def getTargetTemperature():
    return 1337





def main(argv):
    
    parser = argparse.ArgumentParser()
    parser.add_argument("-c", "--current", action="store_true") #Used to get current temp
    parser.add_argument("-t", "--target", action="store_true") #Used to get target temp (SV on the PID)
    parser.add_argument("-s","--set", type=int) 
   
    args = parser.parse_args()
    try:
        if(args.set):
            setKettleTarget(args.set)
        elif(args.current):
            print(getCurrentTemperature())
        elif(args.target):
            print(getTargetTemperature())
        else:
            print("Could not read arguments")
    finally:
        sys.exit(0)

if __name__ == "__main__":
   main(sys.argv[1:])
