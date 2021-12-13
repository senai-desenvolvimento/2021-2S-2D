using senai_gufi_webAPI.Domains;
using System.Collections.Generic;

namespace senai_gufi_webAPI.Interfaces
{
    interface ILocalizacaoRepository
    {
        List<Localizacao> ListarTodas();

        void Cadastrar(Localizacao novaLocalizacao);
    }
}
