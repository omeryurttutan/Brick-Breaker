using UnityEngine;

    public class LevelManager : MonoBehaviour
    {
        public LevelLoadType levelLoadType;
        public static LevelManager instance;
        public SOLevels levelSO;
        public int currentLevelIndex = 0;
        private Level currentLevel;
        public int currentLevelIndexPlus;
        
        private void Awake()
        {
           ;
            if (instance==null)
            {
                instance = this;
            
            }
            else
            {
                Destroy(this);
            }
        }

        public void LoadLevel()
        {
            if (currentLevelIndex < levelSO.levels.Count)
            {
                currentLevel = Instantiate(levelSO.levels[currentLevelIndex]);
                lastLevelIndex = currentLevelIndex;
            }
            else
            {
                Debug.LogError("Level Bitti");
                if (levelLoadType==LevelLoadType.Order)
                {
                    currentLevel = Instantiate(levelSO.levels[orderTypeLevelIndex]);
                    if (orderTypeLevelIndex+1<levelSO.levels.Count)
                    {
                       
                        orderTypeLevelIndex++;
                    }
                    else
                    {
                        orderTypeLevelIndex = 0;
                    }
                    
                }
                else if (levelLoadType == LevelLoadType.Random)
                {
                    var random =  Random.Range(0,levelSO.levels.Count);
                    if (random == lastLevelIndex)
                    {
                        random =  Random.Range(0,levelSO.levels.Count);   
                    }
                    currentLevel = Instantiate(levelSO.levels[random]);
                    lastLevelIndex = random;
                }
            }
        }

        private int lastLevelIndex;
        private int orderTypeLevelIndex;
        public void NextLevel()
        {
            DestroyLevel();
            currentLevelIndex++;
            currentLevelIndexPlus++;
            LoadLevel();
            BallManager.instance.SpawnBall();
            InGameUI.instance.SetActiveLifePanel(true);
            PowerUpManager.instance.DestroyPowerUp();
            InGameUI.instance.SetLevelCountText();
        }

        public void RetryLevel()
        {
            DestroyLevel();
            LoadLevel();
            BallManager.instance.SpawnBall();
            InGameUI.instance.SetActiveLifePanel(true);
            PowerUpManager.instance.DestroyPowerUp();
            InGameUI.instance.SetLevelCountText();
        }

        public void DestroyLevel()
        {
            Destroy(currentLevel.gameObject);
        }
    }
public enum LevelLoadType
{
    Random=0,
    Order=1,
}

