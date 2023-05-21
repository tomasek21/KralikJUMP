using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Hráč, za kterým bude kamera následovat
    public float smoothSpeed = 0.125f; // Hladkost pohybu kamery
    public Vector3 offset; // Ofset pozice kamery vzhledem k hráči
    public float minX; // Minimální X pozice kamery
    public float maxX; // Maximální X pozice kamery

    void LateUpdate()
    {
        float targetX = Mathf.Clamp(target.position.x, minX, maxX);
        Vector3 desiredPosition = new Vector3(targetX, target.position.y, target.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
