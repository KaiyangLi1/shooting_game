using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCode : MonoBehaviour {

    Vector3 pos;
    float intensity = 0.5f;
    public Transform camera;

	public IEnumerator Shake()
    {
        float t = 0;
        while(t < 1f)
        {
            t += Time.deltaTime;
            pos.x = Random.Range(-intensity, intensity);
            pos.y = Random.Range(-intensity, intensity);
            pos.z = Random.Range(-intensity, intensity);
            camera.localPosition = pos;
            yield return null;
        }
    }
}
