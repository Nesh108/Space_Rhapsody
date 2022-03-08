using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public GameObject DebugWindow;

    #region References
    public Player PlayerScript;
    public HealthHandler PlayerHealthScript;
    #endregion

    void Awake()
    {
#if DEBUG
        if(PlayerScript == null)
        {
            Debug.LogError("`PlayerScript` non trovato!");
            PlayerScript = FindObjectOfType<Player>();
        }

        PlayerHealthScript = PlayerScript.gameObject.GetComponent<HealthHandler>();

        DebugWindow.SetActive(false);
#else
        Destroy(DebugWindow);
        Destroy(gameObject);
#endif
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Slash))
        {
            DebugWindow.SetActive(!DebugWindow.activeSelf);
        }
    }

    [ContextMenu("ToggleInvincibility")]
    public void ToggleInvincibility()
    {
        PlayerHealthScript.DEBUG_ToggleInvincibility();
    }

    [ContextMenu("SetMaxGuns")]
    public void SetMaxGuns()
    {
        PlayerScript.SetMaxGuns();
    }

    [ContextMenu("Esegui TogglePause")]
    public void TogglePause()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
