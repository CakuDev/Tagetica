using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchChat;

public class PointerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 25f;
    [SerializeField] private Rigidbody2D pointerRb;

    // Counters for each input. Increase when an user send a message in chat
    private readonly Dictionary<string, int> inputCounters = new()
    {
        {Direction.Up, 0},
        {Direction.Down, 0},
        {Direction.Left, 0},
        {Direction.Right, 0},
        { Direction.Stop, 0 }
    };
    // Dictionary with the current input for each user
    private readonly Dictionary<string, string> usersInput = new();
    private Vector3 direction = Vector3.zero;

    void Start()
    {
        TwitchController.onTwitchMessageReceived += CheckInputsOnMessage;
    }

    private void OnDestroy()
    {
        TwitchController.onTwitchMessageReceived -= CheckInputsOnMessage;
    }

    private void FixedUpdate()
    {
        MovePointer();
    }

    private void CheckInputsOnMessage(Chatter chatter)
    {
        string message = chatter.message.ToLower();
        if (message.Equals("u"))
        {
            AddInputCounterValue(chatter.tags.displayName, Direction.Up);
        }
        if (message.Equals("d"))
        {
            AddInputCounterValue(chatter.tags.displayName, Direction.Down);
        }
        if (message.Equals("l"))
        {
            AddInputCounterValue(chatter.tags.displayName, Direction.Left);
        }
        if (message.Equals("r"))
        {
            AddInputCounterValue(chatter.tags.displayName, Direction.Right);
        }
        if (message.Equals("s"))
        {
            AddInputCounterValue(chatter.tags.displayName, Direction.Stop);
        }
    }

    private void AddInputCounterValue(string username, string newInput)
    {
        // Check first if it isn't the first input send by the user
        if(usersInput.ContainsKey(username))
        {
            // Do nothing if it's the same input than his/her current one
            string previousInput = usersInput[username];
            if (previousInput.Equals(newInput)) return;

            // If not, decrease the counter of his/her current input and increase the counter of the new one
            inputCounters[previousInput] = inputCounters[previousInput] - 1;
            inputCounters[newInput] = inputCounters[newInput] + 1;
            usersInput[username] = newInput;
        } else
        {
            // If it's his/her first input, increase its counter and the input by user registry
            inputCounters[newInput] = inputCounters[newInput] + 1;
            usersInput[username] = newInput;
        }
        CalculateNewDirection();
    }

    private void CalculateNewDirection()
    {
        // Get the total input to use it in the percentage calcs
        var totalInputs = 0;
        foreach (var (key, value) in inputCounters)
        {
            totalInputs += value;
        }

        // If all the inputs are removed, use zero vector to avoid divide by zero exception
        if(totalInputs == 0)
        {
            direction = Vector3.zero;
            return;
        }
        var horizontalValue = GetAxisForcePercentage(inputCounters[Direction.Right], inputCounters[Direction.Left], totalInputs);
        var verticalValue = GetAxisForcePercentage(inputCounters[Direction.Up], inputCounters[Direction.Down], totalInputs);
        direction = new(horizontalValue, verticalValue, 0);
    }
     
    private float GetAxisForcePercentage(int positiveValue, int negativeValue, int totalInputs)
    {
        // Calculate the percentage of the axis by the total of inputs. Must be a number between 0 and 1
        var absoluteValue = positiveValue - negativeValue;
        var percentage = (float) absoluteValue / totalInputs;
        return percentage;
    }

    private void MovePointer()
    {
        pointerRb.AddForce(speed * Time.deltaTime * direction, ForceMode2D.Impulse);
    }
}
