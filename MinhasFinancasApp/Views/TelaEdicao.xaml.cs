using CommunityToolkit.Mvvm.Messaging;
using MinhasFinancasApp.Models;
using MinhasFinancasApp.Repositories;
using System.Text;

namespace MinhasFinancasApp.Views;

public partial class TelaEdicao : ContentPage
{
    private ITransicaoRepositorio _transation;

    private Transacao _transacao;
	public TelaEdicao(ITransicaoRepositorio transation)
	{
		InitializeComponent();

        _transation = transation;
    }

    public void SetTransacacaoEdit(Transacao transacao)
    {
        _transacao = transacao;

        if (transacao.Type == TransacaoType.Income)
            RadioIncome.IsChecked = true;
            else
            RadioExpense.IsChecked = true;

        EntryName.Text = transacao.Name;
        DatePickerDate.Date = transacao.Date.Date;
        EntryValue.Text = transacao.Value.ToString();
    }

    private void OnClickedSalvar(object sender, EventArgs e)
    {
        if (IsvalidData() == false)
        {
            return;
        }

        SalvarnoBanco();

        Navigation.PopModalAsync();

        WeakReferenceMessenger.Default.Send<string>(string.Empty);
    }

    private void SalvarnoBanco()
    {
        Transacao transacao = new Transacao()
        {
            Id = _transacao.Id,
            Type = RadioIncome.IsChecked ? TransacaoType.Income : TransacaoType.Expenses,
            Name = EntryName.Text,
            Date = DatePickerDate.Date,
            Value = double.Parse(EntryValue.Text)
        };

        _transation.Update(transacao);
    }

    private bool IsvalidData()
    {
        bool valid = true;
        StringBuilder sb = new StringBuilder();

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            sb.Append("O campo 'Nome' deve ser preenchido!");
            valid = false;
        }
        if (string.IsNullOrEmpty(EntryValue.Text) || string.IsNullOrWhiteSpace(EntryValue.Text))
        {
            sb.Append("O campo 'Valor' deve ser preenchido!");
            valid = false;
        }
        double result;
        if (!string.IsNullOrEmpty(EntryValue.Text) && !double.TryParse(EntryValue.Text, out result))
        {
            sb.Append("O campo 'Valor' é inválido!");
            valid = false;
        }
        if (valid == false)
        {
            LabelErro.Text = sb.ToString();
            LabelErro.IsVisible = true;
        }

        return valid;
    }

    private void OnTappedImage(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
}