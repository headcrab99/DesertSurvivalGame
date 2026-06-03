using System.Collections;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField] private GameObject light;
    [SerializeField] private float battery;
    [SerializeField] private float batteryMax;
    [SerializeField] private float batteryTick;

    private bool isOn = false;

    private void Start()
    {
        battery = batteryMax;
        StartCoroutine(SpendBattery());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && battery > 0)
        {
            isOn = !isOn;
        }
        light.SetActive(isOn);
    }
    private IEnumerator SpendBattery()
    {
        if (isOn)
        {
            battery -= 1;
        }
        if (battery <= 0)
        {
            isOn = false;
        }
        yield return new WaitForSeconds(batteryTick);

        StartCoroutine(SpendBattery());
    }

    public void RestoreBattery(float battery)
    {
        this.battery += battery;
    }

}
