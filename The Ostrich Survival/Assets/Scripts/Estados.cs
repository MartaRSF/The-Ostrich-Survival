using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Estados : MonoBehaviour {

	[SerializeField] 
	private LifeBar bar;
	
	[SerializeField] 
	private float maxVal;
	
	[SerializeField] 
	private float currentVal;
	
	public float CurrentVal
	{
		get
		{
			return currentVal;
		}
		set
		{
			this.currentVal=value;
			bar.Value=currentVal;
		}
		
	}
	
	public float MaxVal
	{
		get{
			return maxVal;
		}
		set{
			this.maxVal=value;
			bar.MaxValue=(int)maxVal;
		}
	}
	
	private void Initializate()
	{
		
	}
}
