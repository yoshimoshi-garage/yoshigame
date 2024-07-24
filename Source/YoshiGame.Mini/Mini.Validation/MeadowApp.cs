using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;
using YoshiMaker;

namespace Mini.Validation;

internal class MeadowApp : YoshiGameMiniApp
{
    private DisplayScreen _screen;
    private Label _statusLabel;

    public override Task Initialize()
    {
        _screen = new DisplayScreen(Hardware.Display, Meadow.Peripherals.Displays.RotationType._270Degrees)
        {
            BackgroundColor = Color.DarkBlue
        };

        _statusLabel = new Label(0, 0, _screen.Width, _screen.Height)
        {
            HorizontalAlignment = Meadow.Foundation.Graphics.HorizontalAlignment.Center,
            VerticalAlignment = Meadow.Foundation.Graphics.VerticalAlignment.Center,
            TextColor = Color.White,
            Font = new Font16x24(),
            Text = "HELLO!"
        };

        _screen.Controls.Add(_statusLabel);

        Hardware.Joystick.Clicked += OnJoystickClicked;
        Hardware.Joystick.Updated += OnJoystickDirectionUpdated;
        Hardware.KEY1.Clicked += OnButton1Clicked;
        Hardware.KEY2.Clicked += OnButton2Clicked;
        Hardware.KEY3.Clicked += OnButton3Clicked;

        return base.Initialize();
    }

    private void OnButton1Clicked(object? sender, EventArgs e)
    {
        Resolver.Log.Info("KEY1");
        _statusLabel.Text = "KEY1";
    }

    private void OnButton2Clicked(object? sender, EventArgs e)
    {
        Resolver.Log.Info("KEY2");
        _statusLabel.Text = "KEY2";
    }

    private void OnButton3Clicked(object? sender, EventArgs e)
    {
        Resolver.Log.Info("KEY3");
        _statusLabel.Text = "KEY3";
    }

    private void OnJoystickDirectionUpdated(object? sender, ChangeResult<Meadow.Peripherals.Sensors.Hid.DigitalJoystickPosition> e)
    {
        Resolver.Log.Info($"{e.New}");
        _statusLabel.Text = e.New.ToString();
    }

    private void OnJoystickClicked(object? sender, EventArgs e)
    {
        Resolver.Log.Info("JS");
        _statusLabel.Text = "JS";
    }

    private static void Main(string[] args)
    {
        MeadowOS.Start(args);
    }
}
