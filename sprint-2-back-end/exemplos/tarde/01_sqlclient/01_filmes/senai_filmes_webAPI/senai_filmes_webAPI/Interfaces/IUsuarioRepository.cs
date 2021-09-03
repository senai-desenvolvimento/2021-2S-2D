﻿using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Interface responsável pelo repositório IUsuarioRepository
/// </summary>
namespace senai_filmes_webAPI.Interfaces
{
    interface IUsuarioRepository
    {

    /// <summary>
    ///  Valida o usuário
    /// </summary>
    /// <param name="email"> email do usuario</param>
    /// <param name="senha"> senha do usuario</param>
    /// <returns></returns>
      UsuarioDomain BuscarPorEmailSenha(string email, string senha);

    }
}
