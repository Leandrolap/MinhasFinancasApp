using MinhasFinancasApp.Views;

namespace MinhasFinancasApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new TelaInicial();
	}
}
