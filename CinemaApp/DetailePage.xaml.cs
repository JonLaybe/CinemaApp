using ÑinemaApp.MVVM.ViewModels;

namespace CinemaApp;

public partial class DetailePage : ContentPage
{
	public DetailePage(DetaileViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}