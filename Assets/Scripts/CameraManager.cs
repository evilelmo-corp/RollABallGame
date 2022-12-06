//Script for the camera
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Opciones de Tracking")]
    [Space]
    [SerializeField]
    [Tooltip("Objetivo de la cámara")]
    private Transform target;
    [SerializeField]
    [Tooltip("Valor del zoom inicial")]
    private float m_FieldOfView = 60f;
    [SerializeField]
    [Tooltip("Velocidad a la que se acerca y se aleja el zoom")]
    private float zoomSpeed = 10f;

    private Vector3 offset;

    void Start()
    {
        offset = target.position-transform.position;
    }

    void Update()
    {
        m_FieldOfView += -Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        transform.position = target.position - offset;
        Camera.main.fieldOfView = m_FieldOfView;
    }
}
