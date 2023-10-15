using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsController : MonoBehaviour
{
    public GameObject[] escondeQuartos;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void liberaRoom(int numRoom)
    {
        escondeQuartos[numRoom-1].SetActive(false);
        if(numRoom == 2)
        {
            foreach(ArrowShooterController arrow in FindObjectsByType<ArrowShooterController>(FindObjectsSortMode.None))
            {
                arrow.setVerifInit(true);
            }
        }
    }

    public void escondeRoom(int numRoom)
    {
        escondeQuartos[numRoom - 1].SetActive(true);
    }
}
