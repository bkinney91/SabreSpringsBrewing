#!/usr/bin/env python3
import minimalmodbus
import sys
import argparse

#PID Configuration
# Address of device is /dev/ttyUSB0 since it is a USB to RS485 converter that is wired to the PID
# Device Id defaults to 5, I have changed it to 1
# Device type is RTU
pid = minimalmodbus.Instrument("/dev/ttyUSB0", 1, minimalmodbus.MODE_RTU, True)
pid.serial.baudrate = 2400              # Baud rate
pid.serial.bytesize = 8                  # Typical size of a byte :)
pid.serial.parity = minimalmodbus.serial.PARITY_NONE # No parity check for this instrument.
pid.serial.stopbits = 1                     # Whatever this means. It needs to be 1 for this instrument.
pid.serial.timeout  = 1         # Timeout in seconds. Must be >0.3 for this instrument.
pid.mode = minimalmodbus.MODE_RTU                    # RTU or ASCII mode. Must be RTU for this instrument.
pid.clear_buffers_before_each_transaction = True # Seems like a good idea. Works, too.



def getCurrentTemperature():
    return pid.read_float(356)

def getTargetTemperature():
    return pid.read_float(0)

def setKettleTarget(value):
    print("setting temperature to ", value)
    pid.write_float(0, value)



def main(argv):
    
    parser = argparse.ArgumentParser()
    parser.add_argument("-c", "--current", action="store_true", help="Returns the current temperature of the kettle") #Used to get current temp
    parser.add_argument("-t", "--target", action="store_true", help="Returns the target temperature of the PID") #Used to get target temp (SV on the PID)
    parser.add_argument("-s","--set", type=int, help="Requires an integer value above 0, sets the PID target to the provided value.") 
   
    args = parser.parse_args()
    try:
        if(args.set):
            if(args.set < 1):
                raise Exception("PID will not accept value below 1")
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
