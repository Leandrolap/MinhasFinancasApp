using CommunityToolkit.Mvvm.Messaging;
using MinhasFinancasApp.Models;
using MinhasFinancasApp.Repositories;
using System.Text;

namespace MinhasFinancasApp.Views;

public partial class CadastroAdd : ContentPage
{
    private ITransicaoRepositorio _transation;
	public CadastroAdd(ITransicaoRepositorio transation)
	{
		InitializeComponent();
        
        _transation = transation;
	}

    private void OnTappedImage(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
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
            Type = RadioIncome.IsChecked ? TransacaoType.Income : TransacaoType.Expenses,
            Name = EntryName.Text,
            Date = DatePickerDate.Date,
            Value = double.Parse(EntryValue.Text)
        };

        _transation.Add(transacao);
    }

    private bool IsvalidData()
    {
        bool valid = true;
        StringBuilder sb = new StringBuilder();

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text)) 
        {
            sb.Append("O campo 'Nome' deve ser preenchido!" + "\r\n");
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
            LabelErro.IsVisible = true;
            LabelErro.Text = sb.ToString(); 
        }

        return valid;
    }
}