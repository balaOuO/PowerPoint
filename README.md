# 2023視窗程式設計專案
此專案為
<a herf="https://woeikaechen.synology.me/wkc/">
    2023年北科大資工系視窗程式設計
</a>
課程的回家作業，藉由Windows 視窗程式來學習基本design pattern 的實作。

## Installation
本專案使用
<a herf="https://woeikaechen.synology.me/wkc/">
visual studio 2019 Community
</a>
進行開發(感謝陳偉凱老師的安裝教學)
，另外也可使用JetBrains Rider，需另外下載
<a herf="https://dotnet.microsoft.com/en-us/download/visual-studio-sdks">
.NET Framework 4.7.2
</a>。

### 檔案結構
   ```
   PowerPoint/
   │
   ├── WindowsFormsApp1/
   │   ├── View/
   │   └── ModelObject/
   │
   ├── WindowsFormsApp1Tests1/
   │
   └─── WindowsFormsApp1UITests/
   ```
#### WindowsFormsApp1
存放所有source code，按照MVC pattern，
View 內部存放所有和UI顯示有關的部分，
而ModelObject 則是包含所有邏輯以及存放資料的部分

#### WindowsFormsApp1Tests1
包含除了View 之外所有Class 的Unit Test。

#### WindowsFormsApp1UITests
透過selenium 來實現的自動化UI測試

## Usage

[//]: # (## Contributing)

[//]: # (## License)