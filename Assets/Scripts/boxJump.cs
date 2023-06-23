using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxJump : MonoBehaviour
{
    protected float Animation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animation += Time.deltaTime;

        Animation = Animation % 5f;

        transform.position = MathParabola.Parabola(Vector3.zero, Vector3.right * 10f, 5f, Animation / 5f);
    }
}
