using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrolle : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        var x1 = Input.GetAxis("Horizontal") * Time.deltaTime;
        var z1 = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(0, z1, 0);
        transform.Rotate(0,0, -x1);
    }
}
