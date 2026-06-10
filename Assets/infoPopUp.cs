using UnityEngine;
using System.Collections;

public class TapToShowInfo : MonoBehaviour
{
    public GameObject infoQuad;
    public float animDuration = 0.3f;

    private bool isShowing = false;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = infoQuad.transform.localScale;
        infoQuad.SetActive(false);
        infoQuad.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        // Touch saja, hapus mouse input
        if (Input.touchCount == 1 && 
            Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Toggle();
        }

        // Mouse hanya untuk Editor PC (tidak jalan di Android)
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Toggle();
        }
        #endif
    }

    void Toggle()
    {
        isShowing = !isShowing;
        StopAllCoroutines();

        if (isShowing)
        {
            infoQuad.SetActive(true);
            StartCoroutine(ScaleTo(Vector3.zero, originalScale));
        }
        else
        {
            StartCoroutine(ScaleToThenHide(originalScale, Vector3.zero));
        }
    }

    IEnumerator ScaleTo(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        infoQuad.transform.localScale = from;

        while (elapsed < animDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / animDuration;
            infoQuad.transform.localScale = Vector3.Lerp(from, to, t);
            yield return null;
        }

        infoQuad.transform.localScale = to;
    }

    IEnumerator ScaleToThenHide(Vector3 from, Vector3 to)
    {
        yield return StartCoroutine(ScaleTo(from, to));
        infoQuad.SetActive(false);
    }
}