using Meadow;

namespace YoshiMaker;

/// <summary>
/// Represents the base application class for YoshiGameMini devices, inheriting from the generic App class.
/// </summary>
public abstract class YoshiGameMiniApp : App<RaspberryPi, YoshiGameMiniHardwareProvider, IYoshiGameMiniHardware>
{
    public YoshiGameMiniApp()
    {
    }
}

