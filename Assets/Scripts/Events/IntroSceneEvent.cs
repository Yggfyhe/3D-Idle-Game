using Cinemachine;
using UnityEngine;

public class IntroSceneEvent : MonoBehaviour
{
    public float runSpeed = 5f;

    public GameObject buildingPrefab;
    public CinemachineVirtualCamera mainCamera;

    [Header("발걸음 파티클")]
    public GameObject footstepParticlePrefab;
    public Transform leftFootPosition;        
    public Transform rightFootPosition;       
    public float footstepInterval = 0.5f;     
    private float footstepTimer = 0f;        

    private Animator animator;
    private static readonly int isRunningHash = Animator.StringToHash("isRunning");
    private static readonly int runningLoopHash = Animator.StringToHash("Base Layer.Running@loop");

    private bool isMoving = false;
    private bool footstep = true;     

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isMoving)
        {
            AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

            if (currentState.fullPathHash == runningLoopHash)
            {
                transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);

                footstepTimer += Time.deltaTime;
                if (footstepTimer >= footstepInterval)
                {
                    SpawnFootstepParticle();
                    footstepTimer = 0f;
                }
            }
        }
    }
    public void IntroGM()
    {
        animator.SetBool(isRunningHash, true);
        isMoving = true;

        float newYRotation = transform.rotation.eulerAngles.y + 180f;
        transform.rotation = Quaternion.Euler(0, newYRotation, 0);

        Invoke("Disable", 5f);
    }
    private void Disable()
    {
        gameObject.SetActive(false);

        //건물소환
        Vector3 spawnPosition = new Vector3(-3.14f, 10f, -1.16f);
        Quaternion spawnRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 240f, 0);
        Instantiate(buildingPrefab, spawnPosition, spawnRotation);

        mainCamera.Priority = 0;
    }

    public void OnCallChangeFace()
    {
    }

    private void SpawnFootstepParticle()
    {
        Transform footPosition = footstep ? leftFootPosition : rightFootPosition;
        footstep = !footstep; 

        if (footstepParticlePrefab != null && footPosition != null)
        {
            Instantiate(footstepParticlePrefab, footPosition.position, Quaternion.identity);
        }
    }
}
