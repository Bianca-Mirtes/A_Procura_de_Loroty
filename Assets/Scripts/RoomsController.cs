using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsController : MonoBehaviour
{
    public GameObject[] escondeQuartos;

    public void liberaRoom(int numRoom)
    {
        if(numRoom != 0)
        {
            escondeQuartos[numRoom-1].SetActive(false);
        }


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
        if(numRoom != 0)
        {
            escondeQuartos[numRoom - 1].SetActive(true);
        }

        if (numRoom == 2)
        {
            foreach (ArrowShooterController arrow in FindObjectsByType<ArrowShooterController>(FindObjectsSortMode.None))
            {
                arrow.setVerifInit(false);
            }
        }
    }
}
