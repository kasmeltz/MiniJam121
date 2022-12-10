namespace HNS.MiniJam121.Unity.Behaviours
{
    using UnityEngine;

    [AddComponentMenu("MJ121/Player")]
    public class PlayerBehaviour : MonoBehaviour
    {
        public float MoveSpeed;

        public ScenerySectionBehaviour[] ScenerySections;

        public int SceneryIndex;

        protected bool IsPaused { get; set; }

        public void SetPaused(bool isPaused)
        {
            IsPaused = isPaused;
        }

        public void StartScenery(int index)
        {
            SceneryIndex = index;
            transform.position = ScenerySections[SceneryIndex].StartingPosition;
        }

        protected void Update()
        {
            if (IsPaused)
            {
                return;
            }

            var position = transform.position;
            if (Input.GetKey(KeyCode.A) || 
                Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                position -= new Vector3(MoveSpeed, 0, 0) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D) ||
                Input.GetKey(KeyCode.RightArrow))
            {
                transform.localScale = new Vector3(1, 1, 1);
                position += new Vector3(MoveSpeed, 0, 0) * Time.deltaTime;
            }

            var currentScenery = ScenerySections[SceneryIndex];

            if (position.x < currentScenery.Bounds.x)
            {
                position.x = currentScenery.Bounds.x;
            }
            else if (position.x > currentScenery.Bounds.y)
            {
                position.x = currentScenery.Bounds.y;
            }

            transform.position = position;

            var cameraPosition = Camera.main.transform.position;

            cameraPosition = new Vector3(transform.position.x, cameraPosition.y, cameraPosition.z);

            Camera.main.transform.position = cameraPosition;
        }

        protected void Awake()
        {
            StartScenery(0);
        }
    }
}