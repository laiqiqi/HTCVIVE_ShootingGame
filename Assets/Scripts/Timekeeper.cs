using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timekeeper : MonoBehaviour {

    public float gameLength;
    public float elapsedTime;
    [HideInInspector]
    public int TimeCount;
    public GUISkin skin;

    public Text timeText; //Text用変数

    void Update ()
    {
        elapsedTime += Time.deltaTime;
        int counttime = (int)gameLength - (int)elapsedTime;
        if (elapsedTime < 0)
        {
            timeText.text = "Time: " + (int)gameLength;
        } else
        {
            timeText.text = "Time: " + counttime.ToString();
        }

        if (counttime <= 0)
        {
            BroadcastMessage("TimeUp");
            GameObject.FindWithTag("MainCamera").SendMessage("TimeUp");
            timeText.text = "Time Up!!";

            enabled = false;
        }

        

    }

    void StartGame()
    {
        enabled = true;
    }

    /*
    void OnGUI()
    {
        //表示する文字
        int counttime = (int)elapsedTime;
        string countText = "TIME: " + counttime.ToString();

        //描画領域の設定
        int sw = Screen.width;
        int sh = Screen.height;
        Rect rect = new Rect(0, sh/12, sw / 2, sh/4);
        GUI.skin = skin;

        //ラベルの描画
        GUI.Label(rect, countText, "TimeCount");
    }
    */

}
