using UnityEngine;

public class UniversalZoom : MonoBehaviour
{
    [Header("Zoom Settings")]
    public float zoomSpeedMouse = 0.5f; // ngatur kecepatan zoom dengan scroll mouse
    public float zoomSpeedTouch = 0.01f; // ngatur kecepatan zoom dengan pinch di layar sentuh

    [Header("Scale Limits")]
    public float minScale = 0.5f; //ngatur ukuran minimum objek saat di zoom out
    public float maxScale = 1.2f; //ngatur ukuran maksimum objek saat di zoom in

    void Update()
    {
        MouseZoom();
        TouchZoom();
    }

    // LAPTOP / UNITY EDITOR
    void MouseZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); //fungsi buat ngebaca input scroll mouse. 
        

        if (scroll != 0)
        {
            ScaleObject(scroll * zoomSpeedMouse);
        }
    }

    // HP / MOBILE PINCH
    void TouchZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);
            //2 line diatas punya fungsi buat cek apa ada 2 jari yang touch layar

            Vector2 touch0PrevPos =
                touch0.position - touch0.deltaPosition;

            Vector2 touch1PrevPos =
                touch1.position - touch1.deltaPosition;
            // 4 line diatas punya fungsi buat ngitung posisi sebelumnya dari kedua sentuhan dengan mengurangi posisi saat ini dengan perubahan posisi (deltaPosition) dari masing-masing sentuhan.
            
            float prevMagnitude =
                (touch0PrevPos - touch1PrevPos).magnitude;
            float currentMagnitude =
                (touch0.position - touch1.position).magnitude;
            // 2 line diatas (Magnitude) punya fungsi buat ngitung jarak antara kedua sentuhan untuk posisi sebelumnya dan posisi saat ini. 
            // Ini penting untuk menentukan seberapa banyak zoom yang harus diterapkan berdasarkan perubahan jarak antara kedua sentuhan.
            
            float difference =
                currentMagnitude - prevMagnitude;
            ScaleObject(difference * zoomSpeedTouch);
            // punya fungsi untuk cek jarak kedua sentuhanyang sudah terekam dan menyesuaikan ukuran object berdasarkan perubahan jarak tersebut.
        }
    }

    void ScaleObject(float increment) //fungsi untuk menambah ukuran tiap ada zoom in / out
    {
        Vector3 newScale =
            transform.localScale + Vector3.one * increment;

        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
        newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);
        //fungsi untuk memastikan skala ada berada di scale min dan max yang sudah ditentukan.

        transform.localScale = newScale;
    }
}
