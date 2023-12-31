using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Transform box;
    private bool pegouObj=false;
    private int RoomCurrent = 0;

    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        //ani.SetBool("isWalking", true);
        // right/left
        rb.velocity = new Vector3(speed * horizontal, rb.velocity.y, 0f);
        // top/down
        rb.velocity = new Vector3(rb.velocity.x, speed * vertical, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("arrow"))
        {
            ani.SetBool("isDead", true);
            FindObjectOfType<GameController>().DeadPlayer();
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            ani.SetBool("isDead", true);
            FindObjectOfType<GameController>().DeadPlayer();
        }
        if (collision.gameObject.CompareTag("witcherV"))
        {
            FindObjectOfType<GameController>().LevelEnd();
        }
        if (collision.gameObject.CompareTag("witcherF"))
        {
            ani.SetBool("isDead", true);
            FindObjectOfType<GameController>().DeadPlayer();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObjMovivel"))
        {
            box = collision.gameObject.transform;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                pegouObj = true;
                //collision.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    collision.transform.position = new Vector3(transform.position.x + 1.007f, transform.position.y, 0f);
                }
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    collision.transform.position = new Vector3(transform.position.x - 1.007f, transform.position.y, 0f);
                }
                if(Input.GetAxisRaw("Vertical") > 0)
                {
                    collision.transform.position = new Vector3(transform.position.x, transform.position.y + 1.01f, 0f);
                }
                if(Input.GetAxisRaw("Vertical") < 0)
                {
                    collision.transform.position = new Vector3(transform.position.x, transform.position.y - 1.01f, 0f);
                }
                collision.gameObject.transform.parent = transform;
            }
            /*if (Input.GetKey(KeyCode.LeftShift) && pegouObj)
            {
                collision.gameObject.transform.parent = null;
                pegouObj = false;
            }*/
        }
        if (collision.gameObject.CompareTag("trap"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                //interagir com os objetos do mapa
                FindObjectOfType<GameController>().DeadPlayer();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("porta1"))
        {
            RoomCurrent = 1;
        }
        if (collider.gameObject.name.Equals("porta2"))
        {
            RoomCurrent = 2;
        }

        if (collider.gameObject.CompareTag("entrada"))
        {
            FindAnyObjectByType<RoomsController>().liberaRoom(RoomCurrent);
        }

        if (collider.gameObject.CompareTag("saida"))
        {
            FindAnyObjectByType<RoomsController>().escondeRoom(RoomCurrent);
        }
    }

}
