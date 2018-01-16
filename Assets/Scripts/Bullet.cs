using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	//衝突の判定
    void OnCollisionEnter(Collision collision)
    {
        //衝突したものが箱なら
        if(collision.gameObject.tag == "Box")
        {
            //ダメージメッセージを送信
            collision.gameObject.SendMessage("ApplyDamage");

        }
        //弾丸自体も消滅
        Destroy(gameObject);
    }
	
}
