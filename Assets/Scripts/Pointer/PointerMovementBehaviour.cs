using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchChat;
using TMPro;

public class PointerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 25f;
    [SerializeField] private Rigidbody2D pointerRb;
    [SerializeField] private TextMeshProUGUI upText;
    [SerializeField] private TextMeshProUGUI downText;
    [SerializeField] private TextMeshProUGUI leftText;
    [SerializeField] private TextMeshProUGUI rightText;

    // Counters for each input. Increase when an user send a message in chat
    private readonly Dictionary<string, int> inputCounters = new()
    {
        {Direction.Up, 0},
        {Direction.Down, 0},
        {Direction.Left, 0},
        {Direction.Right, 0}
    };
    // Dictionary with the current input for each user
    private readonly Dictionary<string, string> usersInput = new();
    private Vector3 direction = Vector3.zero;
    private bool shouldMove = false;

    //private void Update()
    //{
    //    if (shouldMove) MovePointer();
    //}

    public void TestMove()
    {
        if (shouldMove)
        {
            CalculateNewDirection();
            pointerRb.velocity = Vector2.zero;
            pointerRb.AddForce(speed * direction, ForceMode2D.Impulse);
        }
    }

    private void CheckInputsOnMessage(Chatter chatter)
    {
        string message = chatter.message.ToLower();
        if (message.Equals("w"))
        {
            AddInputCounterValue(chatter.tags.displayName, Direction.Up);
        }
        if (message.Equals("s"))
        {
            AddInputCounterValue(chatter.tags.displayName, Direction.Down);
        }
        if (message.Equals("a"))
        {
            AddInputCounterValue(chatter.tags.displayName, Direction.Left);
        }
        if (message.Equals("d"))
        {
            AddInputCounterValue(chatter.tags.displayName, Direction.Right);
        }

        upText.text = inputCounters[Direction.Up].ToString();
        downText.text = inputCounters[Direction.Down].ToString();
        leftText.text = inputCounters[Direction.Left].ToString();
        rightText.text = inputCounters[Direction.Right].ToString();
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

    public void EnableMovement()
    {
        TwitchController.onTwitchMessageReceived += CheckInputsOnMessage;
        shouldMove = true;
    }

    public void ResetCounterTexts()
    {
        upText.text = "0";
        downText.text = "0";
        rightText.text = "0";
        leftText.text = "0";
        downText.text = "0";
    }

    public void DisableMovement()
    {
        TwitchController.onTwitchMessageReceived -= CheckInputsOnMessage;
        shouldMove = false;
        direction = Vector3.zero;
        transform.position = Vector3.zero;
        pointerRb.velocity = Vector2.zero;
        usersInput.Clear(); 
        inputCounters[Direction.Up] = 0;
        inputCounters[Direction.Down] = 0;
        inputCounters[Direction.Left] = 0;
        inputCounters[Direction.Right] = 0;
    }

    public void ChangeMovementForce(string value)
    {
        if (value == "Low") speed = 4;
        if (value == "Medium") speed = 6;
        if (value == "High") speed = 8;
    }
}
