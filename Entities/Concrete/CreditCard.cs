using Core.Abstract;
using System;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Cvv { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public int CardType { get; set; }
    }

}
