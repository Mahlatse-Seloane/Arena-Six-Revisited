using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    private Camera mainCam;
    private Vector3 originalPos;
    private Coroutine currentCoroutine;

    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        mainCam = Camera.main;
    }

    public void ShakeCamera(float amount, float duration)
    {
        if (currentCoroutine != null) 
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(DelayExecution(amount, duration));
    }

    private IEnumerator DelayExecution(float amount, float duration = 0f)
    {
        originalPos = mainCam.transform.localPosition;

        while (duration > 0)
        {
            StartCameraShake(amount);
            duration -= Time.deltaTime;
            yield return null;
        }

        StopCameraShake();
    }

    private void StartCameraShake(float amount)
    {
        if (amount <= 0.0)
            return;

        Vector3 camPos = originalPos;
        float offsetX = Random.value * amount * 2 - amount;
        float offsetZ = Random.value * amount * 2 - amount;
        camPos.x += offsetX;
        camPos.z += offsetZ;

        mainCam.transform.localPosition = camPos;
    }

    public void StopCameraShake()
    {
        mainCam.transform.localPosition = originalPos;
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }
    }
}