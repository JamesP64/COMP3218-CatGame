using UnityEngine;

public class StarsCollected : MonoBehaviour
{
    public static StarsCollected Instance;
    public int stars = 0;
    public int totalStars = 0;
    public bool level2;
    public bool level3;
    public bool level4;
    public int maxLevel1;
    public int maxLevel2;
    public int maxLevel3;
    public int maxLevel4;

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

    public void max(int level, int number)
    {
        if(level == 1 && number > maxLevel1)
        {
            maxLevel1 = number;
        }
        if(level == 2 && number > maxLevel2)
        {
            maxLevel2 = number;
        }
        if(level == 3 && number > maxLevel3)
        {
            maxLevel3 = number;
        }
        if(level == 4 && number > maxLevel4)
        {
            maxLevel4 = number;
        }
    }
}
