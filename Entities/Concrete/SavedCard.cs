using Core.Abstract;

namespace Entities.Concrete
{
    public class SavedCard : IEntity
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvv { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public int CardType { get; set; }
        public int UserId { get; set; }
    }

}
