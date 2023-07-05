using MinhasFinancasApp.Views;

namespace MinhasFinancasApp;

public partial class App : Application
{
	public App(TelaInicial telainicial)
	{
		InitializeComponent();

		MainPage = new NavigationPage(telainicial);
	}
}
