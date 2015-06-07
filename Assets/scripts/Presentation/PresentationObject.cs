using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Presentation;

public class PresentationObject : MonoBehaviour {

	public PresentationStyle presentationStyleAttribute;
	public List<Sprite> spriteList;

	private SpriteRenderer sr;

	void Awake(){
		sr = transform.GetComponent<SpriteRenderer>();
	}

	void OnEnable(){
		PresentationBase.instance.OnSwitched += SwitchToStyle;
	}

	void OnDisable(){
		PresentationBase.instance.OnSwitched -= SwitchToStyle;
	}


	public void SwitchToStyle(){

		switch (PresentationBase.instance.presentationStyle){
			case PresentationStyle.A:
				sr.sprite = spriteList[0];
			break;
			case PresentationStyle.B:
				sr.sprite = spriteList[1];
			break;
			case PresentationStyle.C:
				sr.sprite = spriteList[2];
			break;
			case PresentationStyle.D:
				sr.sprite = spriteList[3];
			break;
		}
	}

}
