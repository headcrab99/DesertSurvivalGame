using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TremblingLight : MonoBehaviour
{
    private Light2D light;

    [SerializeField] private float deltaIntensity;
    private float maxIntensity;
    private float minIntensity;

    //private float intensity;

    [SerializeField] private float deltaRange;
    private float maxRange;
    private float minRange;
    //private float range;

    [SerializeField] private float time;


    private void Start()
    {
        light = GetComponent<Light2D>();

        maxIntensity = light.intensity + deltaIntensity;
        minIntensity = light.intensity - deltaIntensity;
        maxRange = light.pointLightOuterRadius + deltaRange;
        minRange = light.pointLightOuterRadius - deltaRange;

        StartCoroutine(Chaos());
    }

    void Update()
    {
        
    }

    private IEnumerator Chaos()
    {
        light.intensity += Random.Range(-deltaIntensity, deltaIntensity);
        light.pointLightOuterRadius += Random.Range(-deltaRange, deltaRange);
        light.intensity = Mathf.Clamp(light.intensity, minIntensity, maxIntensity);
        light.pointLightOuterRadius = Mathf.Clamp(light.pointLightOuterRadius, minRange, maxRange);


        yield return new WaitForSeconds(time);
        StartCoroutine(Chaos());
    }
}
