namespace CinemaApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetailePage), typeof(DetailePage));
        }
    }
}
