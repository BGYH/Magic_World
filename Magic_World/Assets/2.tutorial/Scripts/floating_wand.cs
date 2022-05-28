using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating_wand : MonoBehaviour
{
    //public float turn_speed = 0.07f;
    public float floating_speed = 0.07f;
    Vector3 position;
    public float time;
    public float time_fly;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        time_fly = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0f, 20f, 0f) * Time.deltaTime , Space.World);
        time += Time.deltaTime;
        time_fly += Time.deltaTime;

        if (time_fly < 1.5f)
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * floating_speed, Space.World);
        }

        else if (time_fly >= 1.5f)
        {
            this.transform.Translate(Vector3.down * Time.deltaTime * floating_speed, Space.World);

            if (time_fly >= 3.0f)
            {
                time_fly = 0;
            }
        }
    }
}
