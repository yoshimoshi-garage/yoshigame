using Meadow;
using Meadow.Foundation.Displays;
using Meadow.Foundation.Sensors.Buttons;
using Meadow.Foundation.Sensors.Hid;
using Meadow.Hardware;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors.Buttons;
using Meadow.Peripherals.Sensors.Hid;
using Meadow.Units;

namespace YoshiMaker;

public class YoshiGameMini : IYoshiGameMiniHardware
{
    public IMeadowDevice ComputeModule { get; }

    public IDigitalPushButtonJoystick Joystick { get; }
    public IPixelDisplay Display { get; }
    public IButton KEY1 { get; }
    public IButton KEY2 { get; }
    public IButton KEY3 { get; }

    public IDigitalInterruptPort TestPort { get; }

    private readonly IDigitalOutputPort _backlight;

    internal YoshiGameMini(RaspberryPi device)
    {
        ComputeModule = device;

        Joystick = new DigitalPushButtonJoystick(
            device.Pins.GPIO6,  // up
            device.Pins.GPIO19, // down
            device.Pins.GPIO5,  // left
            device.Pins.GPIO26, // right
            device.Pins.GPIO13, // center
            ResistorMode.InternalPullUp
            );

        KEY1 = new PushButton(device.Pins.GPIO21.CreateDigitalInterruptPort(InterruptMode.EdgeBoth, ResistorMode.InternalPullUp));
        KEY2 = new PushButton(device.Pins.GPIO20.CreateDigitalInterruptPort(InterruptMode.EdgeBoth, ResistorMode.InternalPullUp));
        KEY3 = new PushButton(device.Pins.GPIO16.CreateDigitalInterruptPort(InterruptMode.EdgeBoth, ResistorMode.InternalPullUp));

        _backlight = device.Pins.GPIO24.CreateDigitalOutputPort(true);

        Display = new St7735(
            device.CreateSpiBus(device.Pins.SPI0_SCLK, device.Pins.SPI0_MOSI, device.Pins.SPI0_MISO, 24_000_000.Hertz()),
            device.Pins.GPIO8,
            device.Pins.GPIO25,
            device.Pins.GPIO27,
            130, 132);


    }
}

