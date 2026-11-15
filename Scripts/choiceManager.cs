using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class choiceManager : MonoBehaviour
{
    public bounceBack choices;
    public Button[] buttons;
    public string chosenMove = null;
    private TaskCompletionSource<string> pendingChoice;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int j = i;
            buttons[i].onClick.AddListener(() => OnButtonClicked(j, buttons[j]));
            TMP_Text buttonText = buttons[i].transform.parent.GetChild(1).GetComponent<TMP_Text>();
            buttonText.text = choices.movesToSteal[j];
        }
        Debug.Log("Buttons Start");
    }

    void OnButtonClicked(int index, Button clickedButton)
    {
        Debug.Log($"Returning {choices.movesToSteal[index]}!");
        chosenMove = choices.movesToSteal[index];
        pendingChoice?.TrySetResult(chosenMove);
        pendingChoice = null;
    }

    public Task<string> ReturnAChoice()
    {
        chosenMove = null;
        pendingChoice = new TaskCompletionSource<string>();
        return pendingChoice.Task;
    }
}
