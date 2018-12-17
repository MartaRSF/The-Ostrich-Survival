using UnityEngine;
using System.Collections;

public class PlayerC : MonoBehaviour{

	
	[SerializeField]
    private string horizontalnputName;
	[SerializeField]
    private string verticallnputName;
	[SerializeField] private float movementSpeed;
    [SerializeField] private float movementSpeedTemp;
   public float speed;
    private CharacterController charController;
	private bool isJumping;
	private bool Correr;
	[SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
	[SerializeField] private KeyCode jumpKey;
	[SerializeField] private KeyCode correrKey;
	[SerializeField]
	private Estados health;
	
    private void Awake ()
    {
        charController = GetComponent<CharacterController>();
		
    }

    private void Update ()
    {
        PlayerMovement();
		
    }
	
	private void PlayerMovement()
	{
		float horizInput=Input.GetAxis(horizontalnputName)*movementSpeed;
		float vertInput=Input.GetAxis(verticallnputName)*movementSpeed;
		
		Vector3 forwardMovement =transform.forward*vertInput;
		Vector3 rightMovement=transform.right*horizInput;
		charController.SimpleMove(forwardMovement+rightMovement);
		JumpInput();
		CorrerInput();
	}
	
	private void JumpInput()
	{
		if(Input.GetKeyDown(jumpKey) && !isJumping)
		{
			isJumping=true;
			StartCoroutine(JumpEvent());
			
		}
		
	}
	private void CorrerInput()
	{
		Vector3 pos=transform.position;
		float CurrentSpeed=movementSpeed;
		if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(jumpKey) && !Correr)
		{
			Correr=true;
			CurrentSpeed=speed;
			
		}
		else{
			Correr=false;
			CurrentSpeed=movementSpeed;
		}
	}

	
	private IEnumerator JumpEvent()
	{
		charController.slopeLimit=90.0f;
		float timeInAir=0.0f;
		
		do{
			float jumpForce=jumpFallOff.Evaluate(timeInAir);
			charController.Move(Vector3.up*jumpForce*jumpMultiplier*Time.deltaTime);
			timeInAir+=Time.deltaTime;
			yield return null;
			
		}while(!charController.isGrounded && charController.collisionFlags!=CollisionFlags.Above);
		isJumping=false;
		charController.slopeLimit=45.0f;
	}
	
}