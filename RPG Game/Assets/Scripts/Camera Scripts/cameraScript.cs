using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{
    public Transform target;
    public bool freezeRotation;
    public float HSpeed = 4.0F;
    public float VSpeed = -4.0F;
    public GameObject player;
   // private Vector3 offset;

    void Start()
    {
       // offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.LookAt(target);
        float h = HSpeed * Input.GetAxis("Mouse X");
        float v = VSpeed * Input.GetAxis("Mouse Y");
        // transform.position = player.transform.position + offset;
        transform.Rotate(v, h, 0);

    }
}
