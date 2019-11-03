using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveHighScore
{
    
    public static void SaveScore(GameOver gameOver)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameOver.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        HighScore highScore = new HighScore(gameOver);

        formatter.Serialize(stream, highScore);
        stream.Close();
    }

    public static HighScore LoadScore()
    {
        string path = Application.persistentDataPath + "/gameOver.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HighScore highScore = formatter.Deserialize(stream) as HighScore;

            stream.Close();

            return highScore;
        } else
        {
            return null;
        }
    }
}
