namespace HNS.MiniJam121.Unity.Behaviours
{
    using UnityEngine;

    [AddComponentMenu("MJ121/Player")]
    public class PlayerBehaviour : MonoBehaviour
    {
        public float MoveSpeed;

        protected bool IsPaused { get; set; }

        public void SetPaused(bool isPaused)
        {
            IsPaused = isPaused;
        }

        protected void Update()
        {
            if (IsPaused)
            {
                return;
            }

            if (Input.GetKey(KeyCode.A) || 
                Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position -= new Vector3(MoveSpeed, 0, 0) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D) ||
                Input.GetKey(KeyCode.RightArrow))
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += new Vector3(MoveSpeed, 0, 0) * Time.deltaTime;
            }

            var cameraPosition = Camera.main.transform.position;

            cameraPosition = new Vector3(transform.position.x, cameraPosition.y, cameraPosition.z);

            Camera.main.transform.position = cameraPosition;
        }
    }
}