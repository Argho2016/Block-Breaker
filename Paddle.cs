using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //Confuguraton parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);

        float mousePositionUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddleposition = new Vector2(transform.position.x, transform.position.y);
        paddleposition.x = Mathf.Clamp(mousePositionUnits, minX, maxX);
        transform.position = paddleposition;
	}
}
