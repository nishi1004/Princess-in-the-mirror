using UnityEngine;
using System.Collections;

public class WitchController : MonoBehaviour {
    public GameObject[] apples;
    private GameObject player;
    private string[] strategyList= {
        "ランダム","追いかけ"};
    private string strategy;//魔女のとる戦略
    private float interval;//リンゴを撃つ間隔
    public float speed;
    private Animator anim;
    private string pos;
    public AudioClip clip;
    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        speed = Random.Range(1f, 5f);
        interval = Random.Range(2f, 4f); 
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
        pos = Position();
        StartCoroutine("ShootApple");
        strategy = strategyList[Random.Range(0, strategyList.Length)];
        if (strategy == "ランダム")
        {
            StartCoroutine("RandomAttack");
        }
        if (strategy == "追いかけ")
        {
            StartCoroutine("Chase");
        }
        if (strategy == "先回り")
        {
            StartCoroutine("Alreadey");
        }
    }
	
	// Update is called once per frame
	void Update () {
        
       
    }

    //追いかけ
    public IEnumerator Chase()
    {
        float offset = Random.Range(0f, 1f);
        while (true)
        {
            
            if (pos == "上" || pos == "下")
            {
                int dir=(transform.position.x - player.transform.position.x+offset < 0) ? 1 :  -1;
                transform.Translate(new Vector3(0.2f * dir, 0, 0));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.8f, 1.8f), transform.position.y, 0);
            }
            else
            {
                int dir = (transform.position.y - player.transform.position.y+offset < 0) ? 1 : -1;
                transform.Translate(new Vector3(0, 0.2f * dir, 0));
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -0.8f, 0.8f), 0);
            }


            yield return new WaitForSeconds(0.5f);


        }
    }

    //先回り
    void Already()
    {

    }


    //ランダム
    public IEnumerator RandomAttack()
    {
        while (true)
        {
            int[] dir = { -1, 1 };
                if (pos == "上" || pos == "下")
                {
                transform.Translate(new Vector3(Random.Range(0.2f, 0.5f) *dir[Random.Range(0,2)], 0, 0));
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.8f, 1.8f), transform.position.y, 0);
                }
                else
                {
                    transform.Translate(new Vector3(0, Random.Range(0.2f, 0.5f)* dir[Random.Range(0, 2)], 0));
                    transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -0.8f, 0.8f), 0);
                }
                
            
            yield return new WaitForSeconds(0.5f);
                
            
        }

        }

    //自分が今上下左右どの場所にいるかを取得
     string Position()
    {
        if (Mathf.Abs(transform.position.x) < 2)
        {
            if (transform.position.y > 0)
            {
                anim.SetInteger("Walk", 1);
                return "上";
            }
            else
            {
                anim.SetInteger("Walk", 0);
                return "下";
            }
        }else
        {
            if (transform.position.x > 2)
            {
                anim.SetInteger("Walk", 2);
                return "右";
            }
            else
            {
                anim.SetInteger("Walk", 3);
                return "左";
            }
        }
    }

    //リンゴを撃つ
    public IEnumerator ShootApple()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            audioSource.PlayOneShot(clip);
            Instantiate(apples[Random.Range(0, 2)], transform.position, Quaternion.identity);
        }
    }
}
