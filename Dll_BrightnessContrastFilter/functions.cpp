#include "pch.h"
#include "Header.h"
#include <string.h>
#include "opencv2/imgcodecs.hpp"
#include "opencv2/highgui.hpp"
#include <opencv2/opencv.hpp>
#include <vector>
#include <stdio.h>
#include <windows.h>
#include <objidl.h>
#include <gdiplus.h>
#include <gdiplustypes.h>
#include <gdiplusheaders.h>
#include <algorithm>
#include <minmax.h>
#pragma comment (lib,"Gdiplus.lib")

using namespace cv;
using namespace std;
using namespace Gdiplus;

//API
DLLEXPORT void GetPluginFunctionName(char* str)
{
    char source[] = "BrightnessContrastFilter";
    sprintf_s(str, sizeof(source), source);
}

DLLEXPORT void GetFunctionType(char* str)
{
    char source[] = "4A";
    sprintf_s(str, sizeof(source), source);
}

DLLEXPORT void  GetGUIComponentsNames(char* str)
{
    char source[] = "Label;TrackBar;Label;TrackBar";
    sprintf_s(str, sizeof(source), source);
}

DLLEXPORT void GetGUISettings(char* str)
{
    char source[] = "40;41;Контраст|40;60;10;30;1;164;45;1|272;41;Яркость|272;60;0;100;1;577;45;1";
    sprintf_s(str, sizeof(source), source);
}

DLLEXPORT void GetPluginDescription(char* str)
{
    char source[] = "Название: BrightnessContrastFilter\nВерсия: 1.0.0\nАвтор: Кулаков И.В.\nОбщее описание: плагин, дающий доступ к инструментам повышения яркости и констрастности изображений.";
    sprintf_s(str, sizeof(source), source);
}
//Main
Bitmap& GetBitMap(cv::Mat inputImage)
{
    cv::Size size = inputImage.size();
    Bitmap bitmap(size.width, size.height, inputImage.step1(), PixelFormat24bppRGB, inputImage.data);
    return bitmap;
}

HBITMAP BrightnessContrastFilter(BYTE* image, char* datalen, char* alpha, char* beta)
{
    double _alpha = std::stod(alpha) / 10.0;
    int _beta = std::stoi(beta);
    int length = std::stoi(datalen);
    
    std::vector<unsigned char> inputImageBytes(image, image + length);
    Mat _image = imdecode(inputImageBytes, cv::IMREAD_COLOR);

    cv::Mat new_image = cv::Mat::zeros(_image.size(), _image.type());

    for (int y = 0; y < _image.rows; y++)
    {
        for (int x = 0; x < _image.cols; x++)
        {
            for (int c = 0; c < _image.channels(); c++)
            {
                new_image.at<Vec3b>(y, x)[c] =
                    saturate_cast<uchar>(_alpha * _image.at<Vec3b>(y, x)[c] + _beta);
            }
        }
    }
    
    cv::Size size = new_image.size();
    Bitmap bitmap(size.width, size.height, new_image.step1(), PixelFormat24bppRGB, new_image.data);
    HBITMAP hBmp = NULL;
    bitmap.GetHBITMAP(0, &hBmp);

    return hBmp;
}
