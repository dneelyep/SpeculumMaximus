using UnityEngine;
using System.Collections;

public class LaserBolt : MonoBehaviour {

	public float vel = .1f;
	public Vector3 direction = new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(vel * direction);

		//if laser leaves board, destroy it
		if (this.transform.position.x > 10.5 || this.transform.position.y > 10.5 || this.transform.position.x <-0.5 || this.transform.position.y <-0.5)
			Destroy(this);
		if (this.transform.position.z >4 || this.transform.position.z < 0)
			throw new UnityException("laser flew off in z direction. It shouldn't do that");
	}
	//put code to signal to main program that laser section is finished.
	void OnDestroy()
	{
		GameState.InGameState = GameState.InGameState.Moving;
		GameState.changePlayer();
	}
}
