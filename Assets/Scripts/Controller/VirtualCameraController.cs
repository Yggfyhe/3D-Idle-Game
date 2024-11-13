using UnityEngine;
using Cinemachine;
using System.Collections;

public class VirtualCameraController : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera;
    public float rotationSpeed = 15f;
    public float transitionDelay = 3f;

    public IEnumerator IntroCamera()
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDelay)
        {
            mainCamera.transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        mainCamera.Priority = 0;
    }
}
