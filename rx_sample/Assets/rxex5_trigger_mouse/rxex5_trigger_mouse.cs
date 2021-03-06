﻿using UnityEngine;
using System.Collections;

using UniRx;
using UniRx.Triggers;

public class rxex5_trigger_mouse : MonoBehaviour {

	//[SerializeField] private Camera active_camera;

	// Use this for initialization
	void Start () {

		float camdist = Vector3.Distance(  Camera.main.transform.position,transform.position );

		//ObservableUpdateTrigger obv_ut = this.
		//ObservableUpdateTrigger obv_ut = gameObject.AddComponent<ObservableUpdateTrigger> ();
		//ObservableUpdateTrigger obv_ut = gameObject.GetComponent<ObservableUpdateTrigger> ();
		//var obv_ut = this;

		this.OnMouseDownAsObservable ()
			.Subscribe (_ => {
				gameObject.GetComponent<Renderer>().material.color = Color.red;
			}
		);

		this.OnMouseExitAsObservable ()
			.Subscribe (
				_=> {
					gameObject.GetComponent<Renderer>().material.color = Color.green;
				}
			);

		this.OnMouseEnterAsObservable ()
			.Subscribe (
				_=> {
					gameObject.GetComponent<Renderer>().material.color = Color.blue;
				}
		);
		
		this.OnMouseDragAsObservable()
			.TakeUntilDestroy(this)          
			.Select(_ => Input.mousePosition)
			.Subscribe((pos) => {
				//camdist = 10;
				//Vector3 pos3d =  Camera.main.ScreenToWorldPoint( new Vector3(pos.x,pos.y, camdist ) );
				//this.transform.position = pos3d;
				transform.position = Camera.main.ScreenToWorldPoint( new Vector3(pos.x,pos.y, camdist ) );
			
				}
			);


	
	}
	

}
