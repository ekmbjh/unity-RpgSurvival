using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] private float secondPerRealTimeSecound; // ���� ������ 100�� = ���� ������ 1��

    [SerializeField] private float fogDensityClac; // ������ ����

    [SerializeField] private float nightFogDensity; // �� ������ Fog �е�
    private float dayFogDensity; // �� ������ fog �е�.
    private float currentFogDensity; // ���.

    void Start()
    {
        dayFogDensity = RenderSettings.fogDensity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, 0.1f * secondPerRealTimeSecound * Time.deltaTime);

        if (transform.eulerAngles.x >= 170)
        {
            GameManager.isNight = true;
        }
        else if (transform.eulerAngles.x <= 10)
        {
            GameManager.isNight = false;
        }

        if (GameManager.isNight)
        {
            if (currentFogDensity <= nightFogDensity)
            {
                currentFogDensity += 0.1f * fogDensityClac * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
            }
        }
        else
        {
            if (currentFogDensity >= dayFogDensity)
            {
                currentFogDensity -= 0.1f * fogDensityClac * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
            }
        }
    }
}
