using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Asteroid_Generator : MonoBehaviour
{
    public GameObject SamplePrefab;
    public int NoiseValue = 3;
    public int XRange = 10;
    public int YRange = 10;
    public int YIncrement = 2;
    public int XIncrement = 3;

    public int count = 0;
    void Update()
    {
        if (SamplePrefab != null && count == 0)
        {
            Vector3 OriginalPos = transform.position;
            Vector3 YMovement = OriginalPos;
            for (int i = 0; i < XRange; i++)
            {
                for (int j = YRange - i; j > 0; j--)
                {
                    Instantiate(SamplePrefab, YMovement, transform.rotation);
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
                    Instantiate(SamplePrefab, YMovement, transform.rotation);
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
                    Instantiate(SamplePrefab, YMovement, transform.rotation);
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
                    Instantiate(SamplePrefab, YMovement, transform.rotation);
                    YMovement.y -= 2;
                    YMovement.z = Random.Range(-1 * NoiseValue, NoiseValue);
                }
                YMovement.y = OriginalPos.y;
                YMovement.x += XIncrement;

            }

            transform.position = OriginalPos;
            YMovement = OriginalPos;


            count = 1;
        }

       
    }
}