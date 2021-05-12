using Bogus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace fake_data_example
{
    static class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Faker<Pessoa>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Int(1))
                .RuleFor(x => x.Nome, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.Nome))
                .RuleFor(x => x.DataNascimento, f => f.Date.Past(50))
                .RuleFor(x => x.Telefone, f => f.Phone.PhoneNumberFormat())
                .Generate();

            Console.WriteLine(JsonConvert.SerializeObject(pessoa, Formatting.Indented));

            List<Pessoa> pessoaLista = new Faker<Pessoa>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Int(1,100))
                .RuleFor(x => x.Nome, f => f.Name.FullName())
                .RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.Nome))
                .RuleFor(x => x.DataNascimento, f => f.Date.Between(Convert.ToDateTime("01/01/1990"), Convert.ToDateTime("01/01/2000")))
                .RuleFor(x => x.Telefone, f => f.Phone.PhoneNumberFormat())
                .Generate(10);

            Console.WriteLine(JsonConvert.SerializeObject(pessoaLista, Formatting.Indented));
        }
    }
}
