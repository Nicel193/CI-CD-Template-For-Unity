#addin nuget:?package=Cake.Unity&version=0.9.0

var target = Argument("target", "Build-Android");

Task("Clean-Artifacts")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
{
    CleanDirectory($"./artifacts");
});

Task("Build-Android")
    .IsDependentOn("Clean-Artifacts")
    .Does(() =>
{
    // FilePath unityEditorPath = new FilePath("D:\\All_Programs\\Unity\\Editor\\2022.3.10f1\\Editor\\Unity.exe");

    UnityEditor(
        2022, 3,
        new UnityEditorArguments
        {
            ExecuteMethod="Editor.Builder.BuildAndroid",
            BuildTarget=BuildTarget.Android,
            LogFile = "./artifacts/unity.log",
            ProjectPath = "./",
        },
        new UnityEditorSettings
        {
            RealTimeLog = true,
        });
});


RunTarget(target);