using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoCWebAPI.Models;

namespace PoCWebAPI.Controllers
{
    public class DbEscola
    {
        public List<Aluno> Alunos { get; set; } = new List<Aluno>
            {
                new Aluno {
                    Id = 1,
                    Nome = "Willian",
                    Sobrenome = "Sant Anna"
                },
                new Aluno {
                    Id = 2,
                    Nome = "Mariana",
                    Sobrenome = "Alves"
                }
            };
    };

    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {

        private DbEscola dbEscola = new DbEscola();


        [HttpGet]
        public Aluno[] AcessarAlunos()
        {
            return dbEscola.Alunos.ToArray();
        }

        [HttpGet("{Id}")]
        public Aluno AcessarAlunoPelaId(int Id)
        {
            Aluno Resultado = new Aluno();

            foreach (Aluno aluno in dbEscola.Alunos)
            {
                if (aluno.Id == Id)
                {
                    Resultado = aluno;
                }
            }

            return Resultado;
        }

        [HttpPost]
        public Aluno CadastrarAluno(Aluno novoAluno)
        {
            dbEscola.Alunos.Add(novoAluno);

            return novoAluno;
        }

        [HttpDelete("{Id}")]
        public Aluno DeletarAluno(int Id)
        {
             Aluno AlunoDeletado = new Aluno();

            foreach(Aluno aluno in dbEscola.Alunos)
            {
                if(aluno.Id == Id)
                {
                    AlunoDeletado = aluno;
                    dbEscola.Alunos.Remove(AlunoDeletado);
                }
            }

            return AlunoDeletado;
        }

    }
}
