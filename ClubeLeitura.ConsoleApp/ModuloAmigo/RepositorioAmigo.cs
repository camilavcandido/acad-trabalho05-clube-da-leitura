namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo
    {
        public Amigo[] amigos;
        public int id;

        public void Inserir(Amigo amigo)
        {
            amigo.id = ++id;
            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = amigo;
        }

        public Amigo[] SelecionarTodos()
        {
            int quantidadeAmigos = ObterQtdAmigos();

            Amigo[] amigosCadastrados = new Amigo[quantidadeAmigos];
            int j = 0;
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    amigosCadastrados[j] = amigos[i];
                    j++;
                }
            }

            return amigosCadastrados;
        }

        public int ObterQtdAmigos()
        {
            int numeroAmigos = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                    numeroAmigos++;
            }

            return numeroAmigos;
        }

        public bool VerificarIdAmigoExiste(int idAmigo)
        {
            bool idAmigoExiste = false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].id == idAmigo)
                {
                    idAmigoExiste = true;
                    break;
                }
            }

            return idAmigoExiste;
        }

        public void Editar(int idAmigo, Amigo amigo)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].id == idAmigo)
                {
                    amigo.id = idAmigo;
                    amigos[i] = amigo;

                    break;
                }
            }
        }

        public void Excluir(int idAmigo)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i]!=null && amigos[i].id == idAmigo)
                {
                    amigos[i] = null;
                    break;
                }
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