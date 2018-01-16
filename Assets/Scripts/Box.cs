using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

    public string colorName;
    public GameObject explosionPrehab; //プレハブを受け取る関数
    private bool damaged; //ダメージフラグ
    private bool ApplyorNot; //加点・減点をするかしないか
    private float killTimer; //タイマー

    void Awake()
    {
        damaged = false;
    }

    //送ったメッセージと同じ名前の関数を定義する
    void ApplyDamage()
    {
        //命中したら爆発までのカウントをスタート
        if (!damaged)
        {
            damaged = true;
            ApplyorNot = true;
            killTimer = 0.3f;

            //上向きの力を加える
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 15.0f, ForceMode.Impulse);
                
        }
    }

    void NotDamage()
    {
        //命中したら爆発までのカウントをスタート
        if (!damaged)
        {
            damaged = true;
            ApplyorNot = false;
            killTimer = 0.3f;

            //上向きの力を加える
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 15.0f, ForceMode.Impulse);

        }

    }

    void Update(){
        if (!damaged) return;

        killTimer -= Time.deltaTime;
        if (killTimer < 0.0f)
        {
            //破壊をGameControllerに追加
            if (ApplyorNot == true)
            { //弾丸が命中したとき
                GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
                gameController.SendMessage("OnDestroyTarget", colorName);
            }
            else
            { //ボムが命中したとき
                GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
                gameController.SendMessage("OffDestroyTarget", colorName);
            }


            Instantiate(explosionPrehab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
