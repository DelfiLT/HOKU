using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Vector3 target;
    private Camera mainCamera;
    private float initialAngle = 90;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        target = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        float radAngles = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        float degreeAngle = (180 / Mathf.PI) * radAngles - initialAngle;
        transform.rotation = Quaternion.Euler(0, 0, degreeAngle);
    }
}
