using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCoot : Interactables
{
    [SerializeField]
    private Fungus.Flowchart flowdata;

    public bool dialogueEnabled = false;
    public override bool Interact()
    {
        if (distanceToPlayer <= interactableDistance)
        {
            if (InputManager.Instance.PlayerInteract())
            {
                if (flowdata.GetBooleanVariable("dialogue_played") == false)
                {
                    flowdata.ExecuteBlock("TestDialogue");
                    PlayerController.Instance.camExtension.LookatObject = gameObject;
                    InputManager.Instance.LockControl(true);
                    dialogueEnabled = true;
                }
            }
            return true;
        }
        return false;
    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if(dialogueEnabled)
        {
            bool done = flowdata.GetBooleanVariable("finished");
            if(done)
            {
                InputManager.Instance.LockControl(false);
            }
        }
    }
}
