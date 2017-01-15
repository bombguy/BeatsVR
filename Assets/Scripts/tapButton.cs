using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnMouseDown()
    {
        //GameObject Tap = (GameObject)Instantiate(this.deathParticles, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
        //Destroy(Tap, 1);
    }
}
