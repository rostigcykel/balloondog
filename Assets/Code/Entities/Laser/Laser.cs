using System;
using Assets.Code.Constants;
using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public float velocityX;
    public float velocityY;

    private bool isActive;
	// Use this for initialization
	void Awake ()
	{
	    isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(isActive)
	    {
	        transform.Translate(-velocityX, velocityY, 0f);
	    }
	}

    void OnActivate()
    {
        isActive = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var targetGameObject = collision.gameObject;

        if (targetGameObject.tag.Equals(PlayerConstants.PlayerTag, StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Laser Collision");
            targetGameObject.SendMessage("OnDeath");
        }
    }
}
