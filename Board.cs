namespace ToesBot
{
    public enum PlayerTypes
    {
        O, X, None
    }

    public struct Move
    {
        public PlayerTypes Player;
        public int TargetSquare;

        public Move(PlayerTypes player, int targetSquare)
        {
            Player = player;
            TargetSquare = targetSquare;
        }

        public Move(string move)
        {
            Player = Board.ToType(move[0]);
            TargetSquare = (int)char.GetNumericValue(move[1]);
        }
    }

    public class Board
    {
        public PlayerTypes[] Squares = new PlayerTypes[9];
        public PlayerTypes Turn;
        public bool IsGameOver = false;

        public Board(PlayerTypes turn)
        {
            for (int i = 0; i < 9; i++) Squares[i] = PlayerTypes.None;
            Turn = turn;
        }

        public void Play(Move move)
        {
            if (!IsGameOver)
            {
                if (move.Player != Turn)
                    Console.WriteLine("It's not your turn.");
                else if (Squares[move.TargetSquare] != PlayerTypes.None)
                    Console.WriteLine("That square is not empty.");
                else
                {
                    Squares[move.TargetSquare] = move.Player;
                    ChangeTurn();
                }
            }
            GetWinner();
        }

        public void Play(Move[] moves)
        {
            if (!IsGameOver)
            {
                foreach (Move move in moves)
                    Play(move);
            }
            GetWinner();
        }

        public void Play(string[] moves)
        {
            if (!IsGameOver)
            {
                foreach (string move in moves)
                    Play(new Move(move));
            }
            GetWinner();
        }

        public void ChangeTurn()
        {
            Turn = Turn == PlayerTypes.O ? PlayerTypes.X : PlayerTypes.O;
        }

        public static char ToChar(PlayerTypes player)
        {
            return player switch
            {
                PlayerTypes.O => 'o',
                PlayerTypes.X => 'x',
                _ => '-',
            };
        }

        public static PlayerTypes ToType(char player)
        {
            return player switch
            {
                'o' => PlayerTypes.O,
                'x' => PlayerTypes.X,
                _ => PlayerTypes.None
            };
        }

        public void Print()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write("| {0} ", ToChar(Squares[i]));
                if ((i + 1) % 3 == 0) Console.WriteLine("\n+---+---+---");
            }
        }

        public PlayerTypes GetWinner()
        {
            if (!IsGameOver)
            {
                int[][] winConditions = [
                    // horizontal
                    [0, 1, 2],
                    [3, 4, 5],
                    [6, 7, 8],
                    // vertical
                    [0, 3, 6],
                    [1, 4, 7],
                    [2, 5, 8],
                    // diagonal
                    [0, 4, 8],
                    [2, 4, 6]
                ];

                foreach (int[] condition in winConditions)
                {
                    PlayerTypes[] toCheck = new PlayerTypes[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int idx = condition[i];
                        toCheck[i] = Squares[idx];
                    }

                    if ((toCheck[0] == toCheck[1]) && (toCheck[1] == toCheck[2]) && (toCheck[0] != PlayerTypes.None))
                    {
                        IsGameOver = true;
                        Console.WriteLine("{0} Won! The 'play' and 'botplay' commands are now unavailable.", toCheck[0]);
                        return toCheck[0];
                    }
                }

            }
            return PlayerTypes.None;
        }
    }
}