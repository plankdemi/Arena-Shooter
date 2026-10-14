public class Player
{

    public int Health { get; private set; }
    public int Score { get; private set; }

    public Player()
    {
        Health = 10;
        Score = 0;

    }
    public void ReduceHealth()
    {
        --Health;
    }
    public void IncreaseScore(int Score)
    {
        this.Score += Score;
    }


}
