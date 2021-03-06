using UnityEngine;
using System.Collections;

public class LaserBolt : MonoBehaviour {

	public float vel = 5f;
	public Vector3 direction = new Vector3(0,0,0);
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(direction * vel * Time.deltaTime);

		//if laser leaves board, destroy it
		if (this.transform.position.x > 10.5 || this.transform.position.z > 10.5 || this.transform.position.x <-0.5 || this.transform.position.z <-0.5)
			Destroy(this.gameObject);
		if (this.transform.position.y >4 || this.transform.position.y < 0)
			throw new UnityException("laser flew off in z direction. It shouldn't do that");
	}
	//put code to signal to main program that laser section is finished.
	void OnDestroy()
	{
		Game.CurrentState = Game.State.Selecting;
		Game.changePlayer();
	}
}
