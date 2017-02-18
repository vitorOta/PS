using ProcessoSeletivo.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProcessoSeletivo.Application.ViewModel
{
    public class UsuarioViewModel : ViewModelBase
    {

        [Key]
        public override int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public bool Ativo { get; set; }

        [Display(Name ="Data de Inclusão")]
        public DateTime DtInclusao { get; set; }

        [Display(Name = "Perfis")]
        public virtual List<UsuarioPerfilViewModel> Perfis { get; set; }
    }
}