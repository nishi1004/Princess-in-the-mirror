using UnityEngine;
using System.Collections;

public class ApplesController : MonoBehaviour {

    public float appleSpeed = 1f;
    public float blueAppleSpeed = 1.5f;
    private float speed;
    private string pos;
   
    // Use this for initialization
    void Start() {
         pos = Position();
        
        if (gameObject.name == "Apple") { speed = appleSpeed; } else { speed = blueAppleSpeed; }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (pos == "上")
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else if (pos == "下")
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        else if (pos == "右")
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    string Position()
    {
        if (Mathf.Abs(transform.position.x) < 2)
        {
            if (transform.position.y > 0)
            {
                
                return "上";
            }
            else
            {
                return "下";
            }
        }
        else
        {
            if (transform.position.x > 2)
            {
                return "右";
            }
            else
            {
                return "左";
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "floor")
        {
            Destroy(gameObject);
        }
    }
}
