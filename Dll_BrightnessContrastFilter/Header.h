#pragma once
#include "pch.h"
#include <omp.h>
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <stdexcept> 
#include <iostream>
#include "opencv2/imgcodecs.hpp"
#include "opencv2/highgui.hpp"
#include <string.h>

#define DLLEXPORT extern "C" __declspec(dllexport)

//API functions
DLLEXPORT void GetPluginFunctionName(char* str);
DLLEXPORT void GetFunctionType(char* str);
DLLEXPORT void GetGUIComponentsNames(char* str);
DLLEXPORT void GetGUISettings(char* str);
DLLEXPORT void GetPluginDescription(char* str);
//Main plugin function
DLLEXPORT HBITMAP BrightnessContrastFilter(BYTE* image, char* datalen, char* alpha, char* beta);