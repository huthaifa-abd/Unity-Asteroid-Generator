using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Asteroid_Generator))]
class AsteroidGeneratorEditior : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate Asteroid"))
        {
            Asteroid_Generator ScriptHandler = (Asteroid_Generator)target;
            ScriptHandler.funcGenerateAsteroid();
        }

        if (GUILayout.Button("Clear Asteroid"))
        {
            Asteroid_Generator ScriptHandler = (Asteroid_Generator)target;
            ScriptHandler.funcClearAsteroid();
        }
    }

    

}