namespace HNS.MiniJam121.Unity.Behaviours
{
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("MJ121/NarrationPlayer")]
    public class NarrationPlayerBehaviour : MonoBehaviour
    {
        public Image NarrationPanel;
        public TMP_Text NarrationTextObject;
        public Image[] ChoicePanels;
        public TMP_Text[] ChoiceTextObjects;

        public Dictionary<int, int> ChoicesMade { get; set; }

        protected int CurrentNarationIndex { get; set; }

        protected int CurrentSelection { get; set; }

        protected PlayerBehaviour Player { get; set; }

        protected NarrationTriggerBehaviour CurrentTrigger { get; set; }

        public void PlayNarration(NarrationTriggerBehaviour trigger)
        {
            CurrentTrigger = trigger;

            CurrentTrigger
                .SetCompleted(true);

            Player
                .SetPaused(true);

            CurrentNarationIndex = trigger.NarrationIndex;

            NarrationTextObject.text = trigger.NarrationTexts[0];

            for (int i = 0; i < trigger.Choices.Length; i++)
            {
                ChoiceTextObjects[i].text = trigger.Choices[i];
            }

            SelectText(0);

            gameObject
                .SetActive(true);
        }

        public void SelectText(int index)
        {
            if (index < 0)
            {
                index = ChoicePanels.Length - 1;
            }

            if (index >= ChoicePanels.Length)
            {
                index = 0;
            }

            CurrentSelection = index;

            for (int i = 0; i < ChoicePanels.Length; i++)
            {
                if (i == index)
                {
                    ChoicePanels[i].color = new Color32(129, 98, 113, 255);
                }
                else
                {
                    ChoicePanels[i].color = new Color32(129, 98, 113, 0);
                }
            }
        }

        protected void MakeSelection()
        {            
            ChoicesMade[CurrentNarationIndex] = CurrentSelection;

            gameObject
                .SetActive(false);

            Player
               .SetPaused(false);
        }

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.S))
            {
                SelectText(CurrentSelection + 1);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) ||
                Input.GetKeyDown(KeyCode.W))
            {
                SelectText(CurrentSelection - 1);
            }

            if (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.Return))
            {
                MakeSelection();
            }
        }

        protected void Awake()
        {
            gameObject
                .SetActive(false);

            ChoicesMade = new Dictionary<int, int>();
            
            Player = FindObjectOfType<PlayerBehaviour>(true);
        }
    }
}