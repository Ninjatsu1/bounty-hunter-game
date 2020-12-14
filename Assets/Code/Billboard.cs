using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform mainCamera;

    // Turns object always to look at camera
    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCamera.forward);
    }
}
