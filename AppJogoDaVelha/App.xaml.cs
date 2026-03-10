using Microsoft.Extensions.DependencyInjection;

namespace AppJogoDaVelha
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = new(new AppShell())
            {
                Height = 700,
                Width = 350
            };
            return window;
        }
    }
}