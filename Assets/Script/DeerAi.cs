using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeerAi : MonoBehaviour
{
    // Have an Idle, a walking state 
    [Header("To be Assigned")]
    [SerializeField]
    private Transform[] checkpoints;

    /// <summary>
    /// The time that the AI will idle for before walking
    /// </summary>
    [SerializeField]
    private float idleTime;

    /// <summary>
    /// Used as the index to access from the checkpoints array
    /// </summary>
    [SerializeField]
    private int currentCheckpoint;

    /// <summary>
    /// This stores the current state that the AI is in
    /// </summary>
    [Header("Debug Checking")]
    public string currentState;

    /// <summary>
    /// This stores the next state that the AI should transition to
    /// </summary>
    public string nextState;

    /// <summary>
    /// The NavMeshAgent component attached to the gameobject
    /// </summary>
    private NavMeshAgent agentComponent;

    private void Awake()
    {
        // Get the attached NavMeshAgent and store it in agentComponent
        agentComponent = GetComponent<NavMeshAgent>();
    }


    // Start is called before the first frame update
    void Start()
    {
        // Set the starting state as Idle
        nextState = "Idle";
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the AI should change to a new state
        if (nextState != currentState)
        {
            // Stop the current running coroutine first before starting a new one.
            StopCoroutine(currentState);
            currentState = nextState;
            StartCoroutine(currentState);
        }
    }

    public void GrabtheAnimal()
    {
        nextState = "Captured";
    }

    public void ReleasetheAnimal()
    {
        nextState = "Idle";
    }

    /// <summary>
    /// The behaviour of the AI when in the Idle state
    /// </summary>
    /// <returns></returns>
    IEnumerator Idle()
    {
        while (currentState == "Idle")
        {
            // This while loop will contain the Idle behaviour

            // The AI will wait for a few seconds before continuing.
            yield return new WaitForSeconds(idleTime);

            // Change to walking state.
            nextState = "Walking";

        }
    }
    IEnumerable Captured()
    {
        // This while loop will contain the Captured behaviour
        //do nothing
        yield return null;
    }
    /// <summary>
    /// The behaviour of the AI when in the Walking state
    /// </summary>
    /// <returns></returns>
    IEnumerator Walking()
    {
        // Set the checkpoint that this AI should move towards
        agentComponent.SetDestination(checkpoints[currentCheckpoint].position);
        bool hasReached = false;
        while (currentState == "Walking")
        {
            // This while loop will contain the Walking behaviour
            yield return null;

            if (!hasReached)
            {
                if (agentComponent.remainingDistance <= agentComponent.stoppingDistance)
                {
                    if (!agentComponent.hasPath || agentComponent.velocity.sqrMagnitude == 0f)
                    {
                        // We want to make sure this only happens once.
                        hasReached = true;
                        //Debug.Log("reached distance");
                        // Increase the index to retrieve from the checkpoints array
                        ++currentCheckpoint;
                        // A check so that the index does not exceed the length of the checkpoints array
                        if (currentCheckpoint >= checkpoints.Length)
                        {
                            currentCheckpoint = 0;
                        }

                        nextState = "Idle";
                    }
                }

            }
        }
    }
}
