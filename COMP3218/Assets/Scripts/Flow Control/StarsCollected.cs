using UnityEngine;

public class StarsCollected : MonoBehaviour
{
    public static StarsCollected Instance;
    public int stars = 0;
    public int totalStars = 0;
    public bool level2;
    public bool level3;
    public bool level4;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int getTotalStars()
    {
        return totalStars;
    }

    void increaseTotalStars() 
    {
        totalStars += 1;
    }
}
