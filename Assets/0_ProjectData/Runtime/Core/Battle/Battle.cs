using System;

namespace OPR
{
    public class Battle
    {
        const int TOTAL_ROUNDS_NUM = 4;

        public Player CurrentPlayer { get; private set; }
        public int CurrentRound { get; private set; }

        public event Action<Player> OnTurnStarted;
        public event Action OnTurnEnded;

        public event Action<int> OnRoundStarted;
        public event Action OnRoundEnded;

        public event Action OnGameStarted;
        public event Action OnGameEnded;

        public Battle()
        {
        }

        public void Start()
        {
            // TODO roll-off for start first
            // CurrentPlayer = firstPlayer;
            
            OnGameStarted?.Invoke();
            OnRoundStarted?.Invoke(CurrentRound);
            OnTurnStarted?.Invoke(CurrentPlayer);
        }
        
        public void PassRound()
        {
            OnRoundEnded?.Invoke();

            if (CurrentRound - 1 == TOTAL_ROUNDS_NUM)
            {
                OnGameEnded?.Invoke();
                return;
            }

            CurrentRound++;
            OnRoundStarted?.Invoke(CurrentRound);
        }

        public void PassTurn()
        {
            OnTurnEnded?.Invoke();

            CurrentPlayer = CurrentPlayer switch
            {
                Player.P1 => Player.P2,
                Player.P2 => Player.P1,
                _ => throw new ArgumentOutOfRangeException()
            };

            OnTurnStarted?.Invoke(CurrentPlayer);
        }
    }
}