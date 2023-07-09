using CommunityToolkit.Mvvm.Messaging;
using MinhasFinancasApp.Models;
using MinhasFinancasApp.Repositories;
using System;

namespace MinhasFinancasApp.Views;

public partial class TelaInicial : ContentPage
{
    private ITransicaoRepositorio _repositorio;
    public TelaInicial(ITransicaoRepositorio repositorio)
	{
        this._repositorio = repositorio;

		InitializeComponent();

        Reload();

        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
        {
            Reload();
        });
	}

    private void Reload()
    {
        var items = _repositorio.GetAll();
        CollectionTrasacao.ItemsSource = items;

        double income = items.Where(a => a.Type == Models.TransacaoType.Income).Sum(a => a.Value);
        double expense = items.Where(a => a.Type == Models.TransacaoType.Expenses).Sum(a => a.Value);

        double balanca = income - expense;

        LblReceitas.Text = income.ToString("C");
        LblDespesas.Text = expense.ToString("C");
        LblSaldo .Text = balanca.ToString("C");
    }

    private void OnclickAdd(object sender, EventArgs e)
    {
        var transacao = Handler.MauiContext.Services.GetService<CadastroAdd>();
		Navigation.PushModalAsync(transacao);
    }

    private void TapGestureEdit(object sender, TappedEventArgs e)
    {
        var grid = (Grid)sender;
        var gesture = (TapGestureRecognizer)grid.GestureRecognizers[0];
        Transacao transacao = (Transacao)gesture.CommandParameter;

        var editt = Handler.MauiContext.Services.GetService<TelaEdicao>();
        editt.SetTransacacaoEdit(transacao);
        Navigation.PushModalAsync(editt);
    }

    public void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
    {
        var grid = (SwipeItem)sender;
        Transacao transacao = (Transacao)grid.CommandParameter;
        _repositorio.Delete(transacao);

        Reload();
    }

    private void OnClickSobre(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Sobre());
    }
}