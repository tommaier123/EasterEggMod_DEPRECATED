using UnityEngine;
using UMod;
using Synth.mods.utils;
using Synth.mods.events;
using UnityEngine.SceneManagement;
using System.Collections;

public class EasterScript : ModScript, ISynthRidersEvents
{
    public GameObject egg = null;

    public override void OnModLoaded()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    public override void OnModUnload()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    public void OnRoomLoaded()
    {

    }

    public void OnRoomUnloaded()
    {

    }

    public override void OnModUpdate()
    {
        
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name.Contains("Stage"))
        {
            egg = ModAssets.Instantiate<GameObject>("Easter_pre");
        }
        else{
            EggScript.DestroyEggScript();
            UnityEngine.Object.Destroy(egg);
            egg = null;
        }
    }

    public void OnGameStageLoaded(TrackData trackData)
    {
        
    }

    public void OnGameStageUnloaded()
    {
        EggScript.DestroyEggScript();
        UnityEngine.Object.Destroy(egg);
        egg = null;
    }

    public void OnScoreStageLoaded()
    {

    }

    public void OnScoreStageUnloaded()
    {

    }

    public void OnNoteFail(PointsData pointsData)
    {

    }

    public void OnPointScored(PointsData pointsData)
    {

    }

    public void OnSongFinished(SongFinishedData songFinishedData)
    {

    }


    public void OnSongFailed(TrackData trackData)
    {

    }
}
