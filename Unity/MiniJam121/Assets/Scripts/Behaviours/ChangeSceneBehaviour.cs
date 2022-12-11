namespace HNS.MiniJam121.Unity.Behaviours
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    [AddComponentMenu("MJ121/ChangeScene")]
    public class ChangeSceneBehaviour : MonoBehaviour
    {
        public void LoadScene(string name)
        {
            SceneManager
                .LoadSceneAsync(name);
        }
    }
}