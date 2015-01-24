using Assets.Code.Entities.Doggie;
using UnityEngine;
using System.Collections;

public class PlayerStatsFeedbackController : MonoBehaviour
{
    private DoggieController doggie;
    public GUIText guiText;
	// Use this for initialization
	void Start ()
	{
	    doggie = GameObject.Find("Player").GetComponent<DoggieController>();
        guiText.richText = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    guiText.richText = true;
	    guiText.text = string.Format("Current Charge: {0} \n Current Acceleration: {1} \n Current Position: {2} \n Current Velocity: {3} \n Current Timescale{4}",
	                                 doggie.currentCharge, doggie.currentAcceleration, doggie.transform.position, doggie.rigidbody2D.velocity, Time.timeScale);
	}
}
