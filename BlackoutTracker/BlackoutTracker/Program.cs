using BlackoutTracker.Estrutura.Controller;
using BlackoutTracker.Estrutura.Model;
using System;
using System.ComponentModel;
using System.Data;

class Program
{
    static UsuarioController UsuarioController = new UsuarioController();
    static AlertaController AlertaController = new AlertaController();
    static void Main()
    {
        string nome;
        string senha;
        int tentativas = 0;
        int maxTentativas = 3;

        while (true)
        {
            // Tela de login
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║      Bem-Vindo ao BlackoutTracker     ║");
            Console.WriteLine("╠═══════════════════════════════════════╝");
            Console.WriteLine("║ Faça o login para entrar na aplicação");
            Console.WriteLine("║ ");
            Console.WriteLine("║ Nome:");
            Console.Write    ("╠ > ");
            nome = Console.ReadLine();
            Console.WriteLine("║ ");
            Console.WriteLine("║ Senha:");
            Console.Write    ("╠ > ");
            senha = Console.ReadLine();

            // Verificação
            if (UsuarioController.validarUsuarioSenha(nome, senha))
            {
                Console.WriteLine("╠═══════════════════════════════════════╗");
                Console.WriteLine("║           Login bem-sucedido          ║");
                Console.WriteLine("╚═══════════════════════════════════════╝\n");
                tentativas = 0;
                if (UsuarioController.GetTipo(UsuarioController.GetID()) == "Morador")
                {
                    MostrarMenuMorador();
                }
                else
                {
                    MostrarMenuTecnico();
                }
                    
                break;
            }
            else
            {
                tentativas++;
                Console.WriteLine("╠═══════════════════════════════════════╗");
                Console.WriteLine("║      Usuário ou senha incorretos      ║");
                if (tentativas == maxTentativas)
                {
                    Console.WriteLine("║   Limite de tentativas ultrapassado   ║");
                    Console.WriteLine("╠═══════════════════════════════════════╣");
                    Console.WriteLine("║         Fechando aplicação...         ║");
                    Console.WriteLine("╚═══════════════════════════════════════╝\n");
                    break; // Encerra o programa após 3 tentativas
                }
                Console.WriteLine("╚═══════════════════════════════════════╝\n");
            }
        }
    }

    static void MostrarMenuMorador()
    {
        int ID = UsuarioController.GetID();
        int opcao;
        do
        {
            Console.WriteLine("╔═════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        MENU                         ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════╝");

            while (true)
            {
                Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                Console.WriteLine("║ Escolha uma das opções                              ║");
                Console.WriteLine("║ (Digite o número correspondente)                    ║");
                Console.WriteLine("║                                                     ║");
                Console.WriteLine("║ 1 - Registrar Alerta                                ║");
                Console.WriteLine("║ 2 - Ver comunicados no meu bairro                   ║");
                Console.WriteLine("║ 0 - Sair                                            ║");
                Console.WriteLine("╠═════════════════════════════════════════════════════╝");
                Console.Write    ("║ > ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out opcao) && (opcao >= 0 && opcao <= 2))
                    break;
                Console.WriteLine("║ ");
                Console.WriteLine("║ Entrada inválida. Digite um valor válido.");

            }

            Console.WriteLine();

            switch (opcao)
            {
                case 1:
                    string Tipo_NewAlerta;
                    string Descricao_NewAlerta;
                    string Bairro_NewAlerta;
                    string Data_NewAlerta = DateTime.Now.ToString("dd-MM-yyyy");
                    string Hora_NewAlerta = DateTime.Now.ToString("HH:mm:ss");

                    Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                   Registrar Alerta                  ║");
                    Console.WriteLine("╠═════════════════════════════════════════════════════╝");


                    while (true)
                    {
                        Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                        Console.WriteLine("║ Qual o tipo de acontecimeto?                        ║");
                        Console.WriteLine("║ (Digite o número correspondente)                    ║");
                        Console.WriteLine("║                                                     ║");
                        Console.WriteLine("║ 1 - Energia                                         ║");
                        Console.WriteLine("║ 2 - Alagamento                                      ║");
                        Console.WriteLine("║ 3 - Caminho obstruido                               ║");
                        Console.WriteLine("║ 4 - Outro                                           ║");
                        Console.WriteLine("╠═════════════════════════════════════════════════════╝");
                        Console.Write    ("║ > ");
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out opcao) && (opcao >= 1 && opcao <= 4))
                        {
                            switch (opcao)
                            {
                                case 1:
                                    Tipo_NewAlerta = "Energia";
                                    break;
                                case 2:
                                    Tipo_NewAlerta = "Alagamento";
                                    break;
                                case 3:
                                    Tipo_NewAlerta = "Caminho obstruido";
                                    break;
                                case 4:
                                    Tipo_NewAlerta = "Outro";
                                    break;
                                default:
                                    Tipo_NewAlerta = "Outro";
                                    break;
                            }
                            break;
                        }
                        Console.WriteLine("║ ");
                        Console.WriteLine("║ Entrada inválida. Digite um valor válido.");
                    }

                    Console.WriteLine("╠══════════════════════════════════════════════════════");
                    Console.WriteLine("║ Descreva o que aconteceu: ");
                    Console.WriteLine("║ ");
                    Console.Write    ("║ > ");
                    Descricao_NewAlerta = Console.ReadLine();
                    Console.WriteLine("╠══════════════════════════════════════════════════════");
                    Console.WriteLine("║ Em qual bairro isso aconteceu? ");
                    Console.WriteLine("║ ");
                    Console.Write    ("║ > ");
                    Bairro_NewAlerta = Console.ReadLine();
                    Console.WriteLine("╠═════════════════════════════════════════════════════╗");

                    if (AlertaController.NewAlerta(Tipo_NewAlerta, Descricao_NewAlerta, Bairro_NewAlerta, Data_NewAlerta, Hora_NewAlerta))
                    {
                        Console.WriteLine("║ Alerta registrado com sucesso!                      ║");
                        Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                    }
                    else
                    {
                        Console.WriteLine("║ Falha ao registrar o alerta. Tente novamente.       ║");
                        Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                    }

                    break;
                case 2:
                    string BairroUsuario = UsuarioController.GetBairro(ID);
                    List<Alerta> AlertaLista = AlertaController.GetAlertasPorBairro(BairroUsuario);
                    Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                Alertas no seu Bairro                ║");
                    Console.WriteLine("╠═════════════════════════════════════════════════════╝");
                    Console.WriteLine($"║ {BairroUsuario}");
                    if (AlertaLista.Count == 0)
                    {
                        Console.WriteLine("╠══════════════════════════════════════════════════════");
                        Console.WriteLine("║ Nenhum alerta encontrado no seu bairro");
                        Console.WriteLine("╠══════════════════════════════════════════════════════");
                    }
                    else 
                    { 
                        foreach (var alerta in AlertaLista)
                        {
                            Console.WriteLine("╠══════════════════════════════════════════════════════");
                            Console.WriteLine($"║ Tipo: {alerta.Tipo}");
                            Console.WriteLine($"║ Descrição: {alerta.Descricao}");
                            Console.WriteLine($"║ Data: {alerta.Data}");
                            Console.WriteLine($"║ Hora: {alerta.Hora}");
                        }
                        Console.WriteLine("╚══════════════════════════════════════════════════════");
                    }
                    break;
                case 0:
                    Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                 Fechando programa...                ║");
                    Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                    break;
                default:
                    Console.WriteLine("Opção inválida.\n");
                    break;
            }

        } while (opcao != 0);
    }

    static void MostrarMenuTecnico()
    {
        int ID = UsuarioController.GetID();
        int opcao;
        do
        {
            Console.WriteLine("╔═════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        MENU                         ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════╝");

            while (true)
            {
                Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                Console.WriteLine("║ Escolha uma das opções                              ║");
                Console.WriteLine("║ (Digite o número correspondente)                    ║");
                Console.WriteLine("║                                                     ║");
                Console.WriteLine("║ 1 - Registrar Alerta                                ║");
                Console.WriteLine("║ 2 - Ver todos os Alertas                            ║");
                Console.WriteLine("║ 3 - Concluir Alerta                                 ║");
                Console.WriteLine("║ 0 - Sair                                            ║");
                Console.WriteLine("╠═════════════════════════════════════════════════════╝");
                Console.Write    ("║ > ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out opcao) && (opcao >= 0 && opcao <= 3))
                    break;
                Console.WriteLine("║ ");
                Console.WriteLine("║ Entrada inválida. Digite um valor válido.");

            }

            Console.WriteLine();

            switch (opcao)
            {
                case 1:
                    string Tipo_NewAlerta;
                    string Descricao_NewAlerta;
                    string Bairro_NewAlerta;
                    string Data_NewAlerta = DateTime.Now.ToString("dd-MM-yyyy");
                    string Hora_NewAlerta = DateTime.Now.ToString("HH:mm:ss");

                    Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                   Registrar Alerta                  ║");
                    Console.WriteLine("╠═════════════════════════════════════════════════════╝");


                    while (true)
                    {
                        Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                        Console.WriteLine("║ Qual o tipo de acontecimeto?                        ║");
                        Console.WriteLine("║ (Digite o número correspondente)                    ║");
                        Console.WriteLine("║                                                     ║");
                        Console.WriteLine("║ 1 - Energia                                         ║");
                        Console.WriteLine("║ 2 - Alagamento                                      ║");
                        Console.WriteLine("║ 3 - Caminho obstruido                               ║");
                        Console.WriteLine("║ 4 - Outro                                           ║");
                        Console.WriteLine("╠═════════════════════════════════════════════════════╝");
                        Console.Write("║ > ");
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out opcao) && (opcao >= 1 && opcao <= 4))
                        {
                            switch (opcao)
                            {
                                case 1:
                                    Tipo_NewAlerta = "Energia";
                                    break;
                                case 2:
                                    Tipo_NewAlerta = "Alagamento";
                                    break;
                                case 3:
                                    Tipo_NewAlerta = "Caminho obstruido";
                                    break;
                                case 4:
                                    Tipo_NewAlerta = "Outro";
                                    break;
                                default:
                                    Tipo_NewAlerta = "Outro";
                                    break;
                            }
                            break;
                        }
                        Console.WriteLine("║ ");
                        Console.WriteLine("║ Entrada inválida. Digite um valor válido.");
                    }

                    Console.WriteLine("╠══════════════════════════════════════════════════════");
                    Console.WriteLine("║ Descreva o que aconteceu: ");
                    Console.WriteLine("║ ");
                    Console.Write("║ > ");
                    Descricao_NewAlerta = Console.ReadLine();
                    Console.WriteLine("╠══════════════════════════════════════════════════════");
                    Console.WriteLine("║ Em qual bairro isso aconteceu? ");
                    Console.WriteLine("║ ");
                    Console.Write("║ > ");
                    Bairro_NewAlerta = Console.ReadLine();
                    Console.WriteLine("╠═════════════════════════════════════════════════════╗");

                    if (AlertaController.NewAlerta(Tipo_NewAlerta, Descricao_NewAlerta, Bairro_NewAlerta, Data_NewAlerta, Hora_NewAlerta))
                    {
                        Console.WriteLine("║ Alerta registrado com sucesso!                      ║");
                        Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                    }
                    else
                    {
                        Console.WriteLine("║ Falha ao registrar o alerta. Tente novamente.       ║");
                        Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                    }

                    break;
                case 2:
                    List<Alerta> AlertaLista = AlertaController.GetAllAlertasPorBairro();
                    Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                       Alertas                       ║");
                    Console.WriteLine("╠═════════════════════════════════════════════════════╝");
                    if (AlertaLista.Count == 0)
                    {
                        Console.WriteLine("╠══════════════════════════════════════════════════════");
                        Console.WriteLine("║ Nenhum alerta encontrado");
                        Console.WriteLine("╠══════════════════════════════════════════════════════");
                    }
                    else
                    {
                        foreach (var alerta in AlertaLista)
                        {
                            Console.WriteLine("╠══════════════════════════════════════════════════════");
                            Console.WriteLine($"║ ID: {alerta.ID}");
                            Console.WriteLine($"║ Tipo: {alerta.Tipo}");
                            Console.WriteLine($"║ Bairro: {alerta.Bairro}");
                            Console.WriteLine($"║ Descrição: {alerta.Descricao}");
                            Console.WriteLine($"║ Data: {alerta.Data}");
                            Console.WriteLine($"║ Hora: {alerta.Hora}");
                        }
                        Console.WriteLine("╚══════════════════════════════════════════════════════");
                    }
                    break;
                case 3:
                    int AlertaID_Remover;
                    Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                   Concluir Alerta                   ║");
                    Console.WriteLine("╠═════════════════════════════════════════════════════╝");
                    while (true)
                    {

                        Console.WriteLine("╠══════════════════════════════════════════════════════");
                        Console.WriteLine("║ Digite o ID do alerta que foi finalizado:");
                        Console.WriteLine("║ (Digite 0 para voltar ao Menu)");
                        Console.WriteLine("║ ");
                        Console.Write("║ > ");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out AlertaID_Remover))
                        {
                            Console.WriteLine("║ ");
                            Console.WriteLine("║ Digite um valor que seja um digito");
                            Console.WriteLine("║ ");
                            Console.WriteLine("║ Caso não saiba qual o ID, volte para o menu e");
                            Console.WriteLine("║ procure em: Ver todos os Alertas");
                            continue;
                        }
                        if (AlertaID_Remover == 0)
                        {
                            Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                Voltando para o Menu...              ║");
                            Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                            break;
                        }
                        if (!AlertaController.AlertaExiste(AlertaID_Remover))
                        {
                            Console.WriteLine("║ ");
                            Console.WriteLine("║ ID não encontrado");
                            Console.WriteLine("║ ");
                            Console.WriteLine("║ Caso não saiba qual o ID, volte para o menu e");
                            Console.WriteLine("║ procure em: Ver todos os Alertas");
                            continue;
                        }
                        if (AlertaController.DeleteAlerta(AlertaID_Remover))
                        {
                            Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                            Console.WriteLine("║           Alerta registrado com sucesso!            ║");
                            Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                            break;
                        }

                    }
                    break;

                case 0:
                    Console.WriteLine("╠═════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                 Fechando programa...                ║");
                    Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                    break;
                default:
                    Console.WriteLine("Opção inválida.\n");
                    break;
            }

        } while (opcao != 0);
    }
}
