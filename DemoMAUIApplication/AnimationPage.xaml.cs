namespace DemoMAUIApplication;

public partial class AnimationPage : ContentPage
{
	public AnimationPage()
	{
		InitializeComponent();
	}
    private async void OnAnimationButtonClicked(object sender, EventArgs e)
    {
        Button button = sender as Button;

        if (button != null)
        {
            // Applying rotation animation
            await button.RotateTo(360, 1000);  // 360 degrees rotation in 1 second
            button.Rotation = 0;  // Reset rotation

            // Applying scaling animation
            await button.ScaleTo(1.5, 500);  // Scale up to 1.5 in 0.5 seconds
            await button.ScaleTo(1, 500);    // Scale back to 1 in 0.5 seconds
            await button.TranslateTo(-100, 0, 1000);    // Move image left
            await button.TranslateTo(-100, -100, 1000); // Move image diagonally up and left
            await button.TranslateTo(100, 100, 2000);   // Move image diagonally down and right
            await button.TranslateTo(0, 100, 1000);     // Move image left
            await button.TranslateTo(0, 0, 1000);       // Move image up
           
            await button.TranslateTo(0, 200, 2000, Easing.BounceIn);
            await button.ScaleTo(2, 2000, Easing.CubicIn);
            await button.RotateTo(360, 2000, Easing.SinInOut);
            await button.ScaleTo(1, 2000, Easing.CubicOut);
            await button.TranslateTo(0, -200, 2000, Easing.BounceOut);
            uint duration = 10 * 60 * 1000;
            await Task.WhenAll
            (
              button.RotateTo(307 * 360, duration),
              button.RotateXTo(251 * 360, duration),
              button.RotateYTo(199 * 360, duration)
            );
            await Task.WhenAny<bool>
            (
              button.RotateTo(360, 4000),
              button.ScaleTo(2, 2000)
            );
            await button.ScaleTo(1, 2000);
            var animation = new Animation(v => button.Scale = v, 1, 2);
            animation.Commit(this, "SimpleAnimation", 16, 2000, Easing.Linear, (v, c) => button.Scale = 1, () => true);
        }
    }
}