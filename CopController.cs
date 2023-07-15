using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CopState
{
    Idle,
    TurningLeft,
    TurningRight,
    Warning,
    TPose,
    LeftHandOut
}

public enum Direction
{
    North,
    South,
    East,
    West
}

public class CopController : MonoBehaviour
{
    public Animator animator;
    public string[] turnAnimations;
    public string[] trafficAnimations;
    public float cycleInterval = 5f;

    public CopState copState;
    public Direction direction;

    private float timer;

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

        if (!(timer <= 0f)) return;
        var turnIndex = Random.Range(0, turnAnimations.Length);
        var turnAnimation = turnAnimations[turnIndex];

        // Play the chosen turn animation
        animator.Play(turnAnimation);

        timer = cycleInterval;
    }

    public void SetCopState(CopState newState)
    {
        copState = newState;
    }

    public void SetCopDirection(Direction newDirection)
    {
        direction = newDirection;
    }
}
