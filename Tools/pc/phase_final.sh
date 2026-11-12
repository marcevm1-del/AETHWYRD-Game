#!/bin/bash
cd /e/Ideas/Project-Ascend
bash Tools/pc/phase_full.sh $1
bash Tools/pc/phase_shots2.sh ${1}s title menu creator loading
