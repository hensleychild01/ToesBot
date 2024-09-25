namespace ToesBot
{
    public class Engine
    {
        public static bool DidSomeoneWin(Board state)
        {
            return state.GetWinner() != PlayerTypes.None;
        }

        public static int EvaluateWin(Board state, PlayerTypes forWho)
        {
            PlayerTypes winner = state.GetWinner();

            if (winner == PlayerTypes.None) return 0;

            return (winner == forWho) ? 1 : -1;
        }

        // public static int MiniMax(Board state) {

        // }
    }
}