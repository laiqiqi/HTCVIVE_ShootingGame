using UnityEngine;
using System.Collections;

public class Eruption : MonoBehaviour{

    public GameObject explosionPrehab; //プレハブを受け取る関数

    //衝突の判定
    void OnCollisionEnter(Collision collision)
    {
        //衝突したものが箱なら
        if (collision.gameObject.tag == "Box")
        {

            //ダメージメッセージを送信
            collision.gameObject.SendMessage("NotDamage");

            //弾丸自体も消滅
            Destroy(gameObject);
            Instantiate(explosionPrehab, transform.position, transform.rotation);

        }


        if (collision.gameObject.tag == "Bullet")
        {

            //弾丸自体も消滅
            Destroy(gameObject);
            Instantiate(explosionPrehab, transform.position, transform.rotation);

        }

    }

}
