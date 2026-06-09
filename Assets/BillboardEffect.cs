using UnityEngine;

public class BillboardFaceCamera : MonoBehaviour
{
    private Camera _cam;

    void Start()
    {
        _cam = Camera.main; //mencari kamera utama di scene
    }

    void LateUpdate()
    {
        if (_cam == null) return;

        // Arahkan transform ini ke kamera
        transform.LookAt(transform.position + _cam.transform.rotation * Vector3.forward, //Punya fungsi agar target mengarah ke kamera
                         _cam.transform.rotation * Vector3.up);
    }
}