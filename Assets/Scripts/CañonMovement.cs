using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CañonMovement : MonoBehaviour
{
    [SerializeField] private Camera camara;

    void Start()
    {
        // Asegúrate de que el objeto tenga la rotación inicial correcta (frente hacia la derecha)
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        ApuntarAlCursor();
    }

    void ApuntarAlCursor()
    {
        // Obtén la posición del cursor en el mundo
        Vector3 objetivo = camara.ScreenToWorldPoint(Input.mousePosition);
        float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
    }
}
