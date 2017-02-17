using ProcessoSeletivo.Application.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace ProcessoSeletivo.Application.ViewModel
{
    public class UsuarioPerfilViewModel : ViewModelBase
    {

        [Key]
        public int UsuarioId { get; set; }

        [Key]
        public int PerfilId { get; set; }

        public bool Ativo { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }

        public virtual PerfilViewModel Perfil { get; set; }
    }
}