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

        //public virtual List<UsuarioPerfilViewModel> Usuarios { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Id == ((PerfilViewModel)obj).Id;
        }
    }
}