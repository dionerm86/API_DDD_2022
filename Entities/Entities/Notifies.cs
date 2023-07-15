using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities;
public class Notifies
{
    public Notifies()
    {
        Notify = new List<Notifies>();
    }

    [NotMapped]
    public string NomePropriedade { get; set; }
    [NotMapped]
    public string Mensagem { get; set; }
    [NotMapped]
    public List<Notifies> Notify { get; set; }
    public bool ValidarPropriedadeString(string valor, string nomePropriedade)
    {
        if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
        {
            Notify.Add(new Notifies
            {
                Mensagem = "Campo obrigatório",
                NomePropriedade = nomePropriedade
            });

            return false;
        }

        return true;
    }

    public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
    {
        if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
        {
            Notify.Add(new Notifies
            {
                Mensagem = "Campo obrigatório",
                NomePropriedade = nomePropriedade
            });

            return false;
        }

        return true;
    }
}
