using ApiAlunes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAlunes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private List<Aluno> PegarDados()
        {
            // Criar uma lista de Alunos vazia para receber os dados do arquivo
            List<Aluno> listaAlunos = new();

            try
            {
                // Pegar arquivo c:\temp\alunos.json e trazer para a memória
                string dadosArquivo = System.IO.File.ReadAllText("c:\\temp\\alunos.json");
                listaAlunos = System.Text.Json.JsonSerializer.Deserialize<List<Aluno>>(dadosArquivo);
            }
            catch { }

            return listaAlunos;
        }

        [HttpGet]
        public IEnumerable<Aluno> GetLista()
        {
            return PegarDados();
        }

        [HttpPost]
        public IActionResult CadastrarAluno(Aluno aluno)
        {
            // Criar uma lista de Alunos vazia para receber os dados do arquivo
            List<Aluno> listaAlunos = PegarDados();

            // Adicionar o novo aluno na lista de alunos
            listaAlunos.Add(aluno);

            SalvarDados(listaAlunos);

            return Ok();
        }

        [HttpDelete]

        public IActionResult RemoverAlunos(int id)
        {
            //carregar os dados do aquivo para a memória
            List<Aluno> listaAlunos = PegarDados();
            SalvarDados(listaAlunos.Where(item => item.Id != id).ToList());
            return Ok();
        }
        [HttpPut]
        public IActionResult EditarAluno(Aluno aluno)
        {
            var listaAlunos = PegarDados();
            listaAlunos = listaAlunos.Where(item => item.Id != aluno.Id).ToList();
            listaAlunos.Add(aluno);
            SalvarDados(listaAlunos);
            return Ok();
        }

        private static void SalvarDados(List<Aluno> listaAlunos)
        {
            // Serializar a lista de alunos e salvar no arquivo c:\temp\alunos.json
            string dadosSerializados = System.Text.Json.JsonSerializer.Serialize(listaAlunos);

            // Salvar os dados serializados no arquivo c:\temp\alunos.json
            System.IO.File.WriteAllText("c:\\temp\\alunos.json", dadosSerializados);
        }
    }
}