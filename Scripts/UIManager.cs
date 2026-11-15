using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class UIManager : MonoBehaviour
{
    public GameObject foreground;
    public GameObject background;
    public choiceManager choiceManager;

    private string chosen = null;

    void Start()
    {
        GameObject foreground = GetComponent<GameObject>();
        GameObject background = GetComponent<GameObject>();
        choiceManager choiceManager = GetComponent<choiceManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async public Task<string> OpenInterface()
    {
        foreground.SetActive(true);
        background.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Start Interface");
        try
        {
            chosen = await choiceManager.ReturnAChoice();
            return chosen;
        }
        finally
        {
            Debug.Log("End Interface");
            CloseInterface();
        }
    }

    public void CloseInterface()
    {
        Time.timeScale = 1f;
        foreground.SetActive(false);
        background.SetActive(false);
    }

    public async Task<string> ChosenThing()
    {
        return await OpenInterface();
    }
}
