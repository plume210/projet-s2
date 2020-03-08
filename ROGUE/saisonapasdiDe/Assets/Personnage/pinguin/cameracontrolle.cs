using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrolle : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        var x1 = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z1 = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f;
        var y1 = Input.GetAxis("Jump");
        var x2 = Input.GetAxisRaw("Horizontal")* Time.deltaTime * 150.0f;
        transform.Translate(z1,0,-x1);
    }
}
