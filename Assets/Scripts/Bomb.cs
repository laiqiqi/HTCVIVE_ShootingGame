using UnityEngine;
using UnityEngine.VR;
using System.Collections;
using UnityEngine.UI;


public class Bomb : MonoBehaviour
{

    // Use this for initialization

    public float initialVelocity = 100; //弾速の初速
    public GameObject bombPrefab; //弾丸のプレハブ
    public int limit = 3; 
    public GUISkin skin;
    public int chargeTime = -25;

    public Text bombText; //Text用変数


    void Start()
    {
        bombText.text = "Bomb: " + limit.ToString();
    }

    //毎フレーム呼ばれる関数
    void Update()
    {
       
        if (enabled == true)
        {

            SteamVR_TrackedObject trackedObject = GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackedObject.index);
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                if (limit != 0)
                {
                    chargeTime = chargeTime + 1;

                    if (chargeTime > 50)
                    {
                        //弾丸プレハブのインスタンス化
                        GameObject bomb = (GameObject)Instantiate(bombPrefab, transform.position, transform.rotation);
                        bomb.GetComponent<Rigidbody>().velocity = transform.forward * initialVelocity * 2;
                        limit--;
                        chargeTime = -25;

                        bombText.text = "Bomb: " + limit.ToString();

                    }
                }
            }

            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                chargeTime = -30;
            }

            if (Input.GetButton("Bomb") || Input.GetKey(KeyCode.X))
            {
                if (limit != 0)
                {
                    chargeTime = chargeTime + 1;
                    if (chargeTime > 50)
                    {
                        //弾丸プレハブのインスタンス化
                        GameObject bomb = (GameObject)Instantiate(bombPrefab, transform.position, transform.rotation);
                        bomb.GetComponent<Rigidbody>().velocity = transform.forward * initialVelocity * 2;
                        limit--;
                        chargeTime = -25;

                        bombText.text = "Bomb: " + limit.ToString();

                    }

                }
            }
        }
        else
        {
            return;
        }

    }

    void TimeUp()
    {
        enabled = false;
    }

}