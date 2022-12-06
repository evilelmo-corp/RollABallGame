//Script to restart the level when player dies
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public GameObject defeatPanel;
    public float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
