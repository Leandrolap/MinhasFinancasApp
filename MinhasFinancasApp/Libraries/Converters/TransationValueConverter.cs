using MinhasFinancasApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancasApp.Libraries.Converters
{
    public class TransationValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Transacao transacao = (Transacao)value;

            if (transacao == null)
            {
                return "";
            }

            if (transacao.Type == TransacaoType.Income)
            {
                return transacao.Value.ToString("C");
            }
            else
            {
                return $"- {transacao.Value.ToString("C")}";
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
