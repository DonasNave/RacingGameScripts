using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCycler : MonoBehaviour
{
 		public Animator animator;
    	public string[] turnAnimations;
		public string[] trafficAnimations;
    	public float cycleInterval = 5f;

    	private float timer;
    	private bool isWaiting;
    
        private void Start()
        {
            // Set the default animation
            animator.Play("Sad Idle");
    
            // Start the timer
            timer = cycleInterval;
        }
    
        private void Update()
        {
            // Decrease the timer
            timer -= Time.deltaTime;
    
            // Check if it's time to cycle animations
            if (timer <= 0f)
            {
                // Choose a random turn animation from the array
                int turnIndex = Random.Range(0, turnAnimations.Length);
                string turnAnimation = turnAnimations[turnIndex];
    
                // Play the chosen turn animation
                animator.Play(turnAnimation);
    
                // Reset the timer
                timer = cycleInterval;
              // Set the waiting flag to true
            	isWaiting = true;
        	}

        	// Check if waiting for animation to finish
        	if (isWaiting && !animator.GetCurrentAnimatorStateInfo(0).IsName("Sad Idle"))
        	{
            	// Decrease the waiting time
            	timer -= Time.deltaTime;

            	// Check if waiting time is over
            	if (timer <= 0f)
            	{
                	// Reset the waiting flag
                	isWaiting = false;
					
					int trafficIndex = Random.Range(0, trafficAnimations.Length);
					string trafficAnimation = trafficAnimations[trafficIndex];
					animator.Play(trafficAnimation);
           		}
        	}
        }
}
