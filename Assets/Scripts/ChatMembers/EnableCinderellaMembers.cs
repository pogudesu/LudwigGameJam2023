using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCinderellaMembers : MonoBehaviour
{
    public GameObject CinderellaChatMembers;

    public void EnableObjects()
    {
        CinderellaChatMembers.SetActive(true);
    }
}
