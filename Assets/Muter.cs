using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public float rotateSpeed = 10f; // kecepatan putar

    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f); // fungsi untuk memutar planet secara terus menerus pada sumbu Y dengan kecepatan yang ditentukan oleh rotateSpeed.
    }
}