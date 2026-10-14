public class Enemy
{
    public int Health { get; private set; }
    public int ScoreValue { get; private set; }

    public Enemy(int Health, int ScoreValue)
    {
        this.Health = Health;
        this.ScoreValue = ScoreValue;
    }
    public void LowerHealth()
    {
        --Health;
    }
}
