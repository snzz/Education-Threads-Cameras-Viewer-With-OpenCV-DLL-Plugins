#include "pch.h"
#include "Header.h"
#include <string.h>
#include "opencv2/imgcodecs.hpp"
#include "opencv2/highgui.hpp"
#include <opencv2/opencv.hpp>
#include <opencv2/core/core.hpp>
#include "opencv2/imgproc/imgproc.hpp"
#include "opencv2/highgui/highgui.hpp"
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
    char source[] = "GetContours";
    sprintf_s(str, sizeof(source), source);
}

DLLEXPORT void GetFunctionType(char* str)
{
    char source[] = "2";
    sprintf_s(str, sizeof(source), source);
}

DLLEXPORT void  GetGUIComponentsNames(char* str)
{
    char source[] = "";
    sprintf_s(str, sizeof(source), source);
}

DLLEXPORT void GetGUISettings(char* str)
{
    char source[] = "";
    sprintf_s(str, sizeof(source), source);
}

DLLEXPORT void GetPluginDescription(char* str)
{
    char source[] = "Название: GetContours\nВерсия: 1.0.0\nАвтор: Кулаков И.В.\n Общее описание: плагин, предоставляющий инструменты поиска конторов объекта на изображении";
    sprintf_s(str, sizeof(source), source);
}

//Main
HBITMAP GetContours(BYTE* image, char* datalen)
{
    int length = std::stoi(datalen);
    std::vector<unsigned char> inputImageBytes(image, image + length);
    Mat _image = imdecode(inputImageBytes, cv::IMREAD_COLOR);

    //Prepare the image for findContours
    cv::cvtColor(_image, _image, COLOR_BGR2GRAY);
    cv::threshold(_image, _image, 128, 255, THRESH_BINARY);

    //Find the contours. Use the contourOutput Mat so the original image doesn't get overwritten
    std::vector<std::vector<cv::Point> > contours;
    cv::Mat contourOutput = _image.clone();
    cv::findContours(contourOutput, contours, RETR_LIST, CHAIN_APPROX_NONE);

    //Draw the contours
    cv::Mat contourImage(_image.size(), CV_8UC3, cv::Scalar(0, 0, 0));
    cv::Scalar colors[3];
    colors[0] = cv::Scalar(255, 0, 0);
    colors[1] = cv::Scalar(0, 255, 0);
    colors[2] = cv::Scalar(0, 0, 255);
    
    for (size_t idx = 0; idx < contours.size(); idx++) 
    {
        cv::drawContours(contourImage, contours, idx, colors[idx % 3]);
    }

    cv::Size size = contourImage.size();
    Bitmap bitmap(size.width, size.height, contourImage.step1(), 
        PixelFormat24bppRGB, contourImage.data);
    HBITMAP hBmp = NULL;
    bitmap.GetHBITMAP(0, &hBmp);

    return hBmp;
}