using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gamestarter : MonoBehaviour {

    public GUISkin skin;
    private float timer;
    public Text orderText1; //Text用変数
    public Text orderText2;

    void Start()
    {
        timer = 3.5f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        
        orderText1.text = "Shoot Red Boxes!!";
        orderText2.text = Mathf.CeilToInt(timer).ToString();

        if (timer < 0.0f)
        {
            BroadcastMessage("StartGame");
            enabled = false;
            orderText1.text = "";
            orderText2.text = "";
        }
        
    }

    /*
    void OnGUI()
    {
        if (timer > 3.0 || timer <= 0.0) return;
        int sw = Screen.width;
        int sh = Screen.height;
        GUI.skin = skin;

        string text = Mathf.CeilToInt(timer).ToString();
        GUI.color = new Color(1, 1, 1, timer - Mathf.FloorToInt(timer));
        GUI.Label(new Rect(0, sh / 4, sw, sh / 2), text, "CountDown");

    }
    */
}
