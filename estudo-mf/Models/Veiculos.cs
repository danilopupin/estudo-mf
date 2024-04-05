using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estudo_mf.Models
{
    [Table("Veiculos")]
    public class Veiculos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a placa")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o ano de fabricação")]
        [Display (Name="Ano de Fabricação")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o ano do modelo")]
        [Display(Name = "Ano Modelo")]
        public int AnoModelo { get; set; }
    }
}
