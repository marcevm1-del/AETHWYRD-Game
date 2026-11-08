#!/bin/bash
# usage: phase_run.sh <tag> <shotprefix> <windows...>   (coordinator helper: scene, tests, player, screenshots; one Unity at a time)
cd /e/Ideas/Project-Ascend
U="E:/Unity/Editors/6000.6.7f1/Editor/Unity.exe"; L="E:/Ideas/Project-Ascend/Game/Logs"; T=$1; P=$2; shift 2
"$U" -batchmode -projectPath Game -logFile "$L/${T}_scene.log" -quit -executeMethod Ascend.EditorTools.Ring0SceneBuilder.BuildBatch; echo "scene $?"
"$U" -batchmode -projectPath Game -logFile "$L/${T}_tests.log" -runTests -testPlatform PlayMode -testResults "$L/${T}_tests.xml"; echo "tests $?"
"$U" -batchmode -projectPath Game -logFile "$L/${T}_player.log" -quit -executeMethod Ascend.EditorTools.BuildPlayer.BuildRing0; echo "player $?"
for w in "$@"; do
  Game/Builds/Ring0/ProjectAscend.exe -screen-width 1600 -screen-height 900 -screen-fullscreen 0 -ascendShot "E:/Ideas/Project-Ascend/13_Production/${P}_$w.png" -ascendShotWindow $w -logFile "$L/${T}_shot_$w.log"; echo "shot $w $?"
done
echo ALLDONE
