namespace ToesBot
{
    public class Engine
    {
        public static bool DidSomeoneWin(Board state)
        {
            return state.GetWinner() != PlayerTypes.None;
        }

        public static int MiniMax(Board state, PlayerTypes botPlayer)
        {
            if (DidSomeoneWin(state))
            {
                return (state.GetWinner() == botPlayer) ? 10 : -10;
            }

            if 
        }
    }
}