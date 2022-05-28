using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonPosition : MonoBehaviour
{
    public Transform startPot;
    public Transform endPot;
    public float speed = 1.0f;
    public AudioSource wings;

    float startTime;
    float totalDistance;

    // Start is called before the first frame update
    public IEnumerator Start()
    {
        startTime = Time.deltaTime;
        totalDistance = Vector3.Distance(startPot.position, endPot.position);

        yield return RepeatLerp(startPot.position, endPot.position, 3.0f);
        Debug.Log("dragonPosition Start");
        wings.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float currentDutation = (Time.time - startTime) * speed;
        float journeyFraction = currentDutation / totalDistance;
        this.transform.position = Vector3.Lerp(startPot.position, endPot.position, journeyFraction);
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            this.transform.position = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
