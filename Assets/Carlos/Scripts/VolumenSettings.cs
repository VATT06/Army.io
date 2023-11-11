using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenSettings : MonoBehaviour
{
    public Slider slider;
    public float slidervalue;
    public Image imagemute;
    public AudioSource soundtrack;

    // Start is called before the first frame update
    void Start()
    {
        soundtrack = GetComponent<AudioSource>();
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        soundtrack.volume = slider.value;
        Estoymute();
    }
    public void changeSlider(float valor)
    {
        slidervalue= valor;
        PlayerPrefs.SetFloat("volumenAudio", slidervalue);
        soundtrack.volume = slider.value;
        Estoymute();
    }

    public void Estoymute()
    {
    if (slider.value == 0) 
        {
        imagemute.enabled = true;
        }
        else
        {
        imagemute.enabled = false;
        }
    }
}
