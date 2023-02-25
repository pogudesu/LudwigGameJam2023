using SojaExiles;
using UnityEngine;
using UnityEngine.Playables;

namespace UnityTemplateProjects
{
    public class TriggerFinalCutScene : MonoBehaviour
    {
        public GameObject cat;
        public PlayableDirector playableDirector;
        public opencloseDoor opencloseDoor;
        public void StartFinalCutscene()
        {
            cat.SetActive(true);
            if (playableDirector == null) return;
            playableDirector.Play();
        }

        public void SetUpFinalCutscene()
        {
            opencloseDoor.isReadyForCutScene = true;
            StartCoroutine(opencloseDoor.closing());
        }
    }
}