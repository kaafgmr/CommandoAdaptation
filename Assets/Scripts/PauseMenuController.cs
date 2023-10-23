using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;

    private GameObject lastMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        lastMenu = pauseMenu;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnMenu();
        }
    }

    public void ReturnMenu()
    {
        bool isActive = lastMenu.activeInHierarchy;

        if (lastMenu == pauseMenu)
        {
            pauseMenu.SetActive(!isActive);
            Time.timeScale = isActive ? 1.0f : 0.0f;
        }
        else if (lastMenu == settingsMenu)
        {
            settingsMenu.SetActive(!isActive);
            pauseMenu.SetActive(isActive);
            lastMenu = pauseMenu;
        }
    }

    public void SetLastMenu(GameObject menu)
    {
        lastMenu = menu;
    }
}
