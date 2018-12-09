using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayColider : MonoSingleton<RayColider> {
    // [SerializeField] private GameObject InteractText;
	[SerializeField] private float distance = 5f;

	void Update() {
      
      	RaycastHit hit;
      
      	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
      	if (Physics.Raycast(ray, out hit, distance)){  

			Debug.Log("Colide with tile");

			if( hit.transform.gameObject.tag == "Interact"){
				if( hit.transform.gameObject.tag == "Interact"){
					Debug.Log("Colide with interact tile");
				}
			}
			
        }

    }
}
