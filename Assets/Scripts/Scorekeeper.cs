using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Scorekeeper : MonoBehaviour {

    [HideInInspector]
    public int score;
    public GUISkin skin; //スキンの情報をInspecterビューから受け取る

    public Text scoreText; //Text用変数

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    /*
    void OnGUI()
    {
        //表示する文字
        string scoreText = "SCORE: " + score.ToString();

        //描画領域の設定
        int sw = Screen.width;
        int sh = Screen.height;
        Rect rect = new Rect(0, 0, sw / 2, sh / 4);
        GUI.skin = skin;

        //ラベルの描画
        GUI.Label(rect, scoreText, "Score");
    }
    */

}
