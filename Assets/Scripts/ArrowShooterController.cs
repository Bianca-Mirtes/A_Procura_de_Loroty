using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class ArrowShooterController : MonoBehaviour
{
    public float speedArrow;
    public GameObject arrow;
    public Transform positionOrigin;
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
        GameObject clone = Instantiate(arrow, positionOrigin.position, Quaternion.identity);
        Destroy(clone, 3.5f);

    }
}
