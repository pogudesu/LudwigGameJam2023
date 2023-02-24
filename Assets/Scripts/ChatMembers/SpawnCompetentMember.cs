using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCompetentMember : MonoBehaviour
{
    public string dialoguePlayedKey = "dialogue_played";
    public List<Fungus.Flowchart> flowdatas;
    public List<MeshRenderer> mrs;
    
    private bool spawnChatMember = false;
    public GameObject competentMemberObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawnChatMember)
        {
            spawnChatMember = true;
            for (int i = 0; i < flowdatas.Count; i++)
            {
                if(flowdatas[i].GetBooleanVariable(dialoguePlayedKey) == false)
                {
                    spawnChatMember = false;
                    return;
                }
            }
        }
        else
        {
            if(!competentMemberObj.activeInHierarchy)
            {
                competentMemberObj.SetActive(true);
            }
        }
    }

    public void DisableRenderers()
    {
        for (int i = 0; i < mrs.Count; i++)
        {
            mrs[i].GetComponent<Collider>().enabled = false;
            mrs[i].enabled = false;
        }
    }

    public void DisableObjects()
    {
        gameObject.SetActive(false);
    }
}
