using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    public GUISkin skin;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }
    }

    void OnGUI()
    {
        int sw = Screen.width;
        int sh = Screen.height;
        GUI.skin = skin;

        GUI.Label(new Rect(0, 0, sw, sh), "S H O O T I N G  G A M E", "Message");
        GUI.Label(new Rect(0, sh / 2, sw, sh / 2), "Click to Start", "Message");
        GUI.Label(new Rect(0, sh / 8 * 5, sw, sh / 2), "And shoot box in 1 minute!", "Message");
        
    }

}
