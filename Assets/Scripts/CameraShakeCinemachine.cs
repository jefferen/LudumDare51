using System.Collections;
using System.Collections.Generic;
using Cinemachine;                      
using UnityEngine;

public class CameraShakeCinemachine : MonoBehaviour
{
    Vector3 OriginPoint, tempoint; 

    [SerializeField][Range(0.001f,1)]
    float shakeStrength;

    [SerializeField]
    float shakeAmplitude, shakeFrequency;

    [SerializeField][Range(0.01f,2)]
    float time;

    CinemachineBasicMultiChannelPerlin Cam;

    public void Awake()
    {
        Cam = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        StopTremble();
    }

    public void Shake(float magnitude = 1f, float duration = 0.5f)
    {
        StopAllCoroutines();
        StartCoroutine(Tremble(magnitude, duration));
    }

    public IEnumerator Tremble(float magnitude = 1f, float duration = 0.5f)
    {
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            Cam.m_AmplitudeGain = shakeAmplitude * magnitude;
            Cam.m_FrequencyGain = shakeFrequency * magnitude;
            yield return new WaitForEndOfFrame();
        }
        StopTremble();
    }

    public void StopTremble()
    {
        Cam.m_AmplitudeGain = Cam.m_FrequencyGain = 0;
    }
}
