using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class ArrowShooterController : MonoBehaviour
{
    public Rigidbody2D arrow;
    public float speedArrow;
    public Transform arrowPosition;
    private bool verifInit = false;

    private float timeBetween = 2f;

    public void setVerifInit(bool value)
    {
        verifInit = value;
    }
    // Update is called once per frame
    void Update()
    {
        if (verifInit)
        {
            if(timeBetween <= 0)
            {
                Arrow();
                timeBetween = 2f;
            }
            else
            {
                timeBetween -= Time.deltaTime;
            }
        }
    }

    public void Arrow()
    {
        Rigidbody2D clone = Instantiate(arrow, arrowPosition.position, arrowPosition.localRotation);
        clone.velocity = transform.right*speedArrow * Time.deltaTime;
        Destroy(clone.gameObject, 5f);

    }
}
