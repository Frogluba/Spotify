using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public float power =2;
    public float maxSize=5;

    public Quaternion a;
    public Quaternion b;

    public Color startColor;
    public Color endColor;

     void Start()
    {
        Analyzer.onVolumeChanged.AddListener(Dance);
    }

    public void Dance(float volume)
    {
        transform.localScale = Vector3.one * (0.5f + Mathf.Pow(0.5f+volume,power)*maxSize);
        var mixedColors = Color.Lerp(startColor, endColor, volume * 5);
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", mixedColors);
        transform.rotation = Quaternion.Lerp(a, transform.rotation, volume * 5);
        
    }
}
