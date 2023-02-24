using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudwigOpeningDialogue : MonoBehaviour
{
    [SerializeField]
    private Fungus.Flowchart flowdata;
    public bool dialogueEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueEnabled && !flowdata.GetBooleanVariable("finished"))
        {
            flowdata.ExecuteBlock("GameStart");
            PlayerController.Instance.camExtension.LookatObject = gameObject;
            InputManager.Instance.LockControl(true);
            dialogueEnabled = true;
        }
        if (dialogueEnabled)
        {
            bool done = flowdata.GetBooleanVariable("finished");
            if (done)
            {
                InputManager.Instance.LockControl(false);
                dialogueEnabled = false;
            }
        }
    }
}
