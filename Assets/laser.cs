using UnityEngine;
using System.Collections;

public class laser : Piece {

	public int laserVel = 5;
    private int rotateDir = 0;
	public Transform bolt;

	// Use this for initialization
    void Start()
    {
        switch (this.team)
        {
            case (Team.White):
                this.orientation = new Vector3(0, 1, 0);
                break;
            case (Team.Black):
                this.orientation = new Vector3(0, -1, 0);
                break;
            default:
                this.orientation = new Vector3(0, 0, 0);
                break;
        }
        return;

    }
	// Update is called once per frame
	void Update () {
        //check if we are rotating.
        if (rotateDir != -1)
        {
            //rotate the piece. If we hare 
            this.transform.Rotate(new Vector3(0, 0, 1) * rotateVel * rotateDir);
            if ((int)this.transform.rotation.x % 90 == 0)
            {
                this.rotateDir = 0;
            }
        }
	}

	public override bool Move(Vector3 direction)
	{
		return false;
	}
	
	public void fire()
	{
		//TODO: fill this code in
		Instantiate (bolt,this.transform.position);
		//TODO: customiz this so the bolt goes in the right direction
		((laserBolt)bolt).direction = new Vector3(0,0,0);
		
	}
}
