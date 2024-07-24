using Meadow;
using Meadow.Hardware;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors.Buttons;
using Meadow.Peripherals.Sensors.Hid;

namespace YoshiMaker;

public interface IYoshiGameMiniHardware : IMeadowAppEmbeddedHardware
{
    IDigitalInterruptPort TestPort { get; }
    IDigitalPushButtonJoystick Joystick { get; }
    IPixelDisplay Display { get; }
    IButton KEY1 { get; }
    IButton KEY2 { get; }
    IButton KEY3 { get; }

}