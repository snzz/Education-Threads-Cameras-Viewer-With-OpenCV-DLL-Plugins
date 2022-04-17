# Education-Threads-Cameras-Viewer-With-OpenCV-DLL-Plugins
Программа для просмотра онлайн камер AXIS в режиме реального времени с обработкой изображения с помощью алгоритмов OpenCV. Алгоритмы поставляются с помощью DLL плагинов. В программе реализован класс для работы с плагинами под функции с различным количеством параметров.
## Краткое описание API, который должен быть реализован в плагинах для работы с приложением (Значения возвращаются в str):
* GetPluginFunctionName(char* str) - Возвращает названия функции в плагине (легко доработать для большего числа функций)

* GetFunctionType(char* str) - Возвращает тип функции (не возвращаемый), который даёт информацию главному приложению о возвращаемом типе и количестве, типах параметров

* GetGUIComponentsNames(char* str) - Возвращает имена графических компонентов, необходимых для работы плагина

* GetGUISettings(char* str) - Параметры для создания графических компонентов

* GetPluginDescription(char* str) - Возвращает описание плагина
    
## Примеры обработки изображений

![изображение](https://user-images.githubusercontent.com/61936377/163707564-30be6c35-48e3-4d63-bb44-2da5ef3956eb.png)

![изображение](https://user-images.githubusercontent.com/61936377/163707602-67d0d69a-67dc-4deb-a542-6ab5c846705e.png)