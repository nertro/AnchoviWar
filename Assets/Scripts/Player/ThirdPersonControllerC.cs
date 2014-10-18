using UnityEngine;
using System.Collections;

public class ThirdPersonControllerC : MonoBehaviour {

    public AnimationClip idleAnimation;
    public AnimationClip walkAnimation;
    public string Joystick;

    public float walkMaxAnimationSpeed = 0.75F;

    private Animation _animation;

    enum CharacterState
    {
        Idle = 0,
        Walking = 1,
    }
    private CharacterState _characterState;
    // The speed when walking
    public float walkSpeed = 2.0F;

    // The camera doesnt start following the target immediately but waits for a split second to avoid too much waving around.
    private float lockCameraTimer = 0.0F;

    // The current move direction in x-z
    private Vector3 moveDirection = Vector3.zero;

    private float rotateSpeed = 0.5f;

    // The last collision flags returned from controller.Move
    private CollisionFlags collisionFlags;

    // Are we moving backwards (This locks the camera to not do a 180 degree spin)
    private bool movingBack = false;
    // Is the user pressing any keys?
    private bool isMoving = false;

    private bool isControllable = true;

    // Use this for initialization
    void Awake(){
        moveDirection = transform.TransformDirection(Vector3.forward);
   
         _animation = GetComponent<Animation>();
        if(!_animation)
        Debug.Log("The character you would like to control doesn't have animations. Moving her might look weird.");
   
        if(!idleAnimation) {
            _animation = null;
            Debug.Log("No idle animation found. Turning off animations.");
        }
        if(!walkAnimation) {
            _animation = null;
            Debug.Log("No walk animation found. Turning off animations.");
        }
               
    }
    void UpdateSmoothedMovementDirection(){
        Transform cameraTransform = GameObject.FindGameObjectWithTag(Joystick+"Cam").transform;
       
        // Forward vector relative to the camera along the x-z plane   
        Vector3 forward= cameraTransform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;
     
        // Right vector relative to the camera
        // Always orthogonal to the forward vector
         Vector3 right= new Vector3(forward.z, 0, -forward.x);
     
        float v= Input.GetAxis(Joystick+" Vertical");
        float h= Input.GetAxis(Joystick+" Horizontal");
     
        // Are we moving backwards or looking backwards
        if (v < 0f)
            movingBack = true;
        else
            movingBack = false;
       
        bool wasMoving= isMoving;
        isMoving = Mathf.Abs (h) != 0 || Mathf.Abs (v) != 0;
           
        // Target direction relative to the camera
        Vector3 targetDirection= h * right + v * forward;

        moveDirection = targetDirection.normalized;
        
        // Lock camera for short period when transitioning moving  standing still
        lockCameraTimer += Time.deltaTime;
        if (isMoving != wasMoving)
            lockCameraTimer = 0.0f;
        
        _characterState = CharacterState.Idle;
        
    }
    
 
    void Update()
    {

        UpdateSmoothedMovementDirection();

        if (isMoving)
        {
            // Calculate actual motion
            Vector3 movement = moveDirection * walkSpeed;
            movement *= Time.deltaTime;

            // Move the controller
            CharacterController controller = GetComponent<CharacterController>();
            collisionFlags = controller.Move(movement);

            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //  Debug.DrawRay(hit.point, hit.normal);
        if (hit.moveDirection.y > 0.01f)
            return;
    }
    float GetSpeed()
    {
        return walkSpeed;
    }

    Vector3 GetDirection()
    {
        return moveDirection;
    }

    public bool IsMovingBackwards()
    {
        return movingBack;
    }

    public float GetLockCameraTimer()
    {
        return lockCameraTimer;
    }

    bool IsMoving()
    {
        return Mathf.Abs(Input.GetAxisRaw(Joystick+" Vertical")) + Mathf.Abs(Input.GetAxisRaw(Joystick+" Horizontal")) > 0;
    }

    void Reset()
    {
        gameObject.tag = "Player";
    }

}