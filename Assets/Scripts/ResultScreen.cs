using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Scorekeeper))]
public class ResultScreen : MonoBehaviour
{

    public GUISkin skin;
    private Scorekeeper scorekeeper;
    private int state;

    private const int WAIT = 0;
    private const int TIMEUP = 1;
    private const int SHOWSCORE = 2;

    public Text resultText1; //Text用変数
    public Text resultText2; //Text用変数

    void Start()
    {
        scorekeeper = (Scorekeeper)GetComponent(typeof(Scorekeeper));

    }

    
    IEnumerator TimeUp()
    {
        state = TIMEUP;
        yield return new WaitForSeconds(4.0f);

        state = WAIT;
        yield return new WaitForSeconds(0.5f);
        
        state = SHOWSCORE;
        if (state == SHOWSCORE)
        {
            resultText1.text = "Your Score is " + scorekeeper.score.ToString();
            resultText1.color = Color.white;
            resultText2.text = "High Score is " + PlayerPrefs.GetInt("HighScore");
            resultText2.color = Color.white;
        }

        //while (!Input.GetMouseButtonDown(0)) yield return null;
        //SceneManager.LoadScene("Title");
    }

    /*
    void OnGUI()
    {
        int sw = Screen.width;
        int sh = Screen.height;
        GUI.skin = skin;

        if (state == TIMEUP)
        {
            Rect rect = new Rect(0, 0, sw, sh / 2);
            GUI.Label(rect, "Time UP!!", "Message");
        }
        else if (state == SHOWSCORE)
        {
            string scoreText = "Your Score is " + scorekeeper.score.ToString();
            GUI.Label(new Rect(0, sh / 4, sw, sh / 4), scoreText, "Message");
            GUI.Label(new Rect(0, sh / 2, sw, sh / 4), "Click to Exit", "Message");
            string highscoreText = "High Score is " + PlayerPrefs.GetInt("HighScore");
            GUI.Label(new Rect(0, sh / 3, sw, sh / 4), highscoreText, "Message");


        }
    }
    */

}
