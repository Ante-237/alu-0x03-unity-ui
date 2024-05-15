using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using Random = UnityEngine.Random;



public class UIElementController : MonoBehaviour
{
    [Header("Controllers")]
    public Slider VolumeSlider;
    public Slider SizeSlider;
    public Toggle SoundToggle;
    public Toggle LightToggle;
    public float maxTime = 10f;

    public GameObject Lights;
    public GameObject BoxObject;
    public TextMeshProUGUI Timer;
    public AudioSource audioSource;
    public Color[] colors = new[] { Color.green, Color.magenta, Color.red, };


    private float TrackedTime = 0;

    private void Update()
    {
        UpdateTimer();
    }

    private void Start()
    {
        SetListeners();
        
#if  PLATFORM_STANDALONE_WIN
        SizeSlider.interactable = false;
#endif
        
#if  UNITY_EDITOR
        SizeSlider.interactable = true;
#endif
    }

    void SetListeners()
    {
        VolumeSlider.onValueChanged.AddListener(VolumeChangeSlider);
        SizeSlider.onValueChanged.AddListener(SizeChangeSlider);
        SoundToggle.onValueChanged.AddListener(OnSoundToggle);
        LightToggle.onValueChanged.AddListener(OnLightToggle);
    }

    private void OnSoundToggle(bool value)
    {
        audioSource.enabled = value;
    }

    private void OnLightToggle(bool value)
    {
        Lights.SetActive(value);
        Light l = Lights.GetComponent<Light>();
        l.color = colors[Random.Range(0, 3)];

    }

    private void VolumeChangeSlider(float value)
    {
        if (audioSource != null)
        {
            audioSource.volume = value;
        }
        
    }

    private void SizeChangeSlider(float value)
    {
        BoxObject.transform.localScale = new Vector3(value , value, value) * 3;
    }

    public void UpdateTimer()
    {
        TrackedTime += Time.deltaTime;
        Timer.text = TrackedTime.ToString("00:00:00");

        if (TrackedTime > maxTime)
        {
            Timer.text = "<color=yellow>Time Up</color>";
        }
    }
    
    

}
