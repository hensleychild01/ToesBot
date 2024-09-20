namespace ToesBot
{
    public class Program
    {
        public static void Main()
        {
            Board board;

            while (true)
            {
                Console.Write("Who starts? ");
                string? choice = Console.ReadLine();

                if (choice != null)
                {
                    board = new Board(Board.ToType(choice[0]));
                    break;
                }
            }

            while (true)
            {
                string? cmd = Console.ReadLine();
                if (cmd == null) break;

                string head = cmd.Split(' ')[0];
                string[] args = cmd.Split(' ')[1..];

                switch (head)
                {
                    case "print": board.Print(); break;
                    case "play": board.Play(args); break;
                    case "botplay": break;

                    default: Console.WriteLine("Command '{0}' is unknown.", head); break;
                }
            }
        }
    }
}