namespace HNS.MiniJam121.Unity.Behaviours
{
    using UnityEngine;

    [AddComponentMenu("MJ121/Player")]
    public class PlayerBehaviour : MonoBehaviour
    {
        public float MoveSpeed;

        protected void Update()
        {
            if (Input.GetKey(KeyCode.A) || 
                Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(MoveSpeed, 0, 0) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D) ||
                Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(MoveSpeed, 0, 0) * Time.deltaTime;
            }
        }
    }
}