#!/bin/bash
# usage: phase_full.sh <tag>   (Title scene, Ring0 scene, PlayMode tests, player build; one Unity at a time)
cd /e/Ideas/Project-Ascend
U="E:/Unity/Editors/6000.6.7f1/Editor/Unity.exe"; L="E:/Ideas/Project-Ascend/Game/Logs"; T=$1
"$U" -batchmode -projectPath Game -logFile "$L/${T}_title.log" -quit -executeMethod Ascend.EditorTools.TitleSceneBuilder.BuildBatch; echo "title $?"
"$U" -batchmode -projectPath Game -logFile "$L/${T}_scene.log" -quit -executeMethod Ascend.EditorTools.Ring0SceneBuilder.BuildBatch; echo "scene $?"
"$U" -batchmode -projectPath Game -logFile "$L/${T}_tests.log" -runTests -testPlatform PlayMode -testResults "$L/${T}_tests.xml"; echo "tests $?"
"$U" -batchmode -projectPath Game -logFile "$L/${T}_player.log" -quit -executeMethod Ascend.EditorTools.BuildPlayer.BuildRing0; echo "player $?"
echo ALLDONE
