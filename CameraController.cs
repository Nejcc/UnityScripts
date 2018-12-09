using UnityEngine;
using System.Collections;
 
public class CameraController : MonoSingleton<CameraController> {
     
    [Header("Movement Config:")]
    [SerializeField] float mainSpeed = 10.0f; //regular speed
    [SerializeField] float shiftAdd = 20.0f; //multiplied by how long shift is held.
    [SerializeField] float maxShift = 30.0f; //Maximum speed when hold shift
    [SerializeField] float camSens = 0.25f; //How sensitive it with mouse

	  [Header("Zoon Config:")]
    [SerializeField] float zoomSpeed = 0.25f;
    [SerializeField] float zoomPosition = 10f;
    [SerializeField] float zoomMin = 5f;
    [SerializeField] float zoomMax = 20f;

	  public Vector3 kkx; // test
    private Vector3 lastMouse = new Vector3(255, 255, 255); //the middle of the screen, rather than at the top at play
    private float totalRun= 1.0f;
     
    void Update () {
        lastMouse = Input.mousePosition - lastMouse ;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0 );
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x , transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse =  Input.mousePosition;
        //Mouse  camera angle done.  
       
        //Keyboard commands
        // float f = 0.0f;
        Vector3 p = GetBaseInput();
        if (Input.GetKey (KeyCode.LeftShift)){
            totalRun += Time.deltaTime;
            p  = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else{
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }
       
        p = p * Time.deltaTime;

       	Vector3 newPosition = transform.position;

        if (Input.GetKey(KeyCode.Space)){ //If player wants to move on X and Z axis only
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        else{
            // transform.Translate(p);

 			      // space : Moves camera on X and Z axis only.  So camera doesn't gain any height 
            // DELETE THIS BELOW IF YOU WANT FREE HEIGHT CONTROL
			      //TODO:  add scroll wheel for zoom range
			      transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
       
    }
     
    private Vector3 GetBaseInput() { //returns the basic values, if it's 0 than it's not active.

		HexMapGenerator hex = new HexMapGenerator();

		kkx =  transform.position;

		// TODO: set border for camera to move
		
		// if(hex.mapWidth >= transform.position.x AND )
		// {
		// 	Debug.Log("Position z:"+ transform.position.z );
		// }
		// else{
		// 	Debug.Log("Position zz:"+ transform.position.z );
		// }

        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            p_Velocity += new Vector3(0, 0 , 1);
        }
        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
