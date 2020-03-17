using UnityEngine;
using System.Collections;

public class LookX : MonoBehaviour {

    /**
     * Helper scripts for looking left and right within the scene and 
     * debugging without using a headset, enables mimicing headset use
     * */

	[SerializeField] float sensitivity = 5.0f;
    bool onoff;

	void Start () { onoff = true; }

    // Update is called once per frame
    void Update()
    {
        if (onoff)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            onoff = !onoff;
        }
    }
}
