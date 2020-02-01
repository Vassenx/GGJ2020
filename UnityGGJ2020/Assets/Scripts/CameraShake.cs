using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float radius;
    [SerializeField] private float intensity;

    private float timeElapsed;
    private float startTime;

    private Vector3 randomPos;
    private Vector3 lastPos;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void ShakeCamera()
    {
        randomPos = Random.insideUnitSphere * radius;
        lastPos = mainCamera.transform.position;

        StartCoroutine(ShakeLerp());
    }

    IEnumerator ShakeLerp()
    {
        timeElapsed = 0;
        startTime = Time.time;

        while (timeElapsed <= 1f)
        {
            timeElapsed += Time.deltaTime * (Time.time - startTime);
            mainCamera.transform.position = (randomPos - lastPos) * timeElapsed;
            yield return new WaitForEndOfFrame();
        }
    }
}
