
using System.Globalization;

namespace Exercicio_POO_22_Demonstracao_LINQ.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return Id + " - " +
                Name + " - " +
                Price.ToString(CultureInfo.InvariantCulture) + " - " +
                Category.Name + " - " +
                Category.Tie;
        }
    }
}
