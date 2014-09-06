#pragma strict

//generate prefab for selected object

@MenuItem("Project Tools/Make Prefab")
static function MakePrefab()
{
	var selectedObjects	: GameObject[] = Selection.gameObjects;
	
	if(selectedObjects.length > 0)
	{
		for(var GO : GameObject in selectedObjects)
		{
			var localPath	: String = "Assets/" + GO.name + ".prefab";
			
			if(!AssetDatabase.LoadAssetAtPath(localPath, GameObject))
			{
				CreatePrefab(GO, localPath);
			}
			else if(EditorUtility.DisplayDialog("Replace Existing Prefab?",
			"You already prefabbed this. Want to change it?", "Sure", "Not Really"))
			{
				CreatePrefab(GO, localPath);
			}
		}
		AssetDatabase.Refresh();
	}
}

static function CreatePrefab(GO : GameObject, localPath : String)
{
	var prefab = PrefabUtility.CreateEmptyPrefab(localPath);
	PrefabUtility.ReplacePrefab(GO, prefab);
	
	DestroyImmediate(GO);
	var clone = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
}