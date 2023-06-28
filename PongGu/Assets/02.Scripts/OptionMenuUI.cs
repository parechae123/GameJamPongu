using UnityEngine;

public class OptionMenuUI : MonoBehaviour
{
    public GameObject optionMenu;

    private void Start()
    {
        optionMenu.SetActive(false);
    }

    public void ToggleOptionMenu()
    {
        bool isActive = optionMenu.activeSelf;
        optionMenu.SetActive(!isActive);
    }

    public void CloseOptionMenu()
    {
        optionMenu.SetActive(false);
    }
}
