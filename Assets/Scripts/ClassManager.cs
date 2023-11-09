using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClassManager : MonoBehaviour
{
    public PlayerMovement Clase;
    public bool Selected = false;
    Animator anim;
    public GameObject Etapa1;
    public GameObject Etapa2;

    public void Start()
    {
        anim = GetComponent<Animator>();
        Etapa2.SetActive(false);
    }

    private void FixedUpdate()
    {

        if (Clase.PuntosStats >= 1)
        {
            anim.Play("StatsFadeIn");
 
        }
        else if (Clase.PuntosStats <= 0)
        {
            anim.Play("StatsFadeOout");
        }

        if (Clase.Level >= 3 && Selected == false)
        {
            Clase.etapa1 = true;
            if (Clase.etapa1 == true)
            {
                anim.Play("ClassFadeIn");
            }   
        }

        if (Clase.Level >= 5)
        {

            Etapa1.SetActive(false);
            Clase.etapa2 = true;
            Etapa2.SetActive(true);

            if (Clase.etapa2 == true && Selected == true)
            {
                anim.Play("ClassFadeIn");
            }
        }

    }

    public void Etapa1_Sniper()
    {
        anim.Play("ClassFadeOut");
        
        Selected = true;
        Clase.etapa1 = false;
    }

    public void Etapa1_DoubleShoot()
    {
        anim.Play("ClassFadeOut");
      
        Selected = true;
        Clase.etapa1 = false;
    }

    public void Etapa1_Carrier()
    {
        anim.Play("ClassFadeOut");
       
        Selected = true;
        Clase.etapa1 = false;
    }

    public void Etapa1_4()
    {
        anim.Play("ClassFadeOut");
        
        Selected = true;
        Clase.etapa1 = false;
    }

    public void Etapa2_DualSniper()
    {
        anim.Play("ClassFadeOut");

        Selected = true;
        Clase.etapa2 = false;
    }
    public void Etapa2_CuadrupleShoot()
    {
        anim.Play("ClassFadeOut");

        Selected = true;
        Clase.etapa2 = false;
    }

    public void Etapa2_MegaCarrier()
    {
        anim.Play("ClassFadeOut");

        Selected = true;
        Clase.etapa2 = false;
    }

    public void Etapa2_Acorazado()
    {
        anim.Play("ClassFadeOut");
    }
}
