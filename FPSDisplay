using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class FPSDisplay : MonoSingleton<FPSDisplay>{

	public Text fpsTextDisplay;
	public bool isFPSDisplaying = false;

	float deltaTime = 0.0f;
 
	void Update()
	{
			fpsTextDisplay.transform.localScale = new Vector3(1f, 1f, 0f);
			deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

			float msec = deltaTime * 1000.0f;
			float fps = 1.0f / deltaTime;
			string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
			fpsTextDisplay.text = text;
	}
}
