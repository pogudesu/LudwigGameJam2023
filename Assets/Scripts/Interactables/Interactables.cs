using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected float distanceToPlayer;
    public float interactableDistance;
    public virtual bool Interact()
    {
        return true;
    }

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public virtual void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(interactableDistance == 0.0f)
        {
            interactableDistance = 3.0f;
        }
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
    }
}
