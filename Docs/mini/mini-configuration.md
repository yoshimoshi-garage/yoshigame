# YoshiGame Mini Configuration


## Configuring SPI0

The Linux SPI Driver wants to drive the chip select (CS) pin automatically for you, but the Meadow drivers generally assume that the CS is driven by the peripheral driver.  This causes conflict because the Linux driver will auto-reserve pins for the CS function and not allow them for GPIO.

Without remapping, you will see an error like this:

```
Meadow.NativeException: Unable to access output pin.  Pin GPIO8 is in use
```

To address this, we use a kernel overlay to move the SPI driver's mapped CS pin to a pin that is off header (we typically use pin 44 for not specific reason than we know it works).

To move the chip select edit the file at `/boot/firmware/config.txt`

Navigate to the bottom of the file and add the following:

```
[all]
dtoverlay=spi0-1cs,cs0_pin=44
```