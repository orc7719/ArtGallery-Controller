using UnityEngine;
using System.Collections;

public class LookY : MonoBehaviour {

    /**
   * Helper scripts for looking up and down within the scene and 
   * debugging without using a headset, enables mimicing headset use
   * */

    [SerializeField] float sensitivityY;
    public float minimumY = -30F;
    public float maximumY = 30F;
    float rotationY = 0F;
    bool onoff;

    void Start() { onoff = true; }

    // Update is called once per frame
    void Update () {
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        //enables freezing of script to use mouse without it changing perspective
        if (onoff)
        {
            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onoff = !onoff;
        }
    }
}
