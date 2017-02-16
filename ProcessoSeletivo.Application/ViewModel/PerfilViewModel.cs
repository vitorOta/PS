﻿using ProcessoSeletivo.Application.ViewModel.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProcessoSeletivo.Application.ViewModel
{
    public class PerfilViewModel : IViewModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public bool? Ativo { get; set; }

        public virtual List<UsuarioPerfilViewModel> Usuarios { get; set; }
    }
}