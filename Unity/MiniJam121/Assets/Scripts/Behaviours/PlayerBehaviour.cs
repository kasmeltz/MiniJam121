namespace HNS.MiniJam121.Unity.Behaviours
{
    using UnityEngine;

    [AddComponentMenu("MJ121/Player")]
    public class PlayerBehaviour : MonoBehaviour
    {
        public float MoveSpeed;

        public ScenerySectionBehaviour[] ScenerySections;

        public ScenerySectionBehaviour CurrentScenery;

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

        public void StartScenery(ScenerySectionBehaviour scenery)
        {
            CurrentScenery = scenery;
            transform.position = scenery.StartingPosition;
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

            if (position.x < CurrentScenery.Bounds.x)
            {
                position.x = CurrentScenery.Bounds.x;
            }
            else if (position.x > CurrentScenery.Bounds.y)
            {
                position.x = CurrentScenery.Bounds.y;
            }

            transform.position = position;

            var cameraPosition = Camera.main.transform.position;

            cameraPosition = new Vector3(transform.position.x, cameraPosition.y, cameraPosition.z);

            Camera.main.transform.position = cameraPosition;
        }

        protected void Awake()
        {
            Animator = GetComponent<Animator>();

            StartScenery(ScenerySections[0]);
        }
    }
}