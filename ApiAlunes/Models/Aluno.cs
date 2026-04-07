using Microsoft.AspNetCore.Mvc;

namespace ApiAlunes.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Celular { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }



    }
}
