using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("References")]
    public HealthHandler PlayerHealthScript;
    public GameObject[] LifePointsObjects;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerHealthScript == null)
        {
            Debug.LogError("PlayerHealthScript non è definito!");

            PlayerHealthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthHandler>();
        }

        UpdateLifePointUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifePointUI();
    }

    void UpdateLifePointUI()
    {
        for(int i = 0; i < LifePointsObjects.Length; i++)
        {
            if (i < PlayerHealthScript.GetCurrentHealth())
            {
                LifePointsObjects[i].SetActive(true);
            }
            else
            {
                LifePointsObjects[i].SetActive(false);
            }
        }
    }
}
