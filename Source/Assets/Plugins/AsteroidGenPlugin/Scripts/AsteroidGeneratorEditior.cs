using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Asteroid_Generator))]
class AsteroidGeneratorEditior : Editor
{
    public GameObject objGizmo;
    public bool _issub = false;
    public override void OnInspectorGUI()
    {

        string texture = "Assets/AsteroidGenPlugin/Textures/Logo.png";
        Texture2D inputTexture = (Texture2D)AssetDatabase.LoadAssetAtPath(texture, typeof(Texture2D));

        GUILayout.Label(inputTexture);

        //Draw the default gui elements
        DrawDefaultInspector();

        

        if (GUILayout.Button("Generate Asteroid"))
        {
            Asteroid_Generator ScriptHandler = (Asteroid_Generator)target;
            //Clear Previous asteroids
            ScriptHandler.funcClearAsteroid();
            //Generate new asteroids set
            ScriptHandler.funcGenerateAsteroid();
        }

        if (GUILayout.Button("Clear Asteroid"))
        {
            Asteroid_Generator ScriptHandler = (Asteroid_Generator)target;
            //Generate new asteroids set
            ScriptHandler.funcClearAsteroid();
        }

        GUILayout.Label("Gizmo Configuration");
        GUILayout.Label("Used to add or subtract asteroid regions");

        
       objGizmo = (GameObject)EditorGUILayout.ObjectField("Gizmo Mesh", objGizmo, typeof(GameObject), true);
       _issub = EditorGUILayout.Toggle("Subtract Region", _issub);

        if (GUILayout.Button("Apply Gizmo"))
        {
            Asteroid_Generator ScriptHandler = (Asteroid_Generator)target;
            //Apply Gizmo Collision
            if (objGizmo != null)
            {
                //Set Gizmo Layermask
                objGizmo.layer = 8;
                ScriptHandler.funcApplyGizmo(objGizmo.name, 1000f, objGizmo.GetComponent<Collider>(), _issub);
            }
            else
                Debug.LogError("Gizmo Object is null , make sure its avaliable");
            
        }
       
        GUILayout.Label("Asteroid Generation Plugin v0.1");

        

    }

    

}