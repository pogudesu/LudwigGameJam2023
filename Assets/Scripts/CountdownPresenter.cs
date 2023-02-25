using System;
using TMPro;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class CountdownPresenter : MonoBehaviour
    {
        public TextMeshProUGUI count;
        public int numAnimals = 0;
        public static CountdownPresenter Instance;

        private void Start()
        {
            if (Instance == null)
                Instance = this;
        }

        public void Show()
        {
            numAnimals++;
            if (numAnimals == 5) numAnimals = 0;
            count.text = numAnimals.ToString();
        }
    }
}