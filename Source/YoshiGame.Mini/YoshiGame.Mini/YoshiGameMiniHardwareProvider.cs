using Meadow;

namespace YoshiMaker;

public class YoshiGameMiniHardwareProvider : IMeadowAppEmbeddedHardwareProvider<IYoshiGameMiniHardware>
{
    private YoshiGameMiniHardwareProvider()
    {
    }

    /// <summary>
    /// Creates an instance of <see cref="IYoshiGameMiniHardware"/> for the specified device.
    /// </summary>
    /// <param name="device">The device for which to create the hardware.</param>
    /// <returns>An instance of <see cref="IYoshiGameMiniHardware"/>.</returns>
    public IYoshiGameMiniHardware Create(IMeadowDevice device)
    {
        if (device is RaspberryPi pi)
        {
            return new YoshiGameMini(pi);
        }

        // this method is called by MeadowOS, so we should never get here
        throw new Exception("Invalid IMeadowDevice provided");
    }
}

