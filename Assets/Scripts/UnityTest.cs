using UnityEngine;

public class UnityTest : MonoBehaviour
{
    public bool ShowUpdateMessages = true;

    // OnEnable è chiamato ogni volta il componente viene abilitato
    void OnEnable()
    {
        Debug.Log("State: <color=teal>OnEnable</color>");
    }

    // OnDisable è chiamato ogni volta il componente viene disabilitato
    void OnDisable()
    {
        Debug.Log("State: <color=orange>OnDisable</color>");
    }

    // Awake è chiamato sempre prima del Start
    void Awake()
    {
        Debug.Log("State: <color=yellow>Awake</color>");
    }

    // Start è chiamato prima del primo Update, solo se il componente è attivo
    void Start()
    {
        Debug.Log("State: <color=green>Start</color>");
    }

    // Update è chiamato una volta per frame
    void Update()
    {
        if (ShowUpdateMessages)
        {
            Debug.Log("State: Update");
        }
    }

    // LateUpdate è chiamato una volta per frame sempre dopo l'Update (spesso usato per spotare la Camera)
    void LateUpdate()
    {
        if (ShowUpdateMessages)
        {
            Debug.Log("State: <color=pink>LateUpdate</color>");
        }
    }

    // FixedUpdate è chiamato sempre allo stesso intervallo, usato per la fisica
    void FixedUpdate()
    {
        if (ShowUpdateMessages)
        {
            Debug.Log("State: <color=brown>FixedUpdate</color>");
        }
    }

    // OnDestroy è chiamato quando il componente/oggetto è distrutto
    void OnDestroy()
    {
        Debug.Log("State: <color=lime>OnDestroy</color>");
    }

    // OnApplicationQuit quando l'applicazione viene chiusa
    void OnApplicationQuit()
    {
        Debug.Log("State: <color=lime>OnApplicationQuit</color>");
    }
}
