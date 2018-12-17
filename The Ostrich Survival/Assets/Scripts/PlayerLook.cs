using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

	[SerializeField] private string mouseXInputName,mouseYInputName;
	[SerializeField] private float mouseSensitivity;
	
	private float xAxisClamp;
	
	[SerializeField] private Transform playerbody;
	private void Awake()
	{
		Cursor.lockState=CursorLockMode.Locked;
		xAxisClamp=0.0f;
	}
	// Use this for initialization
	void Start () {
		
	}
	private void LockCursor()
	{
		Cursor.lockState=CursorLockMode.Locked;
		
	}
	// Update is called once per frame
	void Update () {
		CameraRotation();
	}
	
	private void CameraRotation()
	{
		float mouseX=Input.GetAxis(mouseXInputName)*mouseSensitivity*Time.deltaTime;
		float mouseY=Input.GetAxis(mouseYInputName)*mouseSensitivity*Time.deltaTime;
		
		xAxisClamp+=mouseY;
		if(xAxisClamp>90.0f)
		{
			xAxisClamp=90.0f;
			mouseY=0.0f;
			ClampAxisRotationToValue(270.0f);
		}
		else if(xAxisClamp<-90.0f)
		{
			xAxisClamp=-90.0f;
			mouseY=0.0f;
			ClampAxisRotationToValue(90.0f);
		}
		
		transform.Rotate(Vector3.left*mouseY);
		playerbody.Rotate(Vector3.up*mouseX);
	}
	
	private void ClampAxisRotationToValue(float value)
	{
		Vector3 eulerRotation=transform.eulerAngles;
		eulerRotation.x=value;
		transform.eulerAngles=eulerRotation;
	}
}
