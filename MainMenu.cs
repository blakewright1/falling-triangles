using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreMain;
    private int highScore; 

    private void Start()
    {
        HighScore score = SaveHighScore.LoadScore();
        highScore = score.highScoreData;
        highScoreMain.text = highScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
