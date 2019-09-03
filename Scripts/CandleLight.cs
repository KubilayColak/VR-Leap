using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour {

    public enum WaveForm { sin, noise};
    public WaveForm waveform = WaveForm.sin;

    public float baseStart = 0f;
    public float amplitude = 1f;
    public float phase = 0f;
    public float frequency = 0.5f;

    private Color originalColour;
    private Light light;

	// Use this for initialization
	void Start () {

        light = GetComponent<Light>();
        originalColour = light.color;
	}
	
	// Update is called once per frame
	void Update () {

        light.color = originalColour * (EvalWave());
		
	}

    float EvalWave()
    {

        float x = (Time.time + phase) * frequency;
        float y;
        x = x - Mathf.Floor(x);

        if (waveform == WaveForm.sin)
        {

            y = Mathf.Sin(x * 2 * Mathf.PI);

        }

        else if (waveform == WaveForm.noise)
        {

            y = 1f - (Random.value * 2);

        }

        else
        {
            y = 1f;
        }

        return (y * amplitude) + baseStart;

    }

}
