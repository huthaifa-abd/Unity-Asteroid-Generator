using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Asteroid_Generator))]
class AsteroidGeneratorEditior : Editor
{
    public override void OnInspectorGUI()
    {

        string texture = "Assets/AsteroidGenPlugin/Textures/Logo.png";
        Texture2D inputTexture = (Texture2D)Resources.LoadAssetAtPath(texture, typeof(Texture2D));

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


        
        GUILayout.Label("Asteroid Generation Plugin v0.1");

        

    }

    

}