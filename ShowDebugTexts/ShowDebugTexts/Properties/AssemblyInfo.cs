using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;
using ShowDebugTexts;

// Общие сведения об этой сборке предоставляются следующим набором
// набора атрибутов. Измените значения этих атрибутов для изменения сведений,
// связанные со сборкой.
[assembly: AssemblyTitle("ShowDebugTexts")]
[assembly: AssemblyDescription("Re-implementation of the debug text updater for Saiko no Sutoka.")]
#if (DEBUG)
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
// [assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ShowDebugTexts")]
[assembly: AssemblyCopyright("The Unlicense")]
// [assembly: AssemblyTrademark("")]
// [assembly: AssemblyCulture("")]

// Установка значения False для параметра ComVisible делает типы в этой сборке невидимыми
// для компонентов COM. Если необходимо обратиться к типу в этой сборке через
// COM, задайте атрибуту ComVisible значение TRUE для этого типа.
[assembly: ComVisible(true)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("f4c0d2f8-c92c-4f8a-8aa1-0a32ba4b238c")]

// Сведения о версии сборки состоят из указанных ниже четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии
//      Номер сборки
//      Редакция
//
// Можно задать все значения или принять номера сборки и редакции по умолчанию 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]

// VersionInfo
[assembly: AssemblyVersion(VersionInfo.ModVersion)]
[assembly: AssemblyFileVersion(VersionInfo.ModVersion)]

// Атрибуты MelonLoader
[assembly: MelonInfo(typeof(Updater), "ShowDebugTexts", VersionInfo.ModVersion, "Anonymous87549236")]
[assembly: MelonGame("Habupain", "Saiko no sutoka")]
// [assembly: MelonPlatform(MelonPlatformAttribute.CompatiblePlatforms.WINDOWS_X64)]
// [assembly: MelonPlatformDomain(MelonPlatformDomainAttribute.CompatibleDomains.IL2CPP)]
// [assembly: MelonGameVersionAttribute(VersionInfo.GameVersion)]
// [assembly: VerifyLoaderVersion(0, 5, 2, true)]