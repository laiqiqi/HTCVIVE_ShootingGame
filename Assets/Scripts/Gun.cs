using UnityEngine;
using UnityEngine.VR;
using System.Collections;
using UnityEngine.UI;


public class Gun : MonoBehaviour {

    // Use this for initialization

    public float initialVelocity = 100000; //弾速の初速
    public GameObject bulletPrefab; //弾丸のプレハブ
    public int BuN = 200;
    public GUISkin skin;
    public int reloadTime;

    public Text gunText; //Text用変数

    void Start()
    {
        gunText.text = "Bullet: " + BuN.ToString();
    }

    //毎フレーム呼ばれる関数
    void Update()
    {

        // Rキーで位置トラッキングをリセットする
        if (Input.GetKeyDown(KeyCode.R))
        {
            SteamVR.instance.hmd.ResetSeatedZeroPose();
        }

        if (BuN == 0)//自動リロード
        {
            gunText.text = "Reloading...";
            gunText.color = Color.red;
            reloadTime = reloadTime + 1;
            if (reloadTime > 120)
            {
                BuN = 200;
                gunText.text = "Bullet: " + BuN.ToString();
                gunText.color = Color.white;
                reloadTime = 0;
            }
            
        }

        if (enabled == true)
        {

            SteamVR_TrackedObject trackedObject = GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackedObject.index);
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                if (BuN != 0)
                {
                    //弾丸プレハブのインスタンス化
                    GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);

                    bullet.GetComponent<Rigidbody>().velocity = transform.forward * initialVelocity * 3;
                    BuN--;
                    gunText.text = "Bullet: " + BuN.ToString();
                    gunText.color = Color.white;

                }

            }

            if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) //手動リロード
            {

                if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
                {
                    if (BuN != 0)
                    {
                        //弾丸プレハブのインスタンス化
                        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);

                        bullet.GetComponent<Rigidbody>().velocity = transform.forward * initialVelocity * 3;
                        BuN--;
                        gunText.text = "Bullet: " + BuN.ToString();
                        gunText.color = Color.white;

                    }

                }

                else
                {
                    BuN = BuN + 1;
                    gunText.text = "Bullet: " + BuN.ToString();
                    gunText.color = Color.white;
                    if (BuN >= 200)
                    {
                        BuN = 200;
                        gunText.text = "Bullet: " + BuN.ToString();
                        gunText.color = Color.white;
                    }
                }

            }
        } else
        {
            return;
        }



            if (Input.GetButton("Bullet")|| Input.GetKey(KeyCode.Z)) //selectで発射
        {
            
            if(BuN != 0)
            {
                //弾丸プレハブのインスタンス化
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody>().velocity = transform.forward * initialVelocity * 2;
                BuN--;
                gunText.text = "Bullet: " + BuN.ToString();
                gunText.color = Color.white;
            }
           
        }

    }

    void TimeUp()
    {
        enabled = false;
    }

}