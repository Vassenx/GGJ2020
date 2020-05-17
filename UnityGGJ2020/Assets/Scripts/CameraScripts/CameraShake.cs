using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float radius = 10f;
    [SerializeField] private float intensity = 10;
    [SerializeField] private float duration = 1f;

    private float timeElapsed;

    private Vector3 randomPos;
    private Vector3 lastPos;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void ShakeCamera()
    {
        lastPos = mainCamera.transform.position;

        StartCoroutine(ShakeLerp());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ShakeCamera();
        }
    }

    IEnumerator ShakeLerp()
    {
        timeElapsed = 0;

        while (timeElapsed <= duration)
        {
            randomPos = Random.insideUnitSphere * radius + mainCamera.transform.position;
            mainCamera.transform.position = new Vector3(randomPos.x, randomPos.y, mainCamera.transform.position.z);

            timeElapsed += Time.deltaTime + (1/intensity);
            yield return new WaitForSeconds(1/intensity);
        }

        mainCamera.transform.position = lastPos;
    }
}
