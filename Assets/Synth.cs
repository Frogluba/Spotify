using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synth : MonoBehaviour
{
    public float frequency;
    public AudioSource source;

    void Start()
    {
        var clip = AudioClip.Create("Sin",441000,1,44100,false);

        var data = new float[441000 * 3];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = Mathf.Sin(i/44100f * Mathf.PI * 2f * 1740);
            data[i] += Mathf.Sin(i / 44100f * Mathf.PI * 2f * 1160);
            data[i] += Mathf.Sin(i / 44100f * Mathf.PI * 2f * 580);
            data[i] /= 2f;
        }
        

        clip.SetData(data, 0);
        source.clip = clip;
        source.Play();
    }
}
