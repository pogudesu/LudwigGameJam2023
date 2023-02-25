using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Fungus;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{

    public static GeneralManager Instace;
    public CinemachineVirtualCamera introCamera;
    private Flowchart flowchart;
    private void Start()
    {
        if (Instace == null)
        {
            Instace = this;
        }

        flowchart = GetComponent<Flowchart>();
    }

    public void OnFinishDialogueIntro()
    {
        // Debug.Log("Finished intro");
        introCamera.Priority = 9;
    }

    public void OnStartFinalDialogue()
    {
        Debug.Log("Finished Final");
        flowchart.ExecuteIfHasBlock("StartFinalCutscene");
    }
}
