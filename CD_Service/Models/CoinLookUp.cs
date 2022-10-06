using System.ComponentModel.DataAnnotations;

namespace CD_Service.Models
{
    public class CoinLookUp
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
