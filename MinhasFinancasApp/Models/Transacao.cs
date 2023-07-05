using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancasApp.Models
{
    public class Transacao
    {
        [BsonId]
        public int Id { get; set; }
        public TransacaoType Type { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Value { get; set; }
    }

    public enum TransacaoType
    {
        Income,
        Expenses  
    }
}
