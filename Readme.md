# Repository to Reproduce [appcenter#377](https://github.com/microsoft/appcenter/issues/377)

Despite the assumption there is an issue only when using connect to app, it is even with `StartApp` (see [AppInitializer](/xamarin-uitest-connectapp-bug.UITests/AppInitializer.cs)) reproducible on this side.

## Steps to reproduce

1. Open Project in Visual Studio
2. Execute UI Tests once
3. Execute UI Test a second time

Error on second run:

```stacktrace
SetUp : Xamarin.UITest.XDB.Exceptions.DeviceAgentException : Unable to end session: An error occurred while sending the request
  ----> System.Net.Http.HttpRequestException : An error occurred while sending the request
  ----> System.Net.WebException : Unable to read data from the transport connection: Connection reset by peer.
  ----> System.IO.IOException : Unable to read data from the transport connection: Connection reset by peer.
  ----> System.Net.Sockets.SocketException : Connection reset by peer

    at Xamarin.UITest.XDB.Services.iOSDeviceAgentService.DeleteSessionAsync (System.String deviceAddress) [0x000fc] in <18ae7883e2424c558186d1d9edf9f14b>:0 
  at Xamarin.UITest.XDB.Services.iOSDeviceAgentService.LaunchTestAsync (System.String deviceId, System.String deviceAddress) [0x001d7] in <18ae7883e2424c558186d1d9edf9f14b>:0 
  at Xamarin.UITest.iOS.iOSAppLauncher.LaunchAppLocal (Xamarin.UITest.Configuration.IiOSAppConfiguration appConfiguration, Xamarin.UITest.Shared.Http.HttpClient httpClient, System.Boolean clearAppData) [0x001e2] in <18ae7883e2424c558186d1d9edf9f14b>:0 
  at Xamarin.UITest.iOS.iOSAppLauncher.LaunchApp (Xamarin.UITest.Configuration.IiOSAppConfiguration appConfiguration, Xamarin.UITest.Shared.Http.HttpClient httpClient, Xamarin.UITest.TestCloud.TestCloudiOSAppConfiguration testCloudAppConfiguration, Xamarin.UITest.Shared.Http.HttpClient testCloudWsClient, Xamarin.UITest.Shared.Http.HttpClient xtcServicesClient, System.Boolean testCloudUseDeviceAgent) [0x00068] in <18ae7883e2424c558186d1d9edf9f14b>:0 
  at Xamarin.UITest.iOS.iOSApp..ctor (Xamarin.UITest.Configuration.IiOSAppConfiguration appConfiguration, Xamarin.UITest.Shared.Execution.IExecutor executor) [0x0028d] in <18ae7883e2424c558186d1d9edf9f14b>:0 
  at Xamarin.UITest.iOS.iOSApp..ctor (Xamarin.UITest.Configuration.IiOSAppConfiguration appConfiguration) [0x00000] in <18ae7883e2424c558186d1d9edf9f14b>:0 
  at Xamarin.UITest.Configuration.iOSAppConfigurator.StartApp (Xamarin.UITest.Configuration.AppDataMode appDataMode) [0x00017] in <18ae7883e2424c558186d1d9edf9f14b>:0 
  at xamarin_uitest_connectapp_bug.UITests.AppInitializer.StartApp (Xamarin.UITest.Platform platform) [0x00001] in /Users/jloos/Workspace/fielmann/xamarin-uitest-connectapp-bug/xamarin-uitest-connectapp-bug.UITests/AppInitializer.cs:11 
  at xamarin_uitest_connectapp_bug.UITests.Tests.BeforeEachTest () [0x00001] in /Users/jloos/Workspace/fielmann/xamarin-uitest-connectapp-bug/xamarin-uitest-connectapp-bug.UITests/Tests.cs:24 
  at (wrapper managed-to-native) System.Reflection.MonoMethod.InternalInvoke(System.Reflection.MonoMethod,object,object[],System.Exception&)
  at System.Reflection.MonoMethod.Invoke (System.Object obj, System.Reflection.BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x0003b] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/corlib/System.Reflection/MonoMethod.cs:305 
--HttpRequestException
  at System.Net.Http.HttpClientHandler.SendAsync (System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) [0x0046c] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/System.Net.Http/System.Net.Http/HttpClientHandler.cs:406 
  at System.Net.Http.HttpClient.SendAsyncWorker (System.Net.Http.HttpRequestMessage request, System.Net.Http.HttpCompletionOption completionOption, System.Threading.CancellationToken cancellationToken) [0x00080] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/System.Net.Http/System.Net.Http/HttpClient.cs:276 
  at Xamarin.UITest.XDB.Services.HttpService+<>c__DisplayClass6_0`1[T].<DeleteAsync>b__0 (System.Threading.CancellationToken token) [0x00082] in <18ae7883e2424c558186d1d9edf9f14b>:0 
  at Xamarin.UITest.XDB.Services.HttpService.ExecuteRequestAsync (System.Func`2[T,TResult] request, System.Threading.CancellationToken token) [0x00084] in <18ae7883e2424c558186d1d9edf9f14b>:0 
  at Xamarin.UITest.XDB.Services.HttpService.RequestAsync[T] (System.Int32 eventId, System.Nullable`1[T] timeout, System.Int32 attempts, System.Nullable`1[T] retryInterval, System.Boolean errorIfUnavailable, System.Boolean logErrors, System.Func`2[T,TResult] request) [0x002f2] in <18ae7883e2424c558186d1d9edf9f14b>:0 
  at Xamarin.UITest.XDB.Services.HttpService.DeleteAsync[T] (System.String url, System.Nullable`1[T] timeout, System.Int32 attempts, System.Nullable`1[T] retryInterval, System.Boolean errorIfUnavailable, System.Boolean logErrors) [0x000f8] in <18ae7883e2424c558186d1d9edf9f14b>:0 
  at Xamarin.UITest.XDB.Services.iOSDeviceAgentService.DeleteSessionAsync (System.String deviceAddress) [0x000cf] in <18ae7883e2424c558186d1d9edf9f14b>:0 
--WebException
  at System.Net.HttpWebRequest.RunWithTimeoutWorker[T] (System.Threading.Tasks.Task`1[TResult] workerTask, System.Int32 timeout, System.Action abort, System.Func`1[TResult] aborted, System.Threading.CancellationTokenSource cts) [0x000e8] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/System/System.Net/HttpWebRequest.cs:956 
  at System.Net.HttpWebRequest.EndGetResponse (System.IAsyncResult asyncResult) [0x00019] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/System/System.Net/HttpWebRequest.cs:1200 
  at System.Threading.Tasks.TaskFactory`1[TResult].FromAsyncCoreLogic (System.IAsyncResult iar, System.Func`2[T,TResult] endFunction, System.Action`1[T] endAction, System.Threading.Tasks.Task`1[TResult] promise, System.Boolean requiresSynchronization) [0x0000f] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/external/corert/src/System.Private.CoreLib/src/System/Threading/Tasks/FutureFactory.cs:534 
--- End of stack trace from previous location where exception was thrown ---

  at System.Net.Http.HttpClientHandler.SendAsync (System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) [0x003d3] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/System.Net.Http/System.Net.Http/HttpClientHandler.cs:402 
--IOException
  at System.Net.Sockets.NetworkStream.EndRead (System.IAsyncResult asyncResult) [0x0007c] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/referencesource/System/net/System/Net/Sockets/NetworkStream.cs:870 
  at System.IO.Stream+<>c.<BeginEndReadAsync>b__43_1 (System.IO.Stream stream, System.IAsyncResult asyncResult) [0x00000] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/referencesource/mscorlib/system/io/stream.cs:450 
  at System.Threading.Tasks.TaskFactory`1+FromAsyncTrimPromise`1[TResult,TInstance].Complete (TInstance thisRef, System.Func`3[T1,T2,TResult] endMethod, System.IAsyncResult asyncResult, System.Boolean requiresSynchronization) [0x00000] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/external/corert/src/System.Private.CoreLib/src/System/Threading/Tasks/FutureFactory.cs:1292 
--- End of stack trace from previous location where exception was thrown ---

  at System.Net.WebResponseStream.InitReadAsync (System.Threading.CancellationToken cancellationToken) [0x00091] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/System/System.Net/WebResponseStream.cs:440 
  at System.Net.WebOperation.Run () [0x0018f] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/System/System.Net/WebOperation.cs:283 
  at System.Net.WebCompletionSource`1[T].WaitForCompletion () [0x0008e] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/System/System.Net/WebCompletionSource.cs:111 
  at System.Net.HttpWebRequest.MyGetResponseAsync (System.Threading.CancellationToken cancellationToken) [0x00235] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/System/System.Net/HttpWebRequest.cs:1016 
--SocketException
  at System.Net.Sockets.Socket.EndReceive (System.IAsyncResult asyncResult) [0x00013] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/referencesource/System/net/System/Net/Sockets/Socket.cs:4524 
  at System.Net.Sockets.NetworkStream.EndRead (System.IAsyncResult asyncResult) [0x00057] in /Users/builder/jenkins/workspace/build-package-osx-mono/2018-08/external/bockbuild/builds/mono-x64/mcs/class/referencesource/System/net/System/Net/Sockets/NetworkStream.cs:858
```

## Reproduced with

```txt
Visual Studio Community 2019 for Mac
Version 8.0.9 (build 5)
Installation UUID: 6f34dc5e-e755-4226-8e8a-5ccf25edb0b7
	GTK+ 2.24.23 (Raleigh theme)
	Xamarin.Mac 5.6.0.2 (d16-0 / 040682909)

	Package version: 518010003

Mono Framework MDK
Runtime:
	Mono 5.18.1.3 (2018-08/fdb26b0a445) (64-bit)
	Package version: 518010003

NuGet
Version: 4.8.2.5835

.NET Core
Runtime: /usr/local/share/dotnet/dotnet
Runtime Versions:
	2.2.5
	2.2.4
	2.2.0
	2.1.9
	2.1.2
	2.0.5
SDK: /usr/local/share/dotnet/sdk/2.2.107/Sdks
SDK Versions:
	2.2.203
	2.2.107
	2.2.106
	2.2.100
	2.1.505
	2.1.302
	2.1.4
MSBuild SDKs: /Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/msbuild/15.0/bin/Sdks

Xamarin.Profiler
Version: 1.6.9
Location: /Applications/Xamarin Profiler.app/Contents/MacOS/Xamarin Profiler

Updater
Version: 11

Xamarin.Android
Version: 9.2.3.0 (Visual Studio Community)
Android SDK: /Users/jloos/Library/Android/sdk
	Supported Android versions:
		4.4 (API level 19)
		5.0 (API level 21)
		5.1 (API level 22)
		6.0 (API level 23)
		7.0 (API level 24)
		7.1 (API level 25)
		8.0 (API level 26)

SDK Tools Version: 26.1.1
SDK Platform Tools Version: 28.0.0
SDK Build Tools Version: 27.0.3

Build Information: 
Mono: mono/mono/2018-08-rc@5ac37ccd385
Java.Interop: xamarin/java.interop/d16-0@c987483
LibZipSharp: grendello/LibZipSharp/d16-1@44de300
LibZip: nih-at/libzip/rel-1-5-1@b95cf3f
MXE: xamarin/mxe/xamarin@b9cbb535
ProGuard: xamarin/proguard/master@905836d
SQLite: xamarin/sqlite/3.26.0@325e91a
Xamarin.Android Tools: xamarin/xamarin-android-tools/d16-0@0a7edd6

Microsoft Mobile OpenJDK
Java SDK: /Users/jloos/Library/Developer/Xamarin/jdk/microsoft_dist_openjdk_1.8.0.9
1.8.0-9
Android Designer EPL code available here:
https://github.com/xamarin/AndroidDesigner.EPL

Android Device Manager
Version: 1.2.0.14
Hash: 86df26f
Branch: remotes/origin/d16-0
Build date: 2019-05-28 18:18:20 UTC

Xamarin Designer
Version: 4.17.4.420
Hash: 0a2420845
Branch: remotes/origin/d16-0
Build date: 2019-05-23 23:40:02 UTC

Apple Developer Tools
Xcode 10.2.1 (14490.122)
Build 10E1001

Xamarin.Mac
Version: 5.8.0.0 (Visual Studio Community)
Hash: 0aa84521
Branch: d16-0
Build date: 2019-04-02 16:01:19-0400

Xamarin Inspector
Version: 1.4.3
Hash: db27525
Branch: 1.4-release
Build date: Mon, 09 Jul 2018 21:20:18 GMT
Client compatibility: 1

Xamarin.iOS
Version: 12.8.0.2 (Visual Studio Community)
Hash: f2248ae6
Branch: d16-0
Build date: 2019-04-23 11:59:04-0400

Build Information
Release ID: 800090005
Git revision: 72a44477dd706608c2300a568f71e5769f89f7ef
Build date: 2019-05-29 15:19:54+00
Build branch: release-8.0
Xamarin extensions: 3e94aa3836143b8f5a5b9151b61a80e2fd278d62

Operating System
Mac OS X 10.14.6
Darwin 18.6.0 Darwin Kernel Version 18.6.0
    Tue May  7 22:54:55 PDT 2019
    root:xnu-4903.270.19.100.1~2/RELEASE_X86_64 x86_64

Enabled user installed extensions
SortAndRemoveOnSave 1.2
```
