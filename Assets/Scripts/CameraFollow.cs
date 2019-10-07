using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform = null;

    // Used for smooth follow
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position.Set(playerTransform.position.x, playerTransform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 cameraTargetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, this.transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, cameraTargetPosition, ref velocity, smoothTime);
    }
}
