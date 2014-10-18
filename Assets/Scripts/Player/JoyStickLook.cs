using UnityEngine;
using System.Collections;

public class JoyStickLook : MonoBehaviour {
    public float sensitivityX = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public string Joystick;

    float rotationY = 0F;

    void Update()
    {
        transform.Rotate(0, Input.GetAxis(Joystick + " Look X") * sensitivityX, 0);
        
    }

    void Start()
    {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }
}
