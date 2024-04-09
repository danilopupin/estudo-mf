using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estudo_mf.Models
{
    [Table("Consumos")]
    public class Consumo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data Obrigatória")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Valor obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "KM Obrigatório")]
        public int Km { get; set; }

        public TipoCombustivel Tipo { get; set; }

        public int VeiculoId {  get; set; }

        [ForeignKey("VeiculoId")]
        public Veiculos Veiculo { get; set; }


    }
    public enum TipoCombustivel
    {
        Gasolina,
        Etanol
    }
}
