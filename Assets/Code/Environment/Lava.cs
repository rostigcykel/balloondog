using System;
using Assets.Code.Constants;
using UnityEngine;

namespace Assets.Code.Environment
{
    public class Lava : MonoBehaviour {
        
	    // Use this for initialization
	    void Start () {
	        
	    }
	
	    // Update is called once per frame
	    void Update () {
	
	    }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var targetGameObject = collision.gameObject;

            if (targetGameObject.tag.Equals(PlayerConstants.PlayerTag, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("Lava Collision");
                targetGameObject.SendMessage("OnDeath");
            }
        }
    }
}
