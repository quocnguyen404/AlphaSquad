using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetFollow = null;
    public Vector3 targetOffset;
    public float lerpRate = 40f;


    private void LateUpdate()
    {
        Vector3 targetPos = targetFollow.position + Vector3.up * targetOffset.y + Vector3.right * targetOffset.x + Vector3.forward * targetOffset.z;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpRate * Time.deltaTime);
    }
}
