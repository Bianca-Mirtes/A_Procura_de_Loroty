using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destiny : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObjMovivel"))
        {
            FindObjectOfType<GameController>().liberaSaida();
            Destroy(collision.gameObject);
        }
    }
}
