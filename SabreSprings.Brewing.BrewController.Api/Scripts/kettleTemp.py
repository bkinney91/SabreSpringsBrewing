import minimalmodbus

PORT='/dev/cu.usbserial-AC00XX39'

HUM_REGISTER = 102

#Set up instrument
instrument = minimalmodbus.Instrument(PORT,1,mode=minimalmodbus.MODE_RTU)

#Make the settings explicit
instrument.serial.baudrate = 9600        # Baud
instrument.serial.bytesize = 8
instrument.serial.parity   = minimalmodbus.serial.PARITY_EVEN
instrument.serial.stopbits = 1
instrument.serial.timeout  = 1          # seconds

# Good practice
instrument.close_port_after_each_call = True

instrument.clear_buffers_before_each_transaction = True

# Read temperatureas a float
# if you need to read a 16 bit register use instrument.read_register()


# Read the humidity
humidity = instrument.read_float(HUM_REGISTER)

#Pront the values

print('The humidity is: %.1f percent\r' % humidity)

#My code

#Read Temp 
TempReadFunction = 3
TempReadPayload ="01 64 00 02 85 AC"
Temperature = instrument.write_register(5, TempReadPayload, number_of_decimals=3,functioncode=3, signed=False)

#set Temp
NewTemperature = 76.5
SetTempPayload = "00 00 00 02 04"
instrument.write_register(5, SetTempPayload + NewTemperature.to_bytes(4, byteorder='big') + "52 CF", functioncode=10, signed=false)