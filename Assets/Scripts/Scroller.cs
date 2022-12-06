//Script to scroll background
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [Header ("Opciones del fondo")]
    [SerializeField]
    [Tooltip("Imagen de fondo")]
    private RawImage img;
    [SerializeField]
    [Tooltip ("Velocidad a la que se desplaza el fondo")]
    private float x, y;
    
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * Time.deltaTime, img.uvRect.size);
    }
}
