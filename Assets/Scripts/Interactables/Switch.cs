using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactables
{
    [SerializeField]
    public bool isOn = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override bool Interact() //return whether interaction with the object is successful
    {
        if (distanceToPlayer <= interactableDistance)
        {
            if (isOn)
            {
                isOn = false;
                return true; //interaction successful
            }
            else
            {
                isOn = true;
                return false; //interaction successful
            }
        }
        return false; //interaction unsuccessful
    }
}
