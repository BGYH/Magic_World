using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonAnim : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;
    public float speed = 3f;
    public float duration = 5f;

    // Start is called before the first frame update
    public IEnumerator Start()
    {
        //this.gameObject.SetActive(true);
        minScale = transform.localScale = new Vector3(0, 0, 0);
        yield return RepeatLerp(minScale, maxScale, duration);
        Debug.Log("dragonAnim Start");
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        //minScale = transform.localScale = new Vector3(0, 0, 0);

        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }

        Debug.Log("RepeatLerp OK");
    }
}
