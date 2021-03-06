using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
  float dist;
    bool dragging = false;
    bool lockForce = false;
    Vector3 offset;
    Vector3 pos;
    Touch touch;
    Vector3 v3;
    Transform toDrag;

    [SerializeField] GameObject menu;
[SerializeField] GameObject sling;
[SerializeField] GameObject cam;
[SerializeField] Rigidbody rb;
[Header("Power settings")]
[SerializeField] float maxDrag;
[SerializeField] float forceShot;

private void Update()
{
    SliceShot();


}
private void LateUpdate()
{

    if (lockForce && rb.velocity.magnitude == 0f)
    {
        menu.SetActive(true);
    }
}
void SliceShot()
{


    if (Input.touchCount == 1)
    {
        touch = Input.GetTouch(0);
        pos = touch.position;
    }

    pos = Input.mousePosition;

    if ((Input.GetMouseButtonDown(0) || touch.phase == TouchPhase.Began) && !lockForce)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "cube")
            {
                toDrag = hit.transform;

                dist = hit.transform.localPosition.z - Camera.main.transform.localPosition.z;
                v3 = new Vector3(pos.x, pos.y, dist);
                v3 = Camera.main.ScreenToWorldPoint(v3);


                offset = toDrag.position - v3;
                dragging = true;
            }
        }
    }
    if (dragging && (Input.GetMouseButton(0) || touch.phase == TouchPhase.Moved))
    {
        v3 = new Vector3(pos.x, pos.y, dist);

        v3 = Camera.main.ScreenToWorldPoint(v3);
        if (v3.z < 6f)
        {
            v3.z = 6f;
        }
        if (v3.y < 67f)
        {
            v3.y = 67f;
        }
        if (v3.x > 11f)
        {
            v3.x = 11f;
        }
        if (v3.x < -11f)
        {
            v3.x = -11f;
        }
        toDrag.position = v3 + offset;

    }
    if (dragging && (Input.GetMouseButtonUp(0) || touch.phase == TouchPhase.Ended))
    {
        Vector3 release = sling.transform.position - rb.position;
        Vector3 clampedForce = Vector3.ClampMagnitude(release, maxDrag);
        rb.AddForce(clampedForce * forceShot, ForceMode.Impulse);
        rb.useGravity = true;
        dragging = false;
        cam.SetActive(true);
        lockForce = true;
    }
}
}