using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Animator anim;
    public int m_playerState = 0;
    private SpriteRenderer m_idlestate;
    public float walkSpeed = 5f;
    public int life = 3;
    private bool muteki=false;
    public float mutekiTime=1f;

    public Sprite F;
    public Sprite B;
    public Sprite R;
    public Sprite L;

    private Vector3 m_playerPosition = new Vector3(0, 0, 0);
    // Use this for initialization
    void Start () {
         
         anim = GetComponent<Animator>();
        m_idlestate = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.speed = 1;
            anim.SetInteger("Walk", 1);
            transform.Translate(0,-walkSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.speed = 1;
            anim.SetInteger("Walk", 0);
            transform.Translate(0, walkSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.speed = 1;
            anim.SetInteger("Walk", 3);
            transform.Translate(walkSpeed * Time.deltaTime, 0,0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.speed = 1;
            anim.SetInteger("Walk", 2);
            transform.Translate(-walkSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.speed = 0;
        }


        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.speed = 0;
        }


        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.speed = 0;
        }


        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.speed = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "apple"&&!muteki)
        {
            if (life > 0)
            {
                life--;
                StartCoroutine("Muteki");
            }else
            {
                //ゲームオーバー
            }

        }
        
    }

    public IEnumerator Muteki()
    {
        muteki = true;
        yield return new WaitForSeconds(mutekiTime);
        muteki = false;
    }
}
