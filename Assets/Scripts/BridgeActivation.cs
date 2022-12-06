//Script to activate the bridge in the area of the floating platforms
using UnityEngine;

public class BridgeActivation : MonoBehaviour
{
    [SerializeField]
    [Tooltip ("Puente que se activaría con el script")]
    public GameObject bridge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bridge.SetActive(true);
        }
    }
}
