using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;
    public GameObject platforms;
    public string score;
    public int highScore;
    public Text secondsSurvivedUI;
    public Text highScoreGameOver;

    
    
    void Start()
    {
        HighScore score = SaveHighScore.LoadScore();
        if (score == null)
        {
            highScore = 0;
            SaveHighScore.SaveScore(this);
        }
        FindObjectOfType<PlayerMove>().OnPlayerDeath += OnGameOver; //makes OnGameOver happen on the OnPlayerDeath event
        
    }
    
    void OnGameOver()
    { 
        //change the screen
        gameOverScreen.SetActive(true);
        platforms.SetActive(false);

        //loads the previous high score
        HighScore score = SaveHighScore.LoadScore();
        highScore = score.highScoreData;

        //checks to see if a new high score was reached
        if (highScore < Mathf.RoundToInt(Time.timeSinceLevelLoad))
        {
            //saves a new high score
            highScore = Mathf.RoundToInt(Time.timeSinceLevelLoad);
            SaveHighScore.SaveScore(this);
        }

        //Display score for that round
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        //display the high score
        highScoreGameOver.text = highScore.ToString();
    }
}
