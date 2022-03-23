using System;
using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Notificador notificador = new Notificador();
            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();
            TelaCadastroCaixa telaCadastroCaixa = new TelaCadastroCaixa();
            TelaCadastroAmigo telaCadastroAmigo = new TelaCadastroAmigo();

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();

            repositorioCaixa.caixas = new Caixa[10];
            repositorioAmigo.amigos = new Amigo[10];      

            telaCadastroCaixa.repositorioCaixa = repositorioCaixa;
            telaCadastroAmigo.repositorioAmigo = repositorioAmigo;

            telaCadastroCaixa.notificador = notificador;
            telaCadastroAmigo.notificador = notificador;

            while (true)
            {
                string opcaoMenuPrincipal = menuPrincipal.MostrarOpcoes();

                if (opcaoMenuPrincipal == "1")
                {
                    string opcao = telaCadastroCaixa.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroCaixa.InserirNovaCaixa();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroCaixa.EditarCaixa();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroCaixa.ExcluirCaixa();
                    }
                    else if (opcao == "4")
                    {
                        bool temCaixaCadastrada = telaCadastroCaixa.VisualizarCaixas("Tela");
                        if (temCaixaCadastrada == false)
                        {
                            notificador.ApresentarMensagem("Nenhuma caixa cadastrada", "Atencao");
                    
                        }
                        Console.ReadLine();
                    }
                }

                if (opcaoMenuPrincipal == "3")
                {
                    string opcao = telaCadastroAmigo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroAmigo.InserirNovoAmigo();
                    }
                    else if (opcao == "2")
                    {
                    telaCadastroAmigo.EditarAmigo();
                    }
                    else if (opcao == "3")
                    {
                      telaCadastroAmigo.ExcluirAmigo();
                    }
                    else if (opcao == "4")
                    {
                       telaCadastroAmigo.VisualizarAmigos("Tela");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
