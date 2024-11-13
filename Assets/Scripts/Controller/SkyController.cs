
using UnityEngine;

public class SkyController : MonoBehaviour
{
    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);
    }
}