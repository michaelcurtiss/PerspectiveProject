using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Presentation{

	public enum PresentationStyle{
		A,
		B,
		C,
		D
	}

	public class PresentationBase : MonoBehaviour{

		 //Here is a private reference only this class can access
	    private static PresentationBase _instance;
	 
	    //This is the public reference that other classes will use
	    public static PresentationBase instance
	    {
	        get
	        {
	            //If _instance hasn't been set yet, we grab it from the scene!
	            //This will only happen the first time this reference is used.
	            if(_instance == null)
	                _instance = GameObject.FindObjectOfType<PresentationBase>();
	            return _instance;
	        }
	    }

	   	public PresentationStyle presentationStyle = PresentationStyle.A;


	   	public delegate void StyleSwitchDelegate();
    	public event StyleSwitchDelegate OnSwitched;

    	public void CastSwitch(){
    		OnSwitched();
    	}

	}
}
