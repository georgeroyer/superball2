using UnityEngine;

public class FreelookCamera : MonoBehaviour {	
	[Tooltip("Default speed in m/s")]
	public float Speed = 10;
	[Tooltip("Wether to use the faster speed option while holder Shift")]
	public bool EnableFastSpeed = true;
	[Tooltip("Speed in m/s while holding Shift")]
	public float FastSpeed = 20;

	[Tooltip("The speed at which your camera rotates when moving the mouse")]
	public float MouseSensitivity = 3;

	[Tooltip("Wether the freelook is initially enabled")]
	public bool IsEnabled = true;							//intern isEnabled bool. The reason we dont use MonoBehaviour's .enabled property is so that we can turn it back on again with the hotkey

	[Tooltip("Wether to lock the cursor while using the freelook camera")]
	public bool LockCursor = true;

	[Tooltip("The hotkey used to enable or disable the freelook camera script")]
	public KeyCode HotKey = KeyCode.T;				//hotkey used for enabling or disabling the freelook script

	private Quaternion originalRotation;
	private float rotationX;
	private float rotationY;

	private Transform myTransform;			//cache of the .tranform property for better performance

	private bool wasUsingKinematic;			//was the (if attached) rigidbody using Kinamtic mode before the freelook was enabled?

	// Use this for initialization
	public void Start () {
		myTransform = transform;
		originalRotation = myTransform.localRotation;

		if(IsEnabled)
			EnableNoClip();
	}

	//called by unity
	public void OnEnable() {
		if(IsEnabled)
			EnableNoClip();
	}

	//called by unity
	public void OnDisable() {
		if(IsEnabled)
			DisableNoClip();
	}
	
	// Update is called once per frame
	public void Update () {
		#region Inputhandling
		//handle enabling/disabling of the component
		if( Input.GetKeyUp (HotKey) ) {
			if( IsEnabled ) {
				DisableNoClip();
			}
			else {
				EnableNoClip();
			}
		}

		//lock the cursor if specified to do so in the inspector
		if(LockCursor)
			Screen.lockCursor = true;

		//Get the speed based on user input
		float currentForwardSpeed = Speed;
		float currentSidewardSpeed = Speed;
		if(EnableFastSpeed && Input.GetKey(KeyCode.LeftShift)) {
			currentForwardSpeed = FastSpeed;
			currentSidewardSpeed = FastSpeed;
		}
		#endregion

		if(!IsEnabled) return;

		#region MouseLook
		// Read the mouse input axis
		rotationX += Input.GetAxis("Mouse X") * MouseSensitivity;
		rotationY += Input.GetAxis("Mouse Y") * MouseSensitivity;

		rotationY = Mathf.Clamp(rotationY, -89f, 89f);

		Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

		myTransform.rotation = originalRotation * xQuaternion * yQuaternion;
		#endregion

		#region Movement
		currentForwardSpeed = Input.GetAxis ("Vertical") * currentForwardSpeed;
		currentSidewardSpeed = Input.GetAxis("Horizontal") * currentSidewardSpeed;
		
		currentForwardSpeed = Mathf.Clamp(currentForwardSpeed,-15f,15f);
		currentForwardSpeed *= Time.deltaTime;
		
		currentSidewardSpeed = Mathf.Clamp(currentSidewardSpeed,-15f,15f);
		currentSidewardSpeed *= Time.deltaTime;

		Vector3 dir = myTransform.forward;
		Vector3 left = myTransform.right;
		myTransform.position = myTransform.position + ( (dir * currentForwardSpeed) + (left * currentSidewardSpeed) );
		#endregion
	}
	
	/// <summary>
	/// Enables the freelook camera, disabling or configuring any other component that might be present and interfere with the freelook camera
	/// </summary>
	private void EnableNoClip() {
		//Integration with the Unity's standard assets' character motor. If you are not using this, you can delete the following 4 lines
		Behaviour motor = gameObject.GetComponent("CharacterMotor") as MonoBehaviour;
		if (motor != null) {
			motor.enabled = false;
		}

		//enables isKinematic on the rigidbody, if present. (this saves the previous state, to not interfere with your own game logic)
		Rigidbody body = gameObject.GetComponent<Rigidbody>();
		if (body != null) {
			wasUsingKinematic = body.isKinematic;
			if (!body.isKinematic) {
				body.isKinematic = true;
			}
		}
		
		IsEnabled = true;
	}
	
	/// <summary>
	/// Disables the freelook camera, enabling or configuring any other component that might be present and interfere with the freelook camera
	/// </summary>
	private void DisableNoClip() {
		//Integration with the Unity's standard assets' character motor. If you are not using this, you can delete the following 4 lines
		Behaviour motor = gameObject.GetComponent("CharacterMotor") as MonoBehaviour;
		if(motor != null) {
			motor.enabled = true;
		}

		//disables isKinematic on the rigidbody if it was before, if present.
		Rigidbody body = gameObject.GetComponent<Rigidbody>();
		if(body != null) {
			if (!body.isKinematic) return;		//the body isKinematic was set to false by something for some reason, no need to force the saved value

			body.isKinematic = wasUsingKinematic;
		}
		
		IsEnabled = false;
	}
}