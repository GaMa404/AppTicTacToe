# AppTicTacToe (Jogo da Velha)

Jogo da velha pra dois jogadores no mesmo celular. Alterna entre X e O, detecta vitória e empate, e mantém um placar na sessão.

> A pasta se chama `AppTicTacToe`, mas o projeto interno é `AppJogoDaVelha`.

## Pra que serve

É um jogo da velha clássico, local, sem internet. Dois jogadores revezam tocando nas células do tabuleiro 3x3. Quando alguém ganha ou dá velha, o tabuleiro reinicia automaticamente, mas o placar de vitórias fica acumulado até fechar o app.

## Como funciona

### Fluxo de uma partida

1. O jogador **X** começa
2. Cada toque numa célula vazia marca X ou O e desabilita aquele botão
3. Depois de cada jogada, o app verifica:
   - **Vitória:** alguma das 8 combinações (3 linhas, 3 colunas, 2 diagonais) tem o mesmo símbolo
   - **Empate:** 9 jogadas sem vencedor ("deu velha")
4. Se houver vitória ou empate, mostra um alerta, atualiza o placar e reinicia o tabuleiro
5. O turno alterna entre X e O

### Interface

- Tabuleiro 3x3 com botões grandes (fonte 80)
- Grade desenhada com `BoxView` brancos sobre fundo com gradiente roxo/vermelho
- Placar no rodapé: `X: 0 | O: 0`
- Barra de navegação do Shell fica oculta

### Lógica principal

O estado do jogo fica em campos simples no code-behind:

- `turn` — jogador atual ("X" ou "O")
- `countPlays` — jogadas da partida atual
- `countXWins` / `countOWins` — placar da sessão
- `winConditions` — matriz com as 8 combinações vencedoras

## Stack

- **.NET MAUI 10** com C# e XAML
- **Arquitetura:** code-behind (sem MVVM)
- **Navegação:** Shell com `MainPage` como rota única

## Estrutura do projeto

```
AppTicTacToe/
├── AppJogoDaVelha.slnx
└── AppJogoDaVelha/
    ├── MainPage.xaml(.cs)     # UI + toda a lógica do jogo
    ├── AppShell.xaml          # NavBar oculta
    ├── MauiProgram.cs
    ├── App.xaml(.cs)          # Janela 350x700
    ├── Resources/
    └── Platforms/
```

Não tem Models, ViewModels, Services nem outras páginas.

## Plataformas

| SO de build | O que compila |
|-------------|---------------|
| Linux | Android |
| macOS | Android, iOS, Mac Catalyst |
| Windows | Todas |

App ID: `com.companyname.appjogodavelha`

## Dependências

- `Microsoft.Maui.Controls`
- `Microsoft.Extensions.Logging.Debug`

## Como rodar

```bash
cd AppTicTacToe
dotnet restore AppJogoDaVelha.slnx
dotnet build AppJogoDaVelha/AppJogoDaVelha.csproj
dotnet build -t:Run -f net10.0-android AppJogoDaVelha/AppJogoDaVelha.csproj
```

Precisa do .NET 10 SDK com workload MAUI.

## O que o app não faz

- Modo contra computador (IA)
- Multiplayer online
- Salvar placar entre sessões
- Navegação entre telas

## Observações

- Células ocupadas ficam desabilitadas, então não dá pra jogar duas vezes no mesmo lugar
- O placar some quando o app é fechado
- A janela é fixada em 350x700 no `App.xaml.cs`

## Ideias de evolução

Modo single player com IA, persistência do placar, animação de vitória, tema escuro, modo online.
