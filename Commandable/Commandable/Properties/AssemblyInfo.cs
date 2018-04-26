using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("Commandable")]
[assembly: AssemblyDescription("The library to equip a console application with the command line interface.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Keiho Sakapon")]
[assembly: AssemblyProduct("KLibrary")]
[assembly: AssemblyCopyright("© 2018 Keiho Sakapon")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyMetadata("ProjectUrl", "https://github.com/sakapon/Commandable")]
[assembly: AssemblyMetadata("LicenseUrl", "https://github.com/sakapon/Commandable/blob/master/LICENSE")]
[assembly: AssemblyMetadata("Tags", "Command Line Console")]
[assembly: AssemblyMetadata("ReleaseNotes", "The first release.")]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントから
// 参照できなくなります。COM からこのアセンブリ内の型にアクセスする必要がある場合は、
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// このプロジェクトが COM に公開される場合、次の GUID が typelib の ID になります
[assembly: Guid("489277a4-8180-4a59-97fd-03e63edbd2fe")]

// アセンブリのバージョン情報は次の 4 つの値で構成されています:
//
//      メジャー バージョン
//      マイナー バージョン
//      ビルド番号
//      Revision
//
// すべての値を指定するか、次を使用してビルド番号とリビジョン番号を既定に設定できます
// 以下のように '*' を使用します:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0")]

[assembly: CLSCompliant(true)]
[assembly: InternalsVisibleTo("UnitTest")]
