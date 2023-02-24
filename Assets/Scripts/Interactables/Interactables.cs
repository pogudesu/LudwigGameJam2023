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
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
    }
}
