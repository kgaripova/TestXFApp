namespace TestXFApp
{
    using System;
    using Xamarin.Forms;
    using System.Threading;
    using System.Threading.Tasks;

    public class AsyncExamplePage : ContentPage
    {
        Frame frame;
        Entry entry;
        Button button;
        Label statusLabel;
        Label resultLabel;
        Label controlLabel;

        public AsyncExamplePage ()
        {
            this.frame = new Frame()
            {
                HeightRequest = 30,
                HasShadow = false
            };

            this.entry = new Entry();

            this.button = new Button()
            {
                Text = "Start!",
                BackgroundColor = Color.Aqua,
                Command = new Command(s => this.OnClick())
            };

            this.controlLabel = new Label()
            {
                Text = "control label",
                HorizontalOptions = LayoutOptions.Center
            };

            this.statusLabel = new Label()
            {
                Text = "status label",
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Yellow
            };

            this.resultLabel = new Label()
            {
                Text = "result label",
                HorizontalOptions = LayoutOptions.Center
            };

            this.Content = new StackLayout
            {
                Children = { this.frame, this.entry, this.button, this.controlLabel, this.statusLabel, this.resultLabel },
                Padding = 20
            };
        }

        private async void OnClick()
        {
            this.statusLabel.Text = "Started...";

            for (int i = 1; i <= 5; i++)
            {
                var result = await GetResult(i);
                this.resultLabel.Text += result;
                this.statusLabel.Text = string.Format("Loaded {0} batch", i); 
            }

            this.controlLabel.Text = "Complete!";
        }

        private async Task<string> GetResult(int batch)
        {
            var result = string.Empty;

            for (int i = 1; i < 20; i++)
            {
                await Task.Delay(100);
                result += string.Format("{0}-{1} ", batch, i);
            }    

            return result;
        }
    }
}

