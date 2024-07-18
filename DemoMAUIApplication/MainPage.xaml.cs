namespace DemoMAUIApplication
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            valueLabel.Text = args.NewValue.ToString("F3");
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Clicked!", "The button labeled '" + button.Text + "' has been clicked", "OK");
        }
        private async void OnAnimationButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                await Navigation.PushAsync(new AnimationPage());
            }
        }
        private async void OnGraphicsButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                await Navigation.PushAsync(new GraphicsPage());
            }
        }
        private async void OnBrushesButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                await Navigation.PushAsync(new BrushesPage());
            }
        }
        private async void OnMenuButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                await Navigation.PushAsync(new MenuPage());
            }
        }
    }

}
