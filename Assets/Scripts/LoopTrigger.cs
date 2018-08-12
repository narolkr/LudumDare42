using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTrigger : MonoBehaviour {

	private Camera mMainCamera;

	[SerializeField]
	LayerMask loopableLayers;

	// Use this for initialization
	void Start () {
		mMainCamera = Camera.main;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Vector2 GetScreenPos(Vector2 worldPos)
	{
		return mMainCamera.WorldToScreenPoint (worldPos);
	}

	Vector2 GetWorldPos(Vector2 ScreenPos)
	{
		return mMainCamera.ScreenToWorldPoint (ScreenPos);
	}

	void WrapPosition(Collider2D collider)
	{
		Vector2 worldPos = collider.gameObject.transform.position;
		Vector2 viewPos = GetScreenPos (worldPos);
		Vector2 wrapedPos = worldPos;

		if (viewPos.x > Screen.width) {
			wrapedPos.x = GetWorldPos (new Vector2(0.0f,0.0f)).x;
		}
		else if (viewPos.x < 0.0f) {
			wrapedPos.x = GetWorldPos (new Vector2(Screen.width,0.0f)).x;
		}
		else if (viewPos.y > Screen.height) {
			wrapedPos.y = GetWorldPos (new Vector2(0.0f,0.0f)).y;
		}
		else if (viewPos.y < 0.0f) {
			wrapedPos.y = GetWorldPos (new Vector2(0.0f,Screen.height)).y;
		}
		collider.gameObject.transform.position = wrapedPos;
	}


	void OnTriggerExit2D(Collider2D collider)
	{
		if (loopableLayers == (loopableLayers | (1 << collider.gameObject.layer)))
        {
            Debug.Log("if is true: "+ collider.gameObject.layer);
            WrapPosition(collider);
        }
			
	}
}
