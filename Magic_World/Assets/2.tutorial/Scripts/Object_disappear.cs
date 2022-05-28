using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_disappear : MonoBehaviour
{
    MeshRenderer renderer;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        renderer = target.GetComponent<MeshRenderer>();
        renderer.additionalVertexStreams.colors[0].a = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
