namespace HNS.MiniJam121.Unity.Behaviours
{
    using UnityEngine;

    [AddComponentMenu("MJ121/NarrationTrigger")]
    public class NarrationTriggerBehaviour : MonoBehaviour
    {
        public TriggerItemCategory NarrationCategory;
        public string[] NarrationTexts;
        public string[] Choices;
        public float[] ChoiceValues;
        public float MinDistanceToActivate;

        protected PlayerBehaviour Player { get; set; }

        protected NarrationPlayerBehaviour NarrationPlayer { get; set; }

        protected bool IsCompleted { get; set; }

        public void SetCompleted(bool isCompleted)
        {
            IsCompleted = isCompleted;
        }

        protected void Update()
        {
            if (IsCompleted)
            {
                return;
            }

            float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

            if (distance <= MinDistanceToActivate)
            {
                NarrationPlayer
                    .PlayNarration(this);
            }
        }

        protected void Awake()
        {
            Player = FindObjectOfType<PlayerBehaviour>(true);
            NarrationPlayer = FindObjectOfType<NarrationPlayerBehaviour>(true);
        }
    }
}