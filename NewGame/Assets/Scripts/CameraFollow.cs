using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Dummy;

    float cameraOffset = -10f;
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(Dummy.transform.position.x, Dummy.transform.position.y, cameraOffset);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
    }
}
