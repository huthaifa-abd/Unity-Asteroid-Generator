using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Linq;

[ExecuteInEditMode]
public class Asteroid_Generator : MonoBehaviour
{

    public GameObject[] AsteroidModelsList;
    public int NoiseValue = 3;
    public int XRange = 10;
    public int YRange = 10;
    public int YIncrement = 2;
    public int XIncrement = 3;
    public bool SetRandomSizes = false;
    public float MaxAsteroidSize = 1;
    public float MinAsteroidSize = 0.1f;
    public bool SetAnimation = false;
    public int AnimationSpeed = 1;


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

    public void funcApplyGizmo(string GizmoName, float CastDistance, Collider GizmoCollider, bool _issub)
    {
        float AffectedObjectCount = 0;
        var tempList = transform.Cast<Transform>().ToList();
        foreach (var child in tempList)
        {

            if (_issub)
            {
                if (RaycastTest(child.gameObject, CastDistance, GizmoName))
                {
                    DestroyImmediate(child.gameObject);
                    AffectedObjectCount++;
                }
            }
            else
            {
                if (!RaycastTest(child.gameObject, CastDistance, GizmoName))
                {
                    DestroyImmediate(child.gameObject);
                    AffectedObjectCount++;
                }
            }

        }

        Debug.Log("Affected Object Count : " + AffectedObjectCount.ToString());
    }

    public bool RaycastTest(GameObject Object, float CastDistance, string TargetName)
    {
        //RaycastHit hit;
        //bool is_hit = false;
        bool _inside = false;

        //Vector3 forward = Object.transform.TransformDirection(Vector3.forward);
        //if (Physics.Raycast(Object.transform.position, forward, out hit, CastDistance))
        //    if (hit.transform.name == TargetName)
        //    {
        //        is_hit = true;
        //    }


        //Vector3 backward = Object.transform.TransformDirection(Vector3.back);
        //if (Physics.Raycast(Object.transform.position, backward, out hit, CastDistance))
        //    if (hit.transform.name == TargetName)
        //    {
        //        is_hit = true;
        //    }


        //Vector3 upward = Object.transform.TransformDirection(Vector3.up);
        //if (Physics.Raycast(Object.transform.position, upward, out hit, CastDistance))
        //    if (hit.transform.name == TargetName)
        //    {
        //        is_hit = true;
        //    }



        //Vector3 downward = Object.transform.TransformDirection(Vector3.down);
        //if (Physics.Raycast(Object.transform.position, downward, out hit, CastDistance))
        //    if (hit.transform.name == TargetName)
        //    {
        //        is_hit = true;
        //    }


        Vector3[] raycastDirections = new Vector3[5];
        raycastDirections[0] = new Vector3(0, 1, 0);
        raycastDirections[1] = new Vector3(0, -1, -0);
        raycastDirections[2] = new Vector3(0, 0, 1);
        raycastDirections[3] = new Vector3(-1.41f, 0, -0.5f);
        raycastDirections[4] = new Vector3(1.41f, 0, -0.5f);
        int hitcount = 0;

        foreach (Vector3 direction in raycastDirections)
        {
            Debug.DrawRay(Object.transform.position - CastDistance * direction, direction * CastDistance, Color.green);
            if (Physics.Raycast(Object.transform.position - CastDistance * direction, direction))
            {
                hitcount++;
            }
        }

        if (hitcount >= 5)
            _inside = true;
        else
            _inside = false;

        return _inside;
    }
    public void funcGenerateAsteroid()
    {
        GameObject AsteroidPrefab = AsteroidModelsList[0];

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
        if (AsteroidModelsList.Length > 0)
        {
            //Generate Random Prefab
            int SelectedIndex = Random.Range(0, AsteroidModelsList.Length);
            Asteroid = Instantiate(AsteroidModelsList[SelectedIndex], YMovement, Random.rotation) as GameObject;
            Asteroid.transform.parent = transform;

            //Generate Random Size
            if (SetRandomSizes)
            {
                float RandomSize = Random.RandomRange(MinAsteroidSize, MaxAsteroidSize);
                Asteroid.transform.localScale += new Vector3(RandomSize, RandomSize, RandomSize);
            }

            // Attach Animation Script
            if (SetAnimation)
            {
                Asteroid.AddComponent<AsteroidAnimation>();
                //Get Asteroid Animaion Handler
                AsteroidAnimation AstAnim = Asteroid.GetComponent<AsteroidAnimation>();
                AstAnim.speed = AnimationSpeed;
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

            // Attach Animation Script
            if (SetAnimation)
            {
                Asteroid.AddComponent<AsteroidAnimation>();
                //Get Asteroid Animaion Handler
                AsteroidAnimation AstAnim = Asteroid.GetComponent<AsteroidAnimation>();
                AstAnim.speed = AnimationSpeed;
            }

        }
        return YMovement;
    }




}