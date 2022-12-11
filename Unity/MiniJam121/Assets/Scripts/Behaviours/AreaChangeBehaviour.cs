namespace HNS.MiniJam121.Unity.Behaviours
{
    using UnityEngine;

    [AddComponentMenu("MJ121/AreaChange")]
    public class AreaChangeBehaviour : MonoBehaviour
    {
        public float PositionToChange;
        public float ChangeDistance;
        public ScenerySectionBehaviour ChangeFrom;
        public ScenerySectionBehaviour ChangeTo;

        protected PlayerBehaviour Player { get; set; }

        protected void Update()
        {
            var distance = Mathf
                .Abs(Player.transform.position.x - PositionToChange);
            
            if (distance <= ChangeDistance)
            {
                ChangeFrom
                    .gameObject
                    .SetActive(false);

                ChangeTo
                    .gameObject
                    .SetActive(true);

                Player
                    .StartScenery(ChangeTo);
            }
        }

        protected void Awake()
        {
            Player = FindObjectOfType<PlayerBehaviour>(true);
        }
    }
}