using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassManager : MonoBehaviour
{
    public playerMovement Clase;
    public GameObject PosFinal;
    private float ClasePosition;
    public bool Selected = false;
    

    private void FixedUpdate()
    {

    }

    public void Etapa1_Sniper()
    {
        ClasePosition = PosFinal.transform.position.y;
        LeanTween.moveY(Clase.Clase, ClasePosition, 1f).setEase(LeanTweenType.easeInOutElastic);
        Selected = true;
        Clase.etapa1 = false;
    }

    public void Etapa1_DoubleShoot()
    {
        ClasePosition = PosFinal.transform.position.y;
        LeanTween.moveY(Clase.Clase, ClasePosition, 1f).setEase(LeanTweenType.easeInOutElastic);
        Selected = true;
        Clase.etapa1 = false;
    }

    public void Etapa1_Carrier()
    {
        ClasePosition = PosFinal.transform.position.y;
        LeanTween.moveY(Clase.Clase, ClasePosition, 1f).setEase(LeanTweenType.easeInOutElastic);
        Selected = true;
        Clase.etapa1 = false;
    }

    public void Etapa1_4()
    {
        ClasePosition = PosFinal.transform.position.y;
        LeanTween.moveY(Clase.Clase, ClasePosition, 1f).setEase(LeanTweenType.easeInOutElastic);
        Selected = true;
        Clase.etapa1 = false;
    }
}
