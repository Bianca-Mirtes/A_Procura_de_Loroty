using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Open"))
        {
            // abre portas, baús, armarios
        }

        if(Input.GetKey(KeyCode.E))
        {
            //interagir com os objetos do mapa
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        // right/left
        rb.velocity = new Vector3(speed * horizontal, rb.velocity.y, 0f);
        // top/down
        rb.velocity = new Vector3(rb.velocity.x, speed * vertical, 0f);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.name.Equals("box"))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if(Input.GetAxisRaw("Horizontal") > 0)
                {
                    collision.transform.position = new Vector3(transform.position.x + 1.007f, transform.position.y, 0f);
                }
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    collision.transform.position = new Vector3(transform.position.x - 1.007f, transform.position.y, 0f);
                }
                if(Input.GetAxisRaw("Vertical") > 0)
                {
                    collision.transform.position = new Vector3(transform.position.x, transform.position.y+1.01f, 0f);
                }
                if(Input.GetAxisRaw("Vertical") < 0)
                {
                    collision.transform.position = new Vector3(transform.position.x, transform.position.y - 1.01f, 0f);
                }
            }
        }
    }
}
