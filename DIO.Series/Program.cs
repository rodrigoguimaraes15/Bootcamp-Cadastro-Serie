using System;

namespace DIO.Series
{
    class Program
    {   
            static SerieRepositorio repositorio = new SerieRepositorio();
            static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
                
        static void Main(string[] args)
        {               
                // Antes do programa iniciar, pede a senha de validação do usuario
                Console.WriteLine("Informe a senha!");

                int senha = int.Parse(Console.ReadLine());

                Senha usuario = new Senha(senha);

                usuario.validarSenha();
                

                Console.WriteLine("1 - Séries ou 2 - Filmes"); 
                int opcao = int.Parse(Console.ReadLine());

                if(opcao == 1)
                {
                    Console.WriteLine("------------- Opção de séries selecionado. -----------");
                    string opcaoUsuario = ObterOpcaoUsuario();            

                        while(opcaoUsuario.ToUpper() != "X")
                        {
                            switch(opcaoUsuario)
                            {
                                    case "1":
                                        ListarSeries();
                                        break;
                                    case "2":
                                        InserirSerie();
                                        break;
                                    case "3":
                                        AtualizarSerie();
                                        break;
                                    case "4":
                                        ExcluirSerie();
                                        break;
                                    case "5":
                                        VisualizarSerie();
                                        break;
                                    case "C":
                                        Console.Clear();
                                        break;

                                    default:
                                        throw new ArgumentOutOfRangeException();  
                            }

                        opcaoUsuario = ObterOpcaoUsuario();
                    }
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadLine();            
                
                } 
                if(opcao == 2)
                {
                Console.WriteLine(" ---------- Opção de filmes selecionado. -----------");
                   string opcaoUsuario = ObterOpcaoUsuario();            

                        while(opcaoUsuario.ToUpper() != "X")
                        {
                            switch(opcaoUsuario)
                            {
                                    case "1":
                                        ListarFilmes();
                                        break;
                                    case "2":
                                        InserirFilme();
                                        break;
                                    case "3":
                                        AtualizarFilme();
                                        break;
                                    case "4":
                                        ExcluirFilme();
                                        break;
                                    case "5":
                                        VisualizarFilme();
                                        break;
                                    case "C":
                                        Console.Clear();
                                        break;

                                    default:
                                        throw new ArgumentOutOfRangeException();  
                            }
                            opcaoUsuario = ObterOpcaoUsuario();
                        }
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadLine();

                }
                
                            
                
                // Opção para realizar o CRUD
                
            // ------------------------------- Visualizar Series/Filmes -----------------------------------------
            static void VisualizarSerie()
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                
                var serie = repositorio.RetornaPorId(indiceSerie);

                Console.WriteLine(serie); 
            }

            static void VisualizarFilme()
            {
                Console.Write("Digite o id da filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                
                var filme = repositorioFilme.RetornaPorId(indiceFilme);

                Console.WriteLine(filme); 
            }


            // ---------------------------- Excluir Serie / Filme ----------------------------------------
            static void ExcluirSerie()
            {                
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());                   
                
                repositorio.Exclui(indiceSerie);
            }

            static void ExcluirFilme()
            {                
                Console.Write("Digite o id da filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());                   
                
                repositorioFilme.Exclui(indiceFilme);
            }




            //------------------------------ Atualizar Series / Filme --------------------------------
            static void AtualizarSerie()
            {
                Console.Write("Digite o id da serie: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o genêro entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Titulo da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de Inicio da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie atualizaSerie = new Serie(id: indiceSerie,
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano: entradaAno,
                                                descricao: entradaDescricao);   
                repositorio.Atualiza(indiceSerie, atualizaSerie);
            }

            static void AtualizarFilme()
            {
                Console.Write("Digite o id da filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o genêro entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Titulo da Filme: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de Inicio da Filme: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição da Filme: ");
                string entradaDescricao = Console.ReadLine();

                Filme atualizaFilme = new Filme(id: indiceFilme,
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano: entradaAno,
                                                descricao: entradaDescricao);   
                repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
            }

            
            // --------------------------- Listar Series / Filmes -------------------------------
            static void ListarSeries()
            {
                Console.WriteLine("Listar séries");

                var lista = repositorio.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma série cadastrada.");
                    return;
                }

                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                
                    Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));                
                    
                }
            }

            static void ListarFilmes()
            {
                Console.WriteLine("Listar Filmes");

                var lista = repositorioFilme.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhume Filme cadastrado.");
                    return;
                }

                foreach (var filme in lista)
                {
                    var excluido = filme.retornaExcluido();
                
                    Console.WriteLine("#ID {0}: - {1} - {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : ""));                
                    
                }
            }


            // ----------------------------- Inserir Serie / Filme ----------------------------

            static void InserirSerie()
            {
                Console.WriteLine("Inserir nova série");

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
                }
                Console.Write("Digite o genero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Titulo da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de Inicio da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,                                            
                                            descricao: entradaDescricao,
                                            ano: entradaAno);
                repositorio.Insere(novaSerie);
            }

            static void InserirFilme()
            {
                Console.WriteLine("Inserir novo Filme");

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
                }
                Console.Write("Digite o genero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Titulo do Filme: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de Inicio do Filme: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a descrição do Filme: ");
                string entradaDescricao = Console.ReadLine();

                Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            ano: entradaAno
                                            );
                repositorioFilme.Insere(novoFilme);
            }

            // ----------------------------------- Menu -------------------------------------
            static string ObterOpcaoUsuario()
            {
                
                Console.WriteLine();
                Console.WriteLine("DIO Sessão streamer Filmes e Series a sua disposição!!!");
                Console.WriteLine("Informe a opção desejada:");

                Console.WriteLine("1 - Listar séries/filme");
                Console.WriteLine("2 - Inserir nova série/filme");
                Console.WriteLine("3 - Atualizar série/filme");
                Console.WriteLine("4 - Excluir série/filme");
                Console.WriteLine("5 - Visualizar série/filme");
                Console.WriteLine("C - Limpar Tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }
        }
    }
}
