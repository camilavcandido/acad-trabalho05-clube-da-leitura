using System;
using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaCadastroAmigo
    {
        public int id;
        public Notificador notificador;
        public RepositorioAmigo repositorioAmigo;

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        } // ok

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo novo Amigo");

            Amigo amigo = ObterAmigo();
            repositorioAmigo.Inserir(amigo);
            notificador.ApresentarMensagem("Amigo inserido com sucesso!", "Sucesso");
        }

        public Amigo ObterAmigo()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o responsável: ");
            string responsavel = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo();

            amigo.nome = nome;
            amigo.responsavel = responsavel;
            amigo.telefone = telefone;
            amigo.endereco = endereco;

            return amigo;
        }

        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");

            bool temAmigoCadastrado = VisualizarAmigos("Pesquisando");
            if (temAmigoCadastrado == false)
            {
                notificador.ApresentarMensagem("Nenhum amigo cadastrado para poder editar", "Atencao");
                return;
            }

            int idAmigo = ObterIdAmigo();


            Amigo amigoAtualizado = ObterAmigo();

            repositorioAmigo.Editar(idAmigo, amigoAtualizado);

            notificador.ApresentarMensagem("Amigo editada com sucesso", "Sucesso");
        }

        public int ObterIdAmigo()
        {
            int idAmigo;
            bool idAmigoEncontrado;

            do
            {
                Console.Write("Digite o ID do Amigo: ");
                idAmigo = Convert.ToInt32(Console.ReadLine());

                idAmigoEncontrado = repositorioAmigo.VerificarIdAmigoExiste(idAmigo);

                if (idAmigoEncontrado == false)
                {
                    notificador.ApresentarMensagem("Amigo não encontrado, digite novamente",
                        "Atencao");

                }

            } while (idAmigoEncontrado == false);

            return idAmigo;
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        } // ok

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            bool temAmigoCadastrado = VisualizarAmigos("Pesquisando");
            if (temAmigoCadastrado == false)
            {
                notificador.ApresentarMensagem("Nenhum amigo cadastrado para poder excluir","Atencao");
                return;
            }

            Console.Write("Digite o id do amigo que deseja excluir: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            repositorioAmigo.Excluir(idAmigo);

            notificador.ApresentarMensagem("Amigo excluído com sucesso", "Sucesso");
        }

        public bool VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            Amigo[] amigos = repositorioAmigo.SelecionarTodos();

            if (amigos.Length == 0)
                return false;

            for (int i = 0; i < amigos.Length; i++)
            {

                Amigo a = amigos[i];

                Console.WriteLine("ID: " + a.id);
                Console.WriteLine("Nome: " + a.nome);
                Console.WriteLine("Responsavel: " + a.responsavel);
                Console.WriteLine("Endereço: " + a.endereco);

                Console.WriteLine();
            }
            return true;
        } // ok



    }
}