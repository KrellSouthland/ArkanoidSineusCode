using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject startMenu, InstructionMenu;

    public void StartGame()
    {
        startMenu.SetActive(false);
        GameState.Instance.ClickState(true);
    }

    public void ToInstruction()
    {
        startMenu.SetActive(false);
        InstructionMenu.SetActive(true);
    }

    public void ToStart()
    {

        startMenu.SetActive(true); 
        InstructionMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
