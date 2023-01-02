using System;
using UnityEditor;
using UnityEditor.Build.Reporting;

public static class ProjectBuilder
{
    private const string ApkPath = "../../artifacts/AsteroidsECS.apk";
    private const string Level1Path = "Assets/Asteroids/Scenes/Level 1.unity";

    [MenuItem("Build/Build Android")]
    public static void BuildAndroid()
    {
        var report = BuildPipeline.BuildPlayer(
           new BuildPlayerOptions
           {
               target = BuildTarget.Android,
               locationPathName = ApkPath,
               scenes = new[] { Level1Path },
           });

        if (report.summary.result != BuildResult.Succeeded)
            throw new Exception("Failed to build Android package. See log for details.");
    }
}