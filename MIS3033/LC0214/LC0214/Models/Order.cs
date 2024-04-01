using System.ComponentModel.DataAnnotations;

namespace b
{
    public class Order
    {
        [Key]

        public string Id { get; set; }

        public double Subtotal { get; set; }

        public double SalesTax { get; set; }

        public override string ToString()
        {
            return $"ID: {this.Id}, Subtotal: {this.Subtotal:C2}";
        }

    }
}