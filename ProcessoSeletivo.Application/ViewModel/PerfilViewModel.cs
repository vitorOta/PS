using ProcessoSeletivo.Application.ViewModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProcessoSeletivo.Application.ViewModel
{
    public class PerfilViewModel : ViewModelBase
    {

        [Key]
        public override int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public List<UsuarioPerfilViewModel> Usuarios { get; set; }
    }
}