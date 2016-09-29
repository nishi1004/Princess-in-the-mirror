using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
        StartCoroutine("Generate");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator Generate()
    {
        //上下左右の順に一定時間ごとに敵追加
        while (true)
        {
            Instantiate(enemy, new Vector3(Random.Range(-1.8f, 1.8f), 1.35f, 0), transform.rotation);
            yield return new WaitForSeconds(10f);
            Instantiate(enemy, new Vector3(Random.Range(-1.8f, 1.8f), -1.35f, 0), transform.rotation);
            yield return new WaitForSeconds(10f);
            Instantiate(enemy, new Vector3(-2.3f, Random.Range(-0.8f, 0.8f), 0), transform.rotation);
            yield return new WaitForSeconds(10f);
            Instantiate(enemy, new Vector3(2.3f, Random.Range(-0.8f, 0.8f), 0), transform.rotation);
            yield return new WaitForSeconds(10f);
        }
    }
}
