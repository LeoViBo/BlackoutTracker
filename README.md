# BlackoutTracker

## Objetivo do Projeto

O **BlackoutTracker** é uma aplicação desenvolvida em C# com banco de dados Oracle, destinada a monitorar e gerenciar falhas de energia e outros incidentes em diferentes bairros de uma cidade. O sistema tem como objetivo facilitar o registro, acompanhamento e solução rápida desses problemas, minimizando o impacto cibernético e operacional causado por falhas de energia.

---

## Requisitos do Projeto

### Requisitos Funcionais

1. Registro de falhas/alertas com informações detalhadas (tipo, bairro, descrição, data e hora).
2. Visualização e consulta de alertas por bairro.
3. Remoção de alertas por ID.
4. Geração de relatórios simples com o status atual dos alertas.
5. Registro de logs para acompanhar operações realizadas.
6. Validação robusta de entradas para garantir a integridade dos dados.

### Requisitos Não Funcionais

- A aplicação deve ser segura, garantindo que apenas usuários autorizados possam alterar dados.
- Interface amigável via console, facilitando a interação.
- Código modular e organizado para facilitar manutenção e extensão.
- Desempenho adequado para consultas rápidas ao banco.
- Tratamento de exceções para entradas inválidas (datas erradas, IDs inválidos, etc.).

---

## Funcionalidades Implementadas

1. **Registrar alerta** — inclusão de falhas no sistema.
2. **Visualizar alertas** — listar todos os alertas cadastrados.
3. **Excluir alerta** — remover alertas por ID.
4. **Gerar relatório de status** — resumo dos alertas ativos por bairro.
5. **Log de eventos** — gravação das operações realizadas para auditoria.
6. **Validação e tratamento de erros** — uso extensivo de `try-catch` para entrada de dados inválidos e tratamento de exceções.

---

## Fluxograma (Descrição)

- Usuário acessa o sistema e escolhe uma opção no menu.
- Para registrar um alerta, insere dados validados (tipo, bairro, descrição, data e hora).
- Sistema salva o alerta no banco.
- Usuário pode listar todos os alertas existentes.
- Usuário pode excluir alertas pelo ID, com confirmação.
- Em cada operação, logs são gravados.
- Caso ocorra erro na entrada, mensagens claras orientam o usuário.

*(Nota: fluxogramas gráficos podem ser adicionados em documentação extra para visualização.)*

---

## Tecnologias Utilizadas

- **C# (.NET Core/Framework)**: linguagem e ambiente de desenvolvimento principal.
- **Oracle Database**: armazenamento e gerenciamento dos dados.
- **Oracle.ManagedDataAccess.Client**: driver para conexão entre C# e Oracle.
- **Console Application**: interface de usuário simples e direta.
- **GitHub**: versionamento e publicação do projeto.

---

## Regras de Negócio

- IDs das tabelas são gerados automaticamente via sequências e triggers no Oracle.
- Alertas devem conter informações completas e validadas.
- Somente alertas existentes podem ser removidos.
- Data e hora devem seguir formato específico (data em `YYYY-MM-DD` e hora em `HH:mm:ss`).
- Logs devem ser mantidos para qualquer ação de inserção, remoção ou erro.
- A aplicação deve validar tipos e formatos, impedindo dados inválidos no banco.

---

## Boas Práticas Aplicadas

- **Classes coesas** com responsabilidades únicas (exemplo: DAO, Controller, Model separados).
- **Encapsulamento** usado para proteger dados das classes.
- **Herança** aplicada para organização e reutilização (quando aplicável).
- Métodos com **nomes claros**, parâmetros explícitos e retornos definidos.
- Código limpo e indentado, com comentários explicativos em pontos importantes.
- Tratamento de exceções (`try-catch`) para entradas inválidas como números, datas, strings vazias, entre outros.
- Reuso de lógica para evitar duplicações.

---

## Acessos

Nome: Gabi - Senha: 123  
Nome: Rafa - Senha: 456  

---

## Membros

Gabriela Trevisan da Silva (RM99500).
Rafael Henrique Pedra Franck (RM550875).  
