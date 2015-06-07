using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Presentation;

public class PresentationHandler : MonoBehaviour{
	public List<GameObject> characterList; 

	private int locationInCharacterList = 0;
	private GameObject currentChar;

	public Camera camRef;
	private CameraSmoothFollow camSmoothFollow;


	void Awake(){
		camSmoothFollow = camRef.GetComponent<CameraSmoothFollow>();
		
	}

	void Start(){
		locationInCharacterList = -1;
		ChangePresentation();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)){
			ChangePresentation();
		}
	}

	void ChangePresentation(){
		locationInCharacterList = modulo(locationInCharacterList+1,characterList.Count);
		currentChar = characterList[locationInCharacterList];
		
		DisableAllCharacterControllers();
		EnableCurrentCharacterController();
		SetCameraTarget(currentChar.transform);
		SwitchToStyle();
	}

	void DisableAllCharacterControllers(){
		foreach(GameObject character in characterList){
			BasicController bc = character.GetComponent<BasicController>();
			bc.Stop();
			bc.enabled = false;
		}
	}

	void EnableCurrentCharacterController(){
		currentChar.GetComponent<BasicController>().enabled = true;
	}

	void SetCameraTarget(Transform t){
		camSmoothFollow.target = t;
	}

    public void SwitchToStyle()
    {
    	PresentationStyle ps = currentChar.GetComponent<PresentationObject>().presentationStyleAttribute;

    	if (ps == PresentationBase.instance.presentationStyle)
    		return;

        PresentationBase.instance.presentationStyle = ps;
        PresentationBase.instance.CastSwitch();
    }	

    int modulo(int dividend, int divisor) {
 		return (((dividend) % divisor) + divisor) % divisor;
		}

}