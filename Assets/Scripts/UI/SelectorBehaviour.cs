using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class SelectorBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textValue;
    [SerializeField] private List<string> values;
    [SerializeField] private UnityEvent<string> onChange;

    // Called when clicked the left button
    public void MoveLeft()
    {
        int index = values.FindIndex(value => value == textValue.text);

        // Manage left boundary
        if (index == 0) return;

        // Set the previous value
        textValue.text = values[index - 1];

        onChange?.Invoke(textValue.text);
    }

    public void MoveRight()
    {
        int index = values.FindIndex(value => value == textValue.text);

        // Manage right boundary
        if (index == values.Count - 1) return;

        // Set the next value
        textValue.text = values[index + 1];

        onChange?.Invoke(textValue.text);
    }
}
