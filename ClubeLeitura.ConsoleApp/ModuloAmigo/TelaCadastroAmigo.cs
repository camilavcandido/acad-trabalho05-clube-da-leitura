using System;
using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaCadastroAmigo
    {
        public Amigo[] amigos;
        public int id;
        public Notificador notificador;

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
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo novo Amigo");

            Amigo amigo = ObterAmigo();

            amigo.id = ++id;

            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = amigo;

            notificador.ApresentarMensagem("Amigo inserida com sucesso!", "Sucesso");
        }

        private Amigo ObterAmigo()
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

            VisualizarAmigos("Pesquisando");

            Console.Write("Digite o id do amigo que deseja editar: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].id == idAmigo)
                {
                    Amigo amigo = ObterAmigo();

                    amigo.id = idAmigo;
                    amigos[i] = amigo;
                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo editada com sucesso", "Sucesso");
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            VisualizarAmigos("Pesquisando");

            Console.Write("Digite o id do amigo que deseja excluir: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].id == idAmigo)
                {
                    amigos[i] = null;
                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo excluído com sucesso", "Sucesso");
        }

        public void VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                Amigo a = amigos[i];

                Console.WriteLine("ID: " + a.id);
                Console.WriteLine("Nome: " + a.nome);
                Console.WriteLine("Responsavel: " + a.responsavel);
                Console.WriteLine("Endereço: " + a.endereco);

                Console.WriteLine();
            }
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }


    }

}