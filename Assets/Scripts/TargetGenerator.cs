using UnityEngine;
using System.Collections;

public class TargetGenerator : MonoBehaviour {

    public float interval;//標的の出現間隔
    public GameObject redBoxPrefab;//赤い箱のプレハブ
    public GameObject blueBoxPrefab;//青い箱のプレハブ
    private bool nextIsRed;//次が赤箱かどうか？
    private float timer;//次の標的が出現するまでの時間

    void Start()
    {
        nextIsRed = true;
        timer = 0.0f;

    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0.0f)
        {
            float offsX = Random.Range(-8.0f, 8.0f);
            float offsZ = Random.Range(-4.0f, 8.0f);
            Vector3 position = transform.position + new Vector3(offsX, 0, offsZ);

            //標的の出現処理
            GameObject prefab = (GameObject)(nextIsRed ? redBoxPrefab : blueBoxPrefab);
            Instantiate(prefab, position, Random.rotation);

            //次の標的の予約
            timer = interval;
            nextIsRed = !nextIsRed;
        }
    }

    void TimeUp()
    {
        enabled = false;
    }

    void StartGame()
    {
        enabled = true;
    }

}
