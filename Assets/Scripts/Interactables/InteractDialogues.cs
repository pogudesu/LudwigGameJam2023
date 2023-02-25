using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class InteractDialogues : Interactables
{
    [SerializeField]
    private Fungus.Flowchart flowdata;

    public bool dialogueEnabled = false;
    public string dialogueplayedKey = "dialogue_played";
    public string blockToExecute = "TestDialogue";
    public string dialogueEndKey = "finished";
    public override bool Interact()
    {
        if (distanceToPlayer <= interactableDistance)
        {
            if (InputManager.Instance.PlayerInteract())
            {
                if (flowdata.GetBooleanVariable(dialogueplayedKey) == false)
                {
                    flowdata.ExecuteBlock(blockToExecute);
                    PlayerController.Instance.camExtension.LookatObject = gameObject;
                    InputManager.Instance.LockControl(true);
                    dialogueEnabled = true;
                    AudioManager.Instance.PlatAnimalSounds();
                    CountdownPresenter.Instance.Show();
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
            bool done = flowdata.GetBooleanVariable(dialogueEndKey);
            if(done)
            {
                InputManager.Instance.LockControl(false);
                dialogueEnabled = false;
            }
        }
    }
}
