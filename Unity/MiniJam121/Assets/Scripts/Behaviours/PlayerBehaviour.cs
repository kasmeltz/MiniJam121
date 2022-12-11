namespace HNS.MiniJam121.Unity.Behaviours
{
    using UnityEngine;

    [AddComponentMenu("MJ121/Player")]
    public class PlayerBehaviour : MonoBehaviour
    {
        public float MoveSpeed;

        public ScenerySectionBehaviour[] ScenerySections;

        public int SceneryIndex;

        protected Animator Animator { get; set; }

        protected bool IsPaused { get; set; }

        public void SetPaused(bool isPaused)
        {
            IsPaused = isPaused;

            if (IsPaused)
            {
                Animator
                    .SetBool("IsWalking", false);

                Animator
                    .SetBool("IsIdle", true);
            }
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

            Animator
                .SetBool("IsWalking", false);

            Animator
                .SetBool("IsIdle", true);

            var position = transform.position;
            if (Input.GetKey(KeyCode.A) || 
                Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                position -= new Vector3(MoveSpeed, 0, 0) * Time.deltaTime;
                
                Animator
                    .SetBool("IsWalking", true);

                Animator
                    .SetBool("IsIdle", false);
            }

            if (Input.GetKey(KeyCode.D) ||
                Input.GetKey(KeyCode.RightArrow))
            {
                transform.localScale = new Vector3(1, 1, 1);
                position += new Vector3(MoveSpeed, 0, 0) * Time.deltaTime;
                
                Animator
                    .SetBool("IsWalking", true);
                
                Animator
                    .SetBool("IsIdle", false);
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
            Animator = GetComponent<Animator>();

            StartScenery(0);
        }
    }
}