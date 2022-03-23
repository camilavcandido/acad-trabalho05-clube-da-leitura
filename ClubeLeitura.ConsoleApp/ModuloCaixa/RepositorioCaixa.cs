using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa
    {
        public Caixa[] caixas;
        public int numeroCaixa;

        public void Inserir(Caixa caixa)
        {
            caixa.numero = ++numeroCaixa;
            int posicaoVazia = ObterPosicaoVazia();
            caixas[posicaoVazia] = caixa;
        }

        public bool EtiquetaJaUtilizada(string etiquetaInformada)
        {
            bool etiquetaJaUtilizada = false;
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].etiqueta == etiquetaInformada)
                {
                    etiquetaJaUtilizada = true;
                    break;
                }
            }

            return etiquetaJaUtilizada;
        }

        public bool VerificarNumeroCaixaExiste(int numeroCaixa)
        {
            bool numeroCaixaEncontrado = false;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].numero == numeroCaixa)
                {
                    numeroCaixaEncontrado = true;
                    break;
                }
            }

            return numeroCaixaEncontrado;
        }

        public void Editar(int numeroSelecioando, Caixa caixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i].numero == numeroSelecioando)
                {
                    caixa.numero = numeroSelecioando;
                    caixas[i] = caixa;

                    break;
                }
            }
        }
        public void Excluir(int numeroCaixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i].numero == numeroCaixa)
                {
                    caixas[i] = null;
                    break;
                }
            }
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                    return i;
            }

            return -1;
        }
    }
}
