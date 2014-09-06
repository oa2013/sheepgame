#pragma strict

//generate folders in our project

import System.IO;

//add menu item to generate folders w/ names
@MenuItem("Project Tools/Make Folders")
static function MakeFolders()
{
	var projectPath	: String = Application.dataPath + "/";
	
	Directory.CreateDirectory(projectPath + "Audio");
	Directory.CreateDirectory(projectPath + "Fonts");
	Directory.CreateDirectory(projectPath + "Materials");
	Directory.CreateDirectory(projectPath + "Meshes");
	Directory.CreateDirectory(projectPath + "Packages");
	Directory.CreateDirectory(projectPath + "Physics");
	Directory.CreateDirectory(projectPath + "Prefabs");
	Directory.CreateDirectory(projectPath + "Resources");
	Directory.CreateDirectory(projectPath + "Scenes");
	Directory.CreateDirectory(projectPath + "Scripts");
	Directory.CreateDirectory(projectPath + "Shaders");
	Directory.CreateDirectory(projectPath + "Textures");
	
	AssetDatabase.Refresh();
}