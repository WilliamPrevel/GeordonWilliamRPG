using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{
public float HSpeed = 40;
public float VSpeed = 40;
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        float h = HSpeed * Input.GetAxis("Mouse Y");
        float v = VSpeed * Input.GetAxis("Mouse X");
       
      //  transform.position = player.transform.position + offset;
        transform.Rotate(v, h, 0);

    }
}
