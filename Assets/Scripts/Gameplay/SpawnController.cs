using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static GameObject enemy;
    public static void SpawnEnemies(int NumOfEnemies)
    {
        for (int i = 0; i < NumOfEnemies; i++)
        {
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-16, 16), UnityEngine.Random.Range(-10, 10), 0);
            Quaternion rot = Quaternion.identity;

            Instantiate((GameObject)Resources.Load("Enemy"), pos, rot);


        }
    }
}

