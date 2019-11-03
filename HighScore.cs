[System.Serializable]
public class HighScore
{
    public int highScoreData;

    public HighScore(GameOver gameOver)
    {
        highScoreData = gameOver.highScore;
    }
   
}
