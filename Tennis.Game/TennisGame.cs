namespace Tennis.Game
{
    public class TennisGame : ITennisGame
    {
        private int score1;
        private int score2;
        private readonly string player1Name;
        private readonly string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName.Equals(player1Name, StringComparison.OrdinalIgnoreCase))
                score1++;
            else if (playerName.Equals(player2Name, StringComparison.OrdinalIgnoreCase))
                score2++;
        }

        public string GetScore()
        {
            if (score1 == score2)
            {
                return GetEqualScore();
            }
            else if (score1 >= 4 || score2 >= 4)
            {
                return GetAdvantageOrWinScore();
            }
            else
            {
                return GetRegularScore();
            }
        }

        private string GetEqualScore()
        {
            return score1 switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }

        private string GetAdvantageOrWinScore()
        {
            var minusResult = score1 - score2;
            return minusResult switch
            {
                1 => "Advantage " + player1Name,
                -1 => "Advantage " + player2Name,
                >= 2 => "Win for " + player1Name,
                _ => "Win for " + player2Name
            };
        }

        private string GetRegularScore()
        {
            var score = "";
            for (var i = 1; i < 3; i++)
            {
                var tempScore = (i == 1) ? score1 : score2;
                score += (i > 1) ? "-" : "";

                score += tempScore switch
                {
                    0 => "Love",
                    1 => "Fifteen",
                    2 => "Thirty",
                    3 => "Forty",
                    _ => throw new InvalidOperationException("Invalid score")
                };
            }
            return score;
        }
    }
}
