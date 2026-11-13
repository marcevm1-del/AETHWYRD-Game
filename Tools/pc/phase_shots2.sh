#!/bin/bash
# usage: phase_shots2.sh <tag> <front screens...>   (player build + front-end screenshots)
cd /e/Ideas/Project-Ascend
U="E:/Unity/Editors/6000.6.7f1/Editor/Unity.exe"; L="E:/Ideas/Project-Ascend/Game/Logs"; T=$1; shift
"$U" -batchmode -projectPath Game -logFile "$L/${T}_player.log" -quit -executeMethod Ascend.EditorTools.BuildPlayer.BuildRing0; echo "player $?"
for w in "$@"; do
  Game/Builds/Ring0/ProjectAscend.exe -screen-width 1600 -screen-height 900 -screen-fullscreen 0 -ascendFront $w -ascendShot "E:/Ideas/Project-Ascend/13_Production/phase1b_$w.png" -logFile "$L/${T}_shot_$w.log" > /dev/null 2>&1; echo "shot $w $?"
done
echo ALLDONE
