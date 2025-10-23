using Nelson;
using UnityEngine;

public class RazorBladeGameManager : MicroGameManager
{
    [SerializeField] GameObject candyPrefab;
    [SerializeField] Vector2 spawnAmountRange = new Vector2(1, 2);
    [SerializeField] Vector2 spawnArea = new Vector2(1, 2);
    bool bladeSpawned = false;
    private void Start()
    {
        SpawnCandies();
    }
    public override void OnStartMicroGame()
    {

    }
    public override void OnEndMicroGame()
    {
    }
    private void SpawnCandies()
    {
        int spawnAmount = Random.Range((int)spawnAmountRange.x, (int)spawnAmountRange.y);
        for(int i = 0; i < spawnAmount; i++)
        {
            float spawnX = Random.Range(-spawnArea.x, spawnArea.x);
            float spawnY = Random.Range(-spawnArea.y, spawnArea.y);
            Vector2 spawnLocation = new Vector2(spawnX, spawnY);
            GameObject currentCandy = Instantiate(candyPrefab, new Vector3(spawnLocation.x, spawnLocation.y, 0), Quaternion.identity);

            float proabability = (float)i / ((float)spawnAmount - 1);
            if (Random.value <= proabability && !bladeSpawned)
            {
                bladeSpawned = true;
                currentCandy.GetComponent<ClickOnCandy>().HasRazor();
            }
        }
    }
}
