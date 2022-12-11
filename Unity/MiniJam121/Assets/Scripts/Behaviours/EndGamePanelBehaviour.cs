namespace HNS.MiniJam121.Unity.Behaviours
{
    using TMPro;
    using UnityEngine;

    [AddComponentMenu("MJ121/EndGamePanel")]
    public class EndGamePanelBehaviour : MonoBehaviour
    {
        public TMP_Text[] PossibleEndingTexts;

        protected PlayerBehaviour Player { get; set; }

        public void ShowEnding(int index)
        {
            foreach (var text in PossibleEndingTexts)
            {
                text
                    .gameObject
                    .SetActive(false);
            }

            PossibleEndingTexts[index]
                .gameObject
                .SetActive(true);

            gameObject
                .SetActive(true);

            Player
                .SetPaused(true);
        }

        protected void Awake()
        {
            Player = FindObjectOfType<PlayerBehaviour>(true);
        }
    }
}