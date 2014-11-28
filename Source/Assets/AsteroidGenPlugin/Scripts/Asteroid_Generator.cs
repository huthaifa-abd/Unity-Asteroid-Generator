using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Linq;

[ExecuteInEditMode]
public class Asteroid_Generator : MonoBehaviour
{

    public GameObject[] SamplePrefab;
    public int NoiseValue = 3;
    public int XRange = 10;
    public int YRange = 10;
    public int YIncrement = 2;
    public int XIncrement = 3;
    public bool SetRandomSizes = false;
    public float MaxAsteroidSize = 1;
    public float MinAsteroidSize = 0.1f;
    

    void Update()
    {
    }

    public void funcClearAsteroid()
    {
        var tempList = transform.Cast<Transform>().ToList();
        foreach (var child in tempList)
        {
            DestroyImmediate(child.gameObject);
        }

    }
    public void funcGenerateAsteroid()
    {
        GameObject AsteroidPrefab = SamplePrefab[0];

        if (AsteroidPrefab != null)
        {
            Vector3 OriginalPos = transform.position;
            Vector3 YMovement = OriginalPos;
            for (int i = 0; i < XRange; i++)
            {
                for (int j = YRange - i; j > 0; j--)
                {
                    //Generate Asteroid
                    InstantiateAsteroid(AsteroidPrefab, YMovement);

                    YMovement.y += YIncrement;
                    YMovement.z = Random.Range(-1 * NoiseValue, NoiseValue);
                }
                YMovement.y = OriginalPos.y;
                YMovement.x += XIncrement;


            }

            transform.position = OriginalPos;
            YMovement = OriginalPos;

            for (int i = 0; i < XRange; i++)
            {
                for (int j = YRange - i; j > 0; j--)
                {
                    InstantiateAsteroid(AsteroidPrefab, YMovement);
                    YMovement.y += YIncrement;
                    YMovement.z = Random.Range(-1 * NoiseValue, NoiseValue);
                }
                YMovement.y = OriginalPos.y;
                YMovement.x -= 3;

            }

            transform.position = OriginalPos;
            YMovement = OriginalPos;

            for (int i = 0; i < XRange; i++)
            {
                for (int j = YRange - i; j > 0; j--)
                {
                    InstantiateAsteroid(AsteroidPrefab, YMovement);
                    YMovement.y -= 2;
                    YMovement.z = Random.Range(-1 * NoiseValue, NoiseValue);
                }
                YMovement.y = OriginalPos.y;
                YMovement.x -= 3;

            }

            transform.position = OriginalPos;
            YMovement = OriginalPos;

            for (int i = 0; i < XRange; i++)
            {
                for (int j = YRange - i; j > 0; j--)
                {
                    InstantiateAsteroid(AsteroidPrefab, YMovement);
                    YMovement.y -= 2;
                    YMovement.z = Random.Range(-1 * NoiseValue, NoiseValue);
                }
                YMovement.y = OriginalPos.y;
                YMovement.x += XIncrement;

            }

            transform.position = OriginalPos;
            YMovement = OriginalPos;



        }
    }

    private Vector3 InstantiateAsteroid(GameObject AsteroidPrefab, Vector3 YMovement)
    {
        GameObject Asteroid;
        if (SamplePrefab.Length > 0)
        {
            //Generate Random Prefab
            int SelectedIndex = Random.Range(0, SamplePrefab.Length);
            Asteroid = Instantiate(SamplePrefab[SelectedIndex], YMovement, Random.rotation) as GameObject;
            Asteroid.transform.parent = transform;

            //Generate Random Size
            if (SetRandomSizes)
            {
                float RandomSize = Random.RandomRange(MinAsteroidSize, MaxAsteroidSize);
                Asteroid.transform.localScale += new Vector3(RandomSize, RandomSize, RandomSize);
            }

        }
        else
        {

            Asteroid = Instantiate(AsteroidPrefab, YMovement, Random.rotation) as GameObject;
            Asteroid.transform.parent = transform;

            //Generate Random Size
            if (SetRandomSizes)
            {
                float RandomSize = Random.RandomRange(MinAsteroidSize, MaxAsteroidSize);
                Asteroid.transform.localScale += new Vector3(RandomSize, RandomSize, RandomSize);
            }
        }
        return YMovement;
    }


}