using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactables
{
    [SerializeField]
    public bool isOn = false;
    public float interactableDistance;

    [SerializeField]
    private float distanceToPlayer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= interactableDistance)
        {
            //TODO: Show UI here to prompt player that they can interact with this object
            if (InputManager.Instance.PlayerInteract())
            {
                Interact();
            }
        }
    }

    public override bool Interact() //return whether interaction with the object is successful
    {
        if(isOn)
        {
            isOn = false;
            return true; //interaction successful
        }
        else
        {
            isOn = true;
            return false; //interaction successful
        }
        return false; //interaction unsuccessful
    }
}
